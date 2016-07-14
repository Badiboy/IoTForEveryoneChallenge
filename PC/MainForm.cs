using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using XmlStoreData;
using System.Net.Http;
using System.Threading;

namespace Crazymeter
{
    public partial class FormMain : Form
    {
        private readonly string SelfPath;

        private readonly Dictionary<string, List<string>> RoutesConfig = new Dictionary<string, List<string>>();

        private GMapControl Map;
        GMapOverlay MapMarkersRoute = new GMapOverlay("route markers");
        private GMapOverlay MapMarkersBoards = new GMapOverlay("boards markers");
        GMapOverlay MapRoutes = new GMapOverlay("routes");

        public FormMain()
        {
            // Getting path to cfg file
            SelfPath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            SelfPath = SelfPath.Substring(0, SelfPath.LastIndexOf(Path.DirectorySeparatorChar) + 1);

            InitializeComponent();

            // Initializing GMap library
            Map = new GMapControl();
            gbMap.Controls.Add(Map);
            Map.Dock = DockStyle.Fill;
            Map.CanDragMap = true;
            Map.RoutesEnabled = true;
            Map.MarkersEnabled = true;
            //Map.ShowTileGridLines = true;
            Map.MinZoom = 0;
            Map.MaxZoom = 18;
            Map.Zoom = 16;

            // Selecting google maps and startup point (at SUAI)
            Map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            Map.Position = new PointLatLng(59.929529, 30.296088);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Load config
            XmlStoreDataObject cfg = new XmlStoreDataObject();
            try
            {
                cfg.LoadFromFile(SelfPath + "config.xml");

                var tokens = cfg.FindNestedObject("tokens");
                foreach (var obj in tokens.Objects)
                {
                    lbAuthTokens.Items.Add(obj.GetAttributeAsString("value"));
                }

                var routes = cfg.FindNestedObject("routes");
                foreach (var route in routes.Objects)
                {
                    string routeName = route.GetAttributeAsString("name");
                    List<string> routePoints = new List<string>();
                    lbRoutesList.Items.Add(routeName);
                    RoutesConfig.Add(routeName, routePoints);

                    foreach (var routePoint in route.Objects)
                    {
                        routePoints.Add(routePoint.GetAttributeAsString("value"));
                    }
                }

                var various = cfg.FindNestedObject("params");
                if (various != null)
                {
                    edtServer.Text = various.GetAttributeAsString("server");
                    edtQueryPeriod.Text = various.GetAttributeAsString("queryPeriod");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(@"Config file not found, new one will be created." + Environment.NewLine + E.Message, @"Config loading error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save config
            XmlStoreDataObject cfg = new XmlStoreDataObject();
            cfg.Name = "config";

            XmlStoreDataObject tokens = new XmlStoreDataObject();
            tokens.Name = "tokens";
            cfg.AddChildObject(tokens);
            foreach (var item in lbAuthTokens.Items)
            {
                XmlStoreDataObject token = new XmlStoreDataObject();
                token.Name = "token";
                token.AddAttribute("value", item.ToString());
                tokens.AddChildObject(token);
            }

            XmlStoreDataObject routes = new XmlStoreDataObject();
            routes.Name = "routes";
            cfg.AddChildObject(routes);
            foreach (var item in RoutesConfig)
            {
                XmlStoreDataObject route = new XmlStoreDataObject();
                route.Name = "route";
                route.AddAttribute("name", item.Key);
                routes.AddChildObject(route);

                foreach (string subitem in item.Value)
                {
                    XmlStoreDataObject routePoint = new XmlStoreDataObject();
                    routePoint.Name = "routePoint";
                    routePoint.AddAttribute("value", subitem);
                    route.AddChildObject(routePoint);
                }
            }

            XmlStoreDataObject various = new XmlStoreDataObject();
            various.Name = "params";
            cfg.AddChildObject(various);
            various.AddAttribute("server", edtServer.Text);
            various.AddAttribute("queryPeriod", edtQueryPeriod.Text);

            cfg.StoreToFile(SelfPath + "config.xml");
        }

        private void btnTokenAdd_Click(object sender, EventArgs e)
        {
            // Add application/board token
            if (String.IsNullOrEmpty(txtAuthToken.Text)) return;

            lbAuthTokens.Items.Add(txtAuthToken.Text);
        }

        private void btnTokenDelete_Click(object sender, EventArgs e)
        {
            // Remove application/board token
            if (lbAuthTokens.SelectedIndex == -1) return;

            lbAuthTokens.Items.RemoveAt(lbAuthTokens.SelectedIndex);
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            // Add route
            if (String.IsNullOrEmpty(txtRoute.Text)) return;

            lbRoutesList.Items.Add(txtRoute.Text);

            List<string> routePoints = new List<string>();
            RoutesConfig.Add(txtRoute.Text, routePoints);
        }

        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            // Remove route
            if (lbRoutesList.SelectedIndex == -1) return;

            RoutesConfig.Remove(lbRoutesList.SelectedItem.ToString());
            lbRoutesList.Items.RemoveAt(lbRoutesList.SelectedIndex);
        }

        private void btnAddRouteDetail_Click(object sender, EventArgs e)
        {
            // Add route point
            if (lbRoutesList.SelectedIndex == -1) return;
            if (String.IsNullOrEmpty(txtRouteDetail.Text)) return;

            lbRouteDetails.Items.Add(txtRouteDetail.Text);
            RoutesConfig[lbRoutesList.SelectedItem.ToString()].Add(txtRouteDetail.Text);
        }

        private void btnDeleteRouteDetail_Click(object sender, EventArgs e)
        {
            // Remove route point
            if (lbRoutesList.SelectedIndex == -1) return;
            if (lbRouteDetails.SelectedIndex == -1) return;

            lbRouteDetails.Items.RemoveAt(lbRoutesList.SelectedIndex);
            RoutesConfig[lbRoutesList.SelectedItem.ToString()].Remove(txtRouteDetail.Text);
        }

        private void lbRoutesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbRouteDetails.Items.Clear();
            if (lbRoutesList.SelectedIndex == -1) return;

            foreach (string routePoint in RoutesConfig[lbRoutesList.SelectedItem.ToString()])
            {
                lbRouteDetails.Items.Add(routePoint);
            }
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTab.SelectedTab == tabChallenge)
            {
                // Preparing Challenge tab
                gbApps.Controls.Clear();

                // Creating controls for all tokens
                int counter = 0;
                foreach (string token in lbAuthTokens.Items)
                {
                    counter++;

                    Label lab = new Label();
                    lab.Left = 10;
                    lab.Width = 250;
                    lab.Top = counter * 25;
                    lab.Text = token;
                    lab.Name = @"lblApp" + counter;
                    gbApps.Controls.Add(lab);

                    CheckBox chkB = new CheckBox();
                    chkB.Left = lab.Left + lab.Width + 20;
                    chkB.Width = 70;
                    chkB.Top = lab.Top - 3;
                    chkB.Text = @"Board active";
                    chkB.Name = @"chkBoard" + counter;
                    gbApps.Controls.Add(chkB);

                    CheckBox chkA = new CheckBox();
                    chkA.Left = chkB.Left + chkB.Width + 20;
                    chkA.Width = 70;
                    chkA.Top = lab.Top - 3;
                    chkA.Text = @"App active";
                    chkA.Name = @"chkApp" + counter;
                    gbApps.Controls.Add(chkA);
                }

                lbLoadRoutes.Items.Clear();
                foreach (var route in RoutesConfig)
                {
                    lbLoadRoutes.Items.Add(route.Key);
                }

                tmrStatus.Interval = Int32.Parse(edtQueryPeriod.Text);
                tmrStatus.Start();
            }
            else
            {
                tmrStatus.Stop();
            }
        }

