namespace Crazymeter
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtQueryPeriod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtServer = new System.Windows.Forms.TextBox();
            this.gbAuthTokens = new System.Windows.Forms.GroupBox();
            this.lbAuthTokens = new System.Windows.Forms.ListBox();
            this.pnlManageTokens = new System.Windows.Forms.Panel();
            this.txtAuthToken = new System.Windows.Forms.TextBox();
            this.btnTokenDelete = new System.Windows.Forms.Button();
            this.btnTokenAdd = new System.Windows.Forms.Button();
            this.gbRoutes = new System.Windows.Forms.GroupBox();
            this.gbRouteDetails = new System.Windows.Forms.GroupBox();
            this.lbRouteDetails = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRouteDetail = new System.Windows.Forms.TextBox();
            this.btnDeleteRouteDetail = new System.Windows.Forms.Button();
            this.btnAddRouteDetail = new System.Windows.Forms.Button();
            this.gbRoutesList = new System.Windows.Forms.GroupBox();
            this.lbRoutesList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.btnDeleteRoute = new System.Windows.Forms.Button();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.tabChallenge = new System.Windows.Forms.TabPage();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.gbLoadRoutes = new System.Windows.Forms.GroupBox();
            this.lbLoadRoutes = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLoadRoute = new System.Windows.Forms.Button();
            this.gbApps = new System.Windows.Forms.GroupBox();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.btnUploadRoute = new System.Windows.Forms.Button();
            this.gbDebug = new System.Windows.Forms.GroupBox();
            this.lbDebug = new System.Windows.Forms.ListBox();
            this.MainTab.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbAuthTokens.SuspendLayout();
            this.pnlManageTokens.SuspendLayout();
            this.gbRoutes.SuspendLayout();
            this.gbRouteDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbRoutesList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabChallenge.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbLoadRoutes.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.tabSettings);
            this.MainTab.Controls.Add(this.tabChallenge);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Margin = new System.Windows.Forms.Padding(4);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1074, 735);
            this.MainTab.TabIndex = 0;
            this.MainTab.SelectedIndexChanged += new System.EventHandler(this.MainTab_SelectedIndexChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.gbAuthTokens);
            this.tabSettings.Controls.Add(this.gbRoutes);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(4);
            this.tabSettings.Size = new System.Drawing.Size(1066, 706);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.edtQueryPeriod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edtServer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(523, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(519, 347);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Various settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Query period (ms):";
            // 
            // edtQueryPeriod
            // 
            this.edtQueryPeriod.Location = new System.Drawing.Point(127, 57);
            this.edtQueryPeriod.Name = "edtQueryPeriod";
            this.edtQueryPeriod.Size = new System.Drawing.Size(225, 22);
            this.edtQueryPeriod.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP:Port";
            // 
            // edtServer
            // 
            this.edtServer.Location = new System.Drawing.Point(127, 29);
            this.edtServer.Name = "edtServer";
            this.edtServer.Size = new System.Drawing.Size(225, 22);
            this.edtServer.TabIndex = 0;
            // 
            // gbAuthTokens
            // 
            this.gbAuthTokens.Controls.Add(this.lbAuthTokens);
            this.gbAuthTokens.Controls.Add(this.pnlManageTokens);
            this.gbAuthTokens.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbAuthTokens.Location = new System.Drawing.Point(4, 4);
            this.gbAuthTokens.Margin = new System.Windows.Forms.Padding(4);
            this.gbAuthTokens.Name = "gbAuthTokens";
            this.gbAuthTokens.Padding = new System.Windows.Forms.Padding(4);
            this.gbAuthTokens.Size = new System.Drawing.Size(519, 347);
            this.gbAuthTokens.TabIndex = 0;
            this.gbAuthTokens.TabStop = false;
            this.gbAuthTokens.Text = "Application tokens";
            // 
            // lbAuthTokens
            // 
            this.lbAuthTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAuthTokens.FormattingEnabled = true;
            this.lbAuthTokens.ItemHeight = 16;
            this.lbAuthTokens.Location = new System.Drawing.Point(4, 19);
            this.lbAuthTokens.Margin = new System.Windows.Forms.Padding(4);
            this.lbAuthTokens.Name = "lbAuthTokens";
            this.lbAuthTokens.Size = new System.Drawing.Size(511, 285);
            this.lbAuthTokens.TabIndex = 0;
            // 
            // pnlManageTokens
            // 
            this.pnlManageTokens.Controls.Add(this.txtAuthToken);
            this.pnlManageTokens.Controls.Add(this.btnTokenDelete);
            this.pnlManageTokens.Controls.Add(this.btnTokenAdd);
            this.pnlManageTokens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlManageTokens.Location = new System.Drawing.Point(4, 304);
            this.pnlManageTokens.Margin = new System.Windows.Forms.Padding(4);
            this.pnlManageTokens.Name = "pnlManageTokens";
            this.pnlManageTokens.Size = new System.Drawing.Size(511, 39);
            this.pnlManageTokens.TabIndex = 2;
            // 
            // txtAuthToken
            // 
            this.txtAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthToken.Location = new System.Drawing.Point(4, 6);
            this.txtAuthToken.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthToken.Name = "txtAuthToken";
            this.txtAuthToken.Size = new System.Drawing.Size(285, 22);
            this.txtAuthToken.TabIndex = 4;
            // 
            // btnTokenDelete
            // 
            this.btnTokenDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTokenDelete.Location = new System.Drawing.Point(407, 4);
            this.btnTokenDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnTokenDelete.Name = "btnTokenDelete";
            this.btnTokenDelete.Size = new System.Drawing.Size(100, 28);
            this.btnTokenDelete.TabIndex = 3;
            this.btnTokenDelete.Text = "Delete";
            this.btnTokenDelete.UseVisualStyleBackColor = true;
            this.btnTokenDelete.Click += new System.EventHandler(this.btnTokenDelete_Click);
            // 
            // btnTokenAdd
            // 
            this.btnTokenAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTokenAdd.Location = new System.Drawing.Point(299, 4);
            this.btnTokenAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnTokenAdd.Name = "btnTokenAdd";
            this.btnTokenAdd.Size = new System.Drawing.Size(100, 28);
            this.btnTokenAdd.TabIndex = 2;
            this.btnTokenAdd.Text = "Add";
            this.btnTokenAdd.UseVisualStyleBackColor = true;
            this.btnTokenAdd.Click += new System.EventHandler(this.btnTokenAdd_Click);
            // 
            // gbRoutes
            // 
            this.gbRoutes.Controls.Add(this.gbRouteDetails);
            this.gbRoutes.Controls.Add(this.gbRoutesList);
            this.gbRoutes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbRoutes.Location = new System.Drawing.Point(4, 351);
            this.gbRoutes.Margin = new System.Windows.Forms.Padding(4);
            this.gbRoutes.Name = "gbRoutes";
            this.gbRoutes.Padding = new System.Windows.Forms.Padding(4);
            this.gbRoutes.Size = new System.Drawing.Size(1058, 351);
            this.gbRoutes.TabIndex = 1;
            this.gbRoutes.TabStop = false;
            this.gbRoutes.Text = "Routes";
            // 
            // gbRouteDetails
            // 
            this.gbRouteDetails.Controls.Add(this.lbRouteDetails);
            this.gbRouteDetails.Controls.Add(this.panel2);
            this.gbRouteDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRouteDetails.Location = new System.Drawing.Point(519, 19);
            this.gbRouteDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbRouteDetails.Name = "gbRouteDetails";
            this.gbRouteDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbRouteDetails.Size = new System.Drawing.Size(535, 328);
            this.gbRouteDetails.TabIndex = 2;
            this.gbRouteDetails.TabStop = false;
            this.gbRouteDetails.Text = "Route points";
            // 
            // lbRouteDetails
            // 
            this.lbRouteDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRouteDetails.FormattingEnabled = true;
            this.lbRouteDetails.ItemHeight = 16;
            this.lbRouteDetails.Location = new System.Drawing.Point(4, 19);
            this.lbRouteDetails.Margin = new System.Windows.Forms.Padding(4);
            this.lbRouteDetails.Name = "lbRouteDetails";
            this.lbRouteDetails.Size = new System.Drawing.Size(527, 266);
            this.lbRouteDetails.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtRouteDetail);
            this.panel2.Controls.Add(this.btnDeleteRouteDetail);
            this.panel2.Controls.Add(this.btnAddRouteDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 285);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 39);
            this.panel2.TabIndex = 2;
            // 
            // txtRouteDetail
            // 
            this.txtRouteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteDetail.Location = new System.Drawing.Point(4, 6);
            this.txtRouteDetail.Margin = new System.Windows.Forms.Padding(4);
            this.txtRouteDetail.Name = "txtRouteDetail";
            this.txtRouteDetail.Size = new System.Drawing.Size(302, 22);
            this.txtRouteDetail.TabIndex = 4;
            // 
            // btnDeleteRouteDetail
            // 
            this.btnDeleteRouteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRouteDetail.Location = new System.Drawing.Point(423, 4);
            this.btnDeleteRouteDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteRouteDetail.Name = "btnDeleteRouteDetail";
            this.btnDeleteRouteDetail.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteRouteDetail.TabIndex = 3;
            this.btnDeleteRouteDetail.Text = "Delete";
            this.btnDeleteRouteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteRouteDetail.Click += new System.EventHandler(this.btnDeleteRouteDetail_Click);
            // 
            // btnAddRouteDetail
            // 
            this.btnAddRouteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRouteDetail.Location = new System.Drawing.Point(315, 4);
            this.btnAddRouteDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRouteDetail.Name = "btnAddRouteDetail";
            this.btnAddRouteDetail.Size = new System.Drawing.Size(100, 28);
            this.btnAddRouteDetail.TabIndex = 2;
            this.btnAddRouteDetail.Text = "Add";
            this.btnAddRouteDetail.UseVisualStyleBackColor = true;
            this.btnAddRouteDetail.Click += new System.EventHandler(this.btnAddRouteDetail_Click);
            // 
            // gbRoutesList
            // 
            this.gbRoutesList.Controls.Add(this.lbRoutesList);
            this.gbRoutesList.Controls.Add(this.panel1);
            this.gbRoutesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRoutesList.Location = new System.Drawing.Point(4, 19);
            this.gbRoutesList.Margin = new System.Windows.Forms.Padding(4);
            this.gbRoutesList.Name = "gbRoutesList";
            this.gbRoutesList.Padding = new System.Windows.Forms.Padding(4);
            this.gbRoutesList.Size = new System.Drawing.Size(515, 328);
            this.gbRoutesList.TabIndex = 1;
            this.gbRoutesList.TabStop = false;
            this.gbRoutesList.Text = "Routes list";
            // 
            // lbRoutesList
            // 
            this.lbRoutesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoutesList.FormattingEnabled = true;
            this.lbRoutesList.ItemHeight = 16;
            this.lbRoutesList.Location = new System.Drawing.Point(4, 19);
            this.lbRoutesList.Margin = new System.Windows.Forms.Padding(4);
            this.lbRoutesList.Name = "lbRoutesList";
            this.lbRoutesList.Size = new System.Drawing.Size(507, 266);
            this.lbRoutesList.TabIndex = 0;
            this.lbRoutesList.SelectedIndexChanged += new System.EventHandler(this.lbRoutesList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRoute);
            this.panel1.Controls.Add(this.btnDeleteRoute);
            this.panel1.Controls.Add(this.btnAddRoute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 285);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 39);
            this.panel1.TabIndex = 2;
            // 
            // txtRoute
            // 
            this.txtRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoute.Location = new System.Drawing.Point(4, 6);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(281, 22);
            this.txtRoute.TabIndex = 4;
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRoute.Location = new System.Drawing.Point(403, 4);
            this.btnDeleteRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteRoute.TabIndex = 3;
            this.btnDeleteRoute.Text = "Delete";
            this.btnDeleteRoute.UseVisualStyleBackColor = true;
            this.btnDeleteRoute.Click += new System.EventHandler(this.btnDeleteRoute_Click);
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoute.Location = new System.Drawing.Point(295, 4);
            this.btnAddRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(100, 28);
            this.btnAddRoute.TabIndex = 2;
            this.btnAddRoute.Text = "Add";
            this.btnAddRoute.UseVisualStyleBackColor = true;
            this.btnAddRoute.Click += new System.EventHandler(this.btnAddRoute_Click);
            // 
            // tabChallenge
            // 
            this.tabChallenge.Controls.Add(this.gbMap);
            this.tabChallenge.Controls.Add(this.panel3);
            this.tabChallenge.Location = new System.Drawing.Point(4, 25);
            this.tabChallenge.Margin = new System.Windows.Forms.Padding(4);
            this.tabChallenge.Name = "tabChallenge";
            this.tabChallenge.Padding = new System.Windows.Forms.Padding(4);
            this.tabChallenge.Size = new System.Drawing.Size(1066, 706);
            this.tabChallenge.TabIndex = 2;
            this.tabChallenge.Text = "Challenge";
            this.tabChallenge.UseVisualStyleBackColor = true;
            // 
            // gbMap
            // 
            this.gbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMap.Location = new System.Drawing.Point(4, 4);
            this.gbMap.Name = "gbMap";
            this.gbMap.Size = new System.Drawing.Size(1058, 404);
            this.gbMap.TabIndex = 0;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Map";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbDebug);
            this.panel3.Controls.Add(this.gbLoadRoutes);
            this.panel3.Controls.Add(this.gbApps);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(4, 408);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1058, 294);
            this.panel3.TabIndex = 1;
            // 
            // gbLoadRoutes
            // 
            this.gbLoadRoutes.Controls.Add(this.lbLoadRoutes);
            this.gbLoadRoutes.Controls.Add(this.panel4);
            this.gbLoadRoutes.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLoadRoutes.Location = new System.Drawing.Point(434, 0);
            this.gbLoadRoutes.Margin = new System.Windows.Forms.Padding(4);
            this.gbLoadRoutes.Name = "gbLoadRoutes";
            this.gbLoadRoutes.Padding = new System.Windows.Forms.Padding(4);
            this.gbLoadRoutes.Size = new System.Drawing.Size(256, 294);
            this.gbLoadRoutes.TabIndex = 6;
            this.gbLoadRoutes.TabStop = false;
            this.gbLoadRoutes.Text = "Routes list";
            // 
            // lbLoadRoutes
            // 
            this.lbLoadRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoadRoutes.FormattingEnabled = true;
            this.lbLoadRoutes.ItemHeight = 16;
            this.lbLoadRoutes.Location = new System.Drawing.Point(4, 19);
            this.lbLoadRoutes.Margin = new System.Windows.Forms.Padding(4);
            this.lbLoadRoutes.Name = "lbLoadRoutes";
            this.lbLoadRoutes.Size = new System.Drawing.Size(248, 232);
            this.lbLoadRoutes.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUploadRoute);
            this.panel4.Controls.Add(this.btnLoadRoute);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(4, 251);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 39);
            this.panel4.TabIndex = 2;
            // 
            // btnLoadRoute
            // 
            this.btnLoadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRoute.Location = new System.Drawing.Point(144, 4);
            this.btnLoadRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadRoute.Name = "btnLoadRoute";
            this.btnLoadRoute.Size = new System.Drawing.Size(100, 28);
            this.btnLoadRoute.TabIndex = 3;
            this.btnLoadRoute.Text = "Load route";
            this.btnLoadRoute.UseVisualStyleBackColor = true;
            this.btnLoadRoute.Click += new System.EventHandler(this.btnLoadRoute_Click);
            // 
            // gbApps
            // 
            this.gbApps.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbApps.Location = new System.Drawing.Point(0, 0);
            this.gbApps.Name = "gbApps";
            this.gbApps.Size = new System.Drawing.Size(434, 294);
            this.gbApps.TabIndex = 5;
            this.gbApps.TabStop = false;
            this.gbApps.Text = "Blynk applications";
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 5000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // btnUploadRoute
            // 
            this.btnUploadRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadRoute.Location = new System.Drawing.Point(4, 4);
            this.btnUploadRoute.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadRoute.Name = "btnUploadRoute";
            this.btnUploadRoute.Size = new System.Drawing.Size(100, 28);
            this.btnUploadRoute.TabIndex = 4;
            this.btnUploadRoute.Text = "Upload route";
            this.btnUploadRoute.UseVisualStyleBackColor = true;
            this.btnUploadRoute.Click += new System.EventHandler(this.btnUploadRoute_Click);
            // 
            // gbDebug
            // 
            this.gbDebug.Controls.Add(this.lbDebug);
            this.gbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDebug.Location = new System.Drawing.Point(690, 0);
            this.gbDebug.Name = "gbDebug";
            this.gbDebug.Size = new System.Drawing.Size(368, 294);
            this.gbDebug.TabIndex = 9;
            this.gbDebug.TabStop = false;
            this.gbDebug.Text = "Debug window";
            // 
            // lbDebug
            // 
            this.lbDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDebug.FormattingEnabled = true;
            this.lbDebug.ItemHeight = 16;
            this.lbDebug.Location = new System.Drawing.Point(3, 18);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(362, 273);
            this.lbDebug.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 735);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bicycle Crazymeter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MainTab.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAuthTokens.ResumeLayout(false);
            this.pnlManageTokens.ResumeLayout(false);
            this.pnlManageTokens.PerformLayout();
            this.gbRoutes.ResumeLayout(false);
            this.gbRouteDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbRoutesList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabChallenge.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gbLoadRoutes.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gbDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabChallenge;
        private System.Windows.Forms.GroupBox gbAuthTokens;
        private System.Windows.Forms.Panel pnlManageTokens;
        private System.Windows.Forms.TextBox txtAuthToken;
        private System.Windows.Forms.Button btnTokenDelete;
        private System.Windows.Forms.Button btnTokenAdd;
        private System.Windows.Forms.ListBox lbAuthTokens;
        private System.Windows.Forms.GroupBox gbRoutes;
        private System.Windows.Forms.GroupBox gbRouteDetails;
        private System.Windows.Forms.ListBox lbRouteDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRouteDetail;
        private System.Windows.Forms.Button btnDeleteRouteDetail;
        private System.Windows.Forms.Button btnAddRouteDetail;
        private System.Windows.Forms.GroupBox gbRoutesList;
        private System.Windows.Forms.ListBox lbRoutesList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Button btnDeleteRoute;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.GroupBox gbMap;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbLoadRoutes;
        private System.Windows.Forms.ListBox lbLoadRoutes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLoadRoute;
        private System.Windows.Forms.GroupBox gbApps;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtQueryPeriod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUploadRoute;
        private System.Windows.Forms.GroupBox gbDebug;
        private System.Windows.Forms.ListBox lbDebug;
    }
}

