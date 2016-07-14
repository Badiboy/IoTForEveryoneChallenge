//#define BLYNK_PRINT Serial    // Comment this out to disable prints and save space
#define ENABLE_FONA 1
#define ESP8266FORFONA 1
#include <SoftwareSerial.h>
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>
#include <Adafruit_NeoPixel.h>
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>
#include "Adafruit_FONA.h"

///////////////////////
//   Gyro Settings   //
///////////////////////

#define BNO055_SAMPLERATE_DELAY_MS (100)
Adafruit_BNO055 bno = Adafruit_BNO055(55);

///////////////////////
//   Fona Settings   //
///////////////////////

class GPSPoint
{
  public: 
    GPSPoint(){_lat = 0; _lon = 0;};
    GPSPoint(float lat, float lon)
    {
      _lat = lat;
      _lon = lon;
      _action = "";
    }
    GPSPoint(float lat, float lon, String text)
    {
      _lat = lat;
      _lon = lon;
      _action = text;
    }
    float GetLat(){return _lat;}
    float GetLon(){return _lon;}
    String GetAction(){return _action;}
  private:
    float _lat;
    float _lon;
    String _action;
};

#ifdef ENABLE_FONA
#define FONA_RX 15
#define FONA_TX 12
#define FONA_RST 5
#define FONA_KEY 13
SoftwareSerial fonaSS = SoftwareSerial(FONA_TX, FONA_RX);
SoftwareSerial *fonaSerial = &fonaSS;
Adafruit_FONA fona = Adafruit_FONA(FONA_RST);
GPSPoint currentPoint;
#endif

GPSPoint suaiPoint(59.929529, 30.296088, "SUAI");
bool pathIsReady = false;
int dynamicPath_length;
int dynamicPath_curInd;
GPSPoint** dynamicPath;

////////////////////
// Blynk Settings //
////////////////////

char BlynkAuth[] = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
char WiFiNetwork[] = "WIFI name";
char WiFiPassword[] = "WiFi password";
long int lastPushInterval;
long int lastFonaInterval;
const long int pushInterval = 200UL;
const long int fonaInterval = 2000UL;

///////////////////////
// Hardware Settings //
///////////////////////

#define WS2812_PIN 4 // Pin connected to WS2812 LED
#define BUTTON_PIN 0
#define LED_PIN    5
#define LCD_VIRTUAL               V20 // 8
#define LCD_TEMPHUMID_VIRTUAL     V21 // 8
#define LCD_STATS_VIRTUAL         V22 // 8
#define LCD_RUNTIME_VIRTUAL       V23 // 8
#define LCD_SPLASH_UPDATE_RATE 10000

Adafruit_NeoPixel rgb = Adafruit_NeoPixel(1, WS2812_PIN, NEO_GRB + NEO_KHZ800);
WidgetLCD thLCD(LCD_VIRTUAL); // LCD widget, updated in blynkLoop

int posX, posY, posZ;
int accelX, accelY, accelZ, accelXPrev;
int bSpeed;
int tmpIndex = 0;
byte crazyMetr;
bool isFirstByte = true;
bool firstConnect = true;
bool gps_success = false;
bool lcdSetByProject = false;
char *buffTime = new char[16];
unsigned long lastLCDSplashUpdate = 0;

BLYNK_CONNECTED() 
{
  if (firstConnect)
  {
    thLCD.print(0, 0, "Hello guys,     ");
    thLCD.print(0, 1, "      from Serge");    
    firstConnect = false;
  }
  Blynk.syncAll(); // Sync all virtual variables
}

// Handle RGB from the zeRGBa
BLYNK_WRITE(V0) 
{
  if (param.getLength() < 5)
    return;

  byte red = param[0].asInt();
  byte green = param[1].asInt();
  byte blue = param[2].asInt();

  uint32_t rgbColor = rgb.Color(red, green, blue);
  rgb.setPixelColor(0, rgbColor);
  rgb.show();
}