        private void btnLoadRoute_Click(object sender, EventArgs e)
        {
            // Load selected route to the map
            if (lbLoadRoutes.SelectedIndex == -1) return;

            List<PointLatLng> points = new List<PointLatLng>();

            Map.Overlays.Remove(MapMarkersRoute);
            Map.Overlays.Remove(MapRoutes);
            MapMarkersRoute.Markers.Clear();
            MapRoutes.Routes.Clear();

            int count = 0;
            foreach (var routePoint in RoutesConfig[lbLoadRoutes.SelectedItem.ToString()])
            {
                count++;

                string[] routeP = routePoint.Split(';');
                PointLatLng point = new PointLatLng(
                        double.Parse(routeP[0].Trim()),
                        double.Parse(routeP[1].Trim()));
                points.Add(point);

                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.green);
                MapMarkersRoute.Markers.Add(marker);

                if (count > 1)
                {
                    MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(points[count - 2], points[count - 1], false, true, 18);
                    GMapRoute gRoute = new GMapRoute(route.Points, "Challenge route " + count);
                    MapRoutes.Routes.Add(gRoute);
                }
            }
            Map.Overlays.Add(MapMarkersRoute);

            //GMapRoute gRoute = new GMapRoute(points, "Challenge route");
            Map.Overlays.Add(MapRoutes);