// Handle Data from Server
BLYNK_WRITE(V21) 
{
  if (param.getLength() < 3)
  {
    if (param.getLength() == 1)
    {
      pathIsReady = false;
      dynamicPath_length = param.asInt();
      for (int i=0;i<dynamicPath_length;++i)
      {
        delete dynamicPath;
      }
      delete [] dynamicPath;
      dynamicPath = new GPSPoint*[dynamicPath_length];
      isFirstByte = false;
      tmpIndex = 0;
        Serial.print("-----LENGTH");
        Serial.print(dynamicPath_length);
    }
    else
      return;
  }
  else
  {
    if ((!isFirstByte)&&(tmpIndex<dynamicPath_length))
    {
      float latIn = (float)param[0].asInt()/(float)1000000;
      float lonIn = (float)param[1].asInt()/(float)1000000;
      const char* textIn = param[2].asStr();
      Serial.print(textIn);
      dynamicPath[tmpIndex] = new GPSPoint(latIn, lonIn, String(textIn));
      tmpIndex++;
        Serial.print("-----POINT ");
        Serial.print(tmpIndex);
    }
    if (tmpIndex==dynamicPath_length)
    {
      for (int i=0;i<dynamicPath_length;++i)
      {
        Serial.println("..Point..");
        Serial.println(dynamicPath[i]->GetLat(), 7);
        Serial.println(dynamicPath[i]->GetLon(), 7);
        Serial.println(dynamicPath[i]->GetAction());
      }
      isFirstByte = true;
      pathIsReady = true;
      dynamicPath_curInd = 0;
    }
  }
}

void setup()
{
  // Initialize hardware
  Serial.begin(115200); // Serial
  rgb.begin(); // RGB LED
  // Initialize Blynk
  Blynk.begin(BlynkAuth, WiFiNetwork, WiFiPassword);
  Serial.println("Init");
  //Adafruit_BNO055::adafruit_bno055_opmode_t::OPERATION_MODE_ACCONLY
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    //while(1);
  }
  
  pinMode(BUTTON_PIN, INPUT); // Button input
  pinMode(LED_PIN, OUTPUT); // LED output   
  digitalWrite(LED_PIN, 0);
  
#ifdef ENABLE_FONA
  pinMode(FONA_KEY, OUTPUT);
  digitalWrite(FONA_KEY, 0);
#endif

  uint8_t system_status, self_test_results, system_error;
  system_status = self_test_results = system_error = 0;
  bno.getSystemStatus(&system_status, &self_test_results, &system_error);
  delay(500);
  sensor_t sensor;
  bno.getSensor(&sensor);
  delay(500);
  bno.setExtCrystalUse(true);
  
  posX = posY = posZ = 0;
  accelX = accelY = accelZ = 0;
  bSpeed = 20;
  crazyMetr = accelXPrev = 0;
  
#ifdef ENABLE_FONA
  //FONA
  Serial.println(F("FONA 808 & 3G GPS"));
  Serial.println(F("Initializing FONA... (May take a few seconds)"));
  
  fonaSerial->begin(4800);
  if (! fona.begin(*fonaSerial))
  {
    Serial.println(F("Couldn't find FONA"));
    //while(1);
  }
  Serial.println(F("FONA is OK"));
  // Try to enable GPS  
  
  Serial.println(F("Enabling GPS..."));
  fona.enableGPS(true);
#endif
  
  lastPushInterval = lastFonaInterval = millis();
}
  
void loop()
{
  Serial.println(BLYNK_TIMEOUT_MS);
  // Execute Blynk.run() as often as possible during the loop
  Blynk.run(); 
  
  uint8_t system, gyro, accel, mag;
  system = gyro = accel = mag = 0;
  bno.getCalibration(&system, &gyro, &accel, &mag);

  if (!system)
  {
    Serial.print("! ");
  }
    
  sensors_event_t event;
  bno.getEvent(&event);
  posX = (int)event.orientation.x;
  posY = (int)event.orientation.y;
  posZ = (int)event.orientation.z;

  //Filtering
  if (posX>180)
    posX = 360 - posX;
  if (posY>180)
    posY = 360 - posY;
  if (posZ>180)
    posZ = 360 - posZ;
  
  Serial.print("X: ");
  Serial.print(event.orientation.x, 4);
  Serial.print("\tY: ");
  Serial.print(event.orientation.y, 4);
  Serial.print("\tZ: ");
  Serial.println(event.orientation.z, 4);
  
  float distance = GetDistance(GPSPoint(59.845476, 30.210532),GPSPoint(59.853184, 30.101715));  

#ifdef ENABLE_FONA
  if (millis() - lastFonaInterval > fonaInterval)
  {
    float latitude, longitude, speed_kph, heading, speed_mph, altitude;
    if (fona.getTime(buffTime, 16))
    {
      Serial.println(buffTime);      
    }
    else
      Serial.println("No time");   
    gps_success = fona.getGPS(&latitude, &longitude, &speed_kph, &heading, NULL);
    if (gps_success) 
    {
      Serial.print("GPS lat:");
      Serial.println(latitude, 6);
      Serial.print("GPS long:");
      Serial.println(longitude, 6);
      Serial.print("GPS speed KPH:");
      Serial.println(speed_kph);
      Serial.print("GPS speed MPH:");
      speed_mph = speed_kph * 0.621371192;
      Serial.println(speed_mph);
      Serial.print("GPS heading:");
      Serial.println(heading);
      Serial.print("GPS altitude:");
      Serial.println(altitude);
      currentPoint = GPSPoint(latitude, longitude);
      bSpeed = speed_mph;
      
      if (pathIsReady)
      {
        distance = GetDistance(currentPoint,*dynamicPath[dynamicPath_curInd]);
        if (distance<0.02)
        {
          dynamicPath_curInd++;
          if (dynamicPath_curInd == dynamicPath_length)
          {
            dynamicPath_curInd = 0;
          }
        }
      }
    } 
    else 
    {
      Serial.println("Waiting for FONA GPS 3D fix...");
    }
    lastFonaInterval = millis();
  }
 #endif

  //---Calculate crazyMetr value---
  if (!accel)
  {
    accelXPrev = accelX;
    imu::Vector<3> tmpVector = bno.getVector(Adafruit_BNO055::adafruit_vector_type_t::VECTOR_LINEARACCEL);
    accelX = tmpVector.x();
    accelY = tmpVector.y();
    accelZ = tmpVector.z();
    crazyMetr = 1.7*bSpeed + 3.5*(abs(accelX) + abs(accelXPrev));
  }
  
  //---Push Data to server---//
  if (millis() - lastPushInterval > pushInterval)
  {
    Blynk.virtualWrite(V7, posX);
    Blynk.virtualWrite(V8, posY);
    Blynk.virtualWrite(V9, posZ);
    Blynk.virtualWrite(V10, accelX);
    Blynk.virtualWrite(V11, accelY);
    Blynk.virtualWrite(V12, accelZ);
    Blynk.virtualWrite(V14, bSpeed);
    Blynk.virtualWrite(V15, crazyMetr);
    if (gps_success)
    {
      Blynk.virtualWrite(V16, int(currentPoint.GetLat()*1000000));
      Blynk.virtualWrite(V17, int(currentPoint.GetLon()*1000000));
    }
    else
    {
      Blynk.virtualWrite(V16, 0);
      Blynk.virtualWrite(V17, 0);
    }
    lastPushInterval = millis();

    if (!lcdSetByProject) lcdSetByProject = true;
    
    if (pathIsReady)
    {
      String tmpStr;
      
      if (dynamicPath[dynamicPath_curInd]->GetAction().length()>16)
        tmpStr = dynamicPath[dynamicPath_curInd]->GetAction().substring(0,16);
      else
        tmpStr = dynamicPath[dynamicPath_curInd]->GetAction();
        
      thLCD.clear(); // Clear the LCD
      thLCD.print(0, 0, tmpStr.c_str()/*topLine.c_str()*/); // Print top line
      thLCD.print(0, 1, buffTime/*botLine.c_str()*/); // Print bottom line
    }
    else
    {
      String topLine = "RunTime-HH:MM:SS";
      String botLine = "    ";
      float seconds, minutes, hours;
      // Calculate seconds, minutes, hours elapsed, based on millis
      seconds = (float)millis() / 1000;
      minutes = seconds / 60;
      hours = minutes / 60;
      seconds = (int)seconds % 60;
      minutes = (int)minutes % 60;
      // Construct a string indicating run time
      if (hours < 10) botLine += "0"; // Add the leading 0
      botLine += String((int)hours) + ":";
      if (minutes < 10) botLine += "0"; // Add the leading 0
      botLine += String((int)minutes) + ":";
      if (seconds < 10) botLine += "0"; // Add the leading 0
      botLine += String((int)seconds);    
      thLCD.clear(); // Clear the LCD
      thLCD.print(0, 0, botLine/*topLine*/.c_str()); // Print top line
      thLCD.print(0, 1, buffTime/*botLine.c_str()*/); // Print bottom line
    }
  }
  delay(BNO055_SAMPLERATE_DELAY_MS);
}

//Return distance between 2 GPS point's
float GetDistance(GPSPoint in1, GPSPoint in2)
{
  //radians = degrees * PI / 180;
  float R = 6371.0; // Earth radius, km
  float dLat = (in2.GetLat() - in1.GetLat())* PI / 180;
  float dLon = (in2.GetLon() - in1.GetLon())* PI / 180;
  float lat1 = in1.GetLat() * PI / 180;
  float lat2 = in2.GetLat() * PI / 180;
  
  float a = sin(dLat/2) * sin(dLat/2) +
          sin(dLon/2) * sin(dLon/2) * cos(lat1) * cos(lat2); 
    
  return R * 2 * atan2(sqrt(a), sqrt(1-a));
}