            Map.Position = points[0];
        }

        private async void tmrStatus_Tick(object sender, EventArgs e)
        {
            // Interact with boards via HTTP API
            tmrStatus.Stop();

            Map.Overlays.Remove(MapMarkersBoards);

            string baseURL = "http://" + edtServer.Text + "/";
            using (var httpClient = new HttpClient { BaseAddress = new Uri(baseURL) })
            {
                int count = 0;
                foreach (var app in lbAuthTokens.Items)
                {
                    count++;

                    // Check online status
                    //   board
                    var response = await httpClient.GetAsync(app + "/isHardwareConnected");
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (responseData.Contains("Invalid token"))
                        break;
                    bool activeBoard = Boolean.Parse(responseData);
                    var chks = gbApps.Controls.Find(@"chkBoard" + count, false);
                    if (chks.Length > 0)
                        ((CheckBox)chks[0]).Checked = activeBoard;
                    //   app
                    response = await httpClient.GetAsync(app + "/isAppConnected");
                    responseData = await response.Content.ReadAsStringAsync();
                    bool activeApp = Boolean.Parse(responseData);
                    chks = gbApps.Controls.Find(@"chkApp" + count, false);
                    if (chks.Length > 0)
                        ((CheckBox)chks[0]).Checked = activeApp;

                    if (!activeBoard || !activeApp)
                        continue;

                    // Get board GPS coordinates
                    response = await httpClient.GetAsync(app + "/pin/V16");
                    string point1 = await response.Content.ReadAsStringAsync();
                    point1 = point1.Split('"')[1];
                    response = await httpClient.GetAsync(app + "/pin/V17");
                    string point2 = await response.Content.ReadAsStringAsync();
                    point2 = point2.Split('"')[1];
                    //lbDebug.Items.Add(point1);
                    //lbDebug.Items.Add(point2);
                    PointLatLng point = new PointLatLng(
                            (double)(int.Parse(point1)) / 1000000,
                            (double)(int.Parse(point2)) / 1000000);
                    GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.yellow);
                    MapMarkersBoards.Markers.Add(marker);
                }
            }

            Map.Overlays.Add(MapMarkersBoards);

            tmrStatus.Start();
        }

        private async void btnUploadRoute_Click(object sender, EventArgs e)
        {
            // Upload route to boards
            if (lbLoadRoutes.SelectedIndex == -1) return;

            var points = RoutesConfig[lbLoadRoutes.SelectedItem.ToString()];

            string baseURL = "http://" + edtServer.Text + "/";
            using (var httpClient = new HttpClient { BaseAddress = new Uri(baseURL) })
            {
                lbDebug.Items.Add("Uploading route: " + points.Count + " points.");
                var content = new StringContent("[  \"" + points.Count + "\"]", System.Text.Encoding.Default, "application/json");
                var response = await httpClient.PutAsync(lbAuthTokens.Items[0] + "/pin/V21", content);
                string responseData = await response.Content.ReadAsStringAsync();
                Thread.Sleep(500);
                //this.Invalidate();

                int count = 0;
                foreach (var routePoint in RoutesConfig[lbLoadRoutes.SelectedItem.ToString()])
                {
                    count++;
                    lbDebug.Items.Add("Sending point " + count);

                    string[] routeP = routePoint.Split(';');
                    content = new StringContent("[  " +
                        "\"" + (int)(double.Parse(routeP[0].Trim()) * 1000000) + "\", " +
                        "\"" + (int)(double.Parse(routeP[1].Trim()) * 1000000) + "\", " +
                        "\"" + routeP[2].Trim() + "\"" +
                        "]",
                        System.Text.Encoding.Default,
                        "application/json");
                    response = await httpClient.PutAsync(lbAuthTokens.Items[0] + "/pin/V21", content);
                    responseData = await response.Content.ReadAsStringAsync();
                    Thread.Sleep(500);
                }
            }
        }
    }
}
