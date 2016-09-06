namespace DGWebScanner
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("N/A");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.getVulnerableInfo = new System.ComponentModel.BackgroundWorker();
            this.websiteURL = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.scanWebsite = new MaterialSkin.Controls.MaterialRaisedButton();
            this.vulnerableLabel = new MaterialSkin.Controls.MaterialLabel();
            this.vulnerableColumnsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.columnsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.versionNumberLabel = new MaterialSkin.Controls.MaterialLabel();
            this.usernamesLabel = new MaterialSkin.Controls.MaterialLabel();
            this.usernameStatus = new MaterialSkin.Controls.MaterialLabel();
            this.versionNumberStatus = new MaterialSkin.Controls.MaterialLabel();
            this.columnsStatus = new MaterialSkin.Controls.MaterialLabel();
            this.vulnerableColumnsStatus = new MaterialSkin.Controls.MaterialLabel();
            this.vulnerableStatus = new MaterialSkin.Controls.MaterialLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.databaseInfoTreeView = new System.Windows.Forms.TreeView();
            this.tabView = new System.Windows.Forms.TabControl();
            this.databaseTab = new System.Windows.Forms.TabPage();
            this.databaseGridView = new System.Windows.Forms.DataGridView();
            this.adminTab = new System.Windows.Forms.TabPage();
            this.maybeAdminURLListBox = new System.Windows.Forms.ListBox();
            this.adminURLListBox = new System.Windows.Forms.ListBox();
            this.possibleAdminlabel = new MaterialSkin.Controls.MaterialLabel();
            this.findAdminButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.websiteURLAdmin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.toolsTab = new System.Windows.Forms.TabPage();
            this.copyHashButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.decodeHashStatus = new MaterialSkin.Controls.MaterialLabel();
            this.decodeHashButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.decodeHashText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.findAdminPageWorker = new System.ComponentModel.BackgroundWorker();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.darkCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.lightCheckBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.themeColorLabel = new MaterialSkin.Controls.MaterialLabel();
            this.accentColorComboBox = new System.Windows.Forms.ComboBox();
            this.accentColorLabel = new MaterialSkin.Controls.MaterialLabel();
            this.primaryColorComboBox = new System.Windows.Forms.ComboBox();
            this.primaryColorLabel = new MaterialSkin.Controls.MaterialLabel();
            this.textShadeBlackButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.textShadeWhiteButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.textShadeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.proxyPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.proxyUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.proxyPort = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.proxyIP = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.proxyPasswordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.proxyUsernameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.proxyPortLabel = new MaterialSkin.Controls.MaterialLabel();
            this.proxyIPLabel = new MaterialSkin.Controls.MaterialLabel();
            this.proxySettingsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.saveSettings = new MaterialSkin.Controls.MaterialRaisedButton();
            this.internetTimeoutText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.adminPageTimeoutLabel = new MaterialSkin.Controls.MaterialLabel();
            this.statusInfo = new MaterialSkin.Controls.MaterialLabel();
            this.settingsButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.checkUpdates = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.databaseGridViewMenuStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeHashWorker = new System.ComponentModel.BackgroundWorker();
            this.tabView.SuspendLayout();
            this.databaseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseGridView)).BeginInit();
            this.adminTab.SuspendLayout();
            this.toolsTab.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.databaseGridViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // getVulnerableInfo
            // 
            this.getVulnerableInfo.WorkerReportsProgress = true;
            this.getVulnerableInfo.WorkerSupportsCancellation = true;
            this.getVulnerableInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getVulnerableInfo_DoWork);
            this.getVulnerableInfo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.getVulnerableInfo_ProgressChanged);
            this.getVulnerableInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getVulnerableInfo_RunWorkerCompleted);
            // 
            // websiteURL
            // 
            this.websiteURL.Depth = 0;
            this.websiteURL.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteURL.Hint = "";
            this.websiteURL.Location = new System.Drawing.Point(12, 70);
            this.websiteURL.MouseState = MaterialSkin.MouseState.HOVER;
            this.websiteURL.Name = "websiteURL";
            this.websiteURL.PasswordChar = '\0';
            this.websiteURL.SelectedText = "";
            this.websiteURL.SelectionLength = 0;
            this.websiteURL.SelectionStart = 0;
            this.websiteURL.Size = new System.Drawing.Size(457, 23);
            this.websiteURL.TabIndex = 14;
            this.websiteURL.UseSystemPasswordChar = false;
            this.websiteURL.Click += new System.EventHandler(this.websiteURL_Click);
            this.websiteURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.websiteURL_KeyPress);
            // 
            // scanWebsite
            // 
            this.scanWebsite.Depth = 0;
            this.scanWebsite.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.scanWebsite.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanWebsite.Location = new System.Drawing.Point(475, 70);
            this.scanWebsite.MouseState = MaterialSkin.MouseState.HOVER;
            this.scanWebsite.Name = "scanWebsite";
            this.scanWebsite.Primary = true;
            this.scanWebsite.Size = new System.Drawing.Size(123, 23);
            this.scanWebsite.TabIndex = 15;
            this.scanWebsite.Text = "Scan Website";
            this.scanWebsite.UseVisualStyleBackColor = true;
            this.scanWebsite.Click += new System.EventHandler(this.scanWebsite_Click_1);
            // 
            // vulnerableLabel
            // 
            this.vulnerableLabel.AutoSize = true;
            this.vulnerableLabel.Depth = 0;
            this.vulnerableLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.vulnerableLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.vulnerableLabel.Location = new System.Drawing.Point(215, 105);
            this.vulnerableLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.vulnerableLabel.Name = "vulnerableLabel";
            this.vulnerableLabel.Size = new System.Drawing.Size(88, 19);
            this.vulnerableLabel.TabIndex = 16;
            this.vulnerableLabel.Text = "Vulnerable :";
            // 
            // vulnerableColumnsLabel
            // 
            this.vulnerableColumnsLabel.AutoSize = true;
            this.vulnerableColumnsLabel.Depth = 0;
            this.vulnerableColumnsLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.vulnerableColumnsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.vulnerableColumnsLabel.Location = new System.Drawing.Point(151, 143);
            this.vulnerableColumnsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.vulnerableColumnsLabel.Name = "vulnerableColumnsLabel";
            this.vulnerableColumnsLabel.Size = new System.Drawing.Size(152, 19);
            this.vulnerableColumnsLabel.TabIndex = 17;
            this.vulnerableColumnsLabel.Text = "Vulnerable Columns :";
            // 
            // columnsLabel
            // 
            this.columnsLabel.AutoSize = true;
            this.columnsLabel.Depth = 0;
            this.columnsLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.columnsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.columnsLabel.Location = new System.Drawing.Point(226, 124);
            this.columnsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.columnsLabel.Name = "columnsLabel";
            this.columnsLabel.Size = new System.Drawing.Size(77, 19);
            this.columnsLabel.TabIndex = 18;
            this.columnsLabel.Text = "Columns :";
            // 
            // versionNumberLabel
            // 
            this.versionNumberLabel.AutoSize = true;
            this.versionNumberLabel.Depth = 0;
            this.versionNumberLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.versionNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.versionNumberLabel.Location = new System.Drawing.Point(177, 162);
            this.versionNumberLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionNumberLabel.Name = "versionNumberLabel";
            this.versionNumberLabel.Size = new System.Drawing.Size(126, 19);
            this.versionNumberLabel.TabIndex = 19;
            this.versionNumberLabel.Text = "Version Number :";
            // 
            // usernamesLabel
            // 
            this.usernamesLabel.AutoSize = true;
            this.usernamesLabel.Depth = 0;
            this.usernamesLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.usernamesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.usernamesLabel.Location = new System.Drawing.Point(7, 96);
            this.usernamesLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernamesLabel.Name = "usernamesLabel";
            this.usernamesLabel.Size = new System.Drawing.Size(85, 19);
            this.usernamesLabel.TabIndex = 20;
            this.usernamesLabel.Text = "Username :";
            this.usernamesLabel.Visible = false;
            // 
            // usernameStatus
            // 
            this.usernameStatus.AutoSize = true;
            this.usernameStatus.Depth = 0;
            this.usernameStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.usernameStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.usernameStatus.Location = new System.Drawing.Point(98, 96);
            this.usernameStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernameStatus.Name = "usernameStatus";
            this.usernameStatus.Size = new System.Drawing.Size(36, 19);
            this.usernameStatus.TabIndex = 25;
            this.usernameStatus.Text = "N/A";
            this.usernameStatus.Visible = false;
            // 
            // versionNumberStatus
            // 
            this.versionNumberStatus.AutoSize = true;
            this.versionNumberStatus.Depth = 0;
            this.versionNumberStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.versionNumberStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.versionNumberStatus.Location = new System.Drawing.Point(309, 162);
            this.versionNumberStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionNumberStatus.Name = "versionNumberStatus";
            this.versionNumberStatus.Size = new System.Drawing.Size(36, 19);
            this.versionNumberStatus.TabIndex = 24;
            this.versionNumberStatus.Text = "N/A";
            // 
            // columnsStatus
            // 
            this.columnsStatus.AutoSize = true;
            this.columnsStatus.Depth = 0;
            this.columnsStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.columnsStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.columnsStatus.Location = new System.Drawing.Point(309, 124);
            this.columnsStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.columnsStatus.Name = "columnsStatus";
            this.columnsStatus.Size = new System.Drawing.Size(36, 19);
            this.columnsStatus.TabIndex = 23;
            this.columnsStatus.Text = "N/A";
            // 
            // vulnerableColumnsStatus
            // 
            this.vulnerableColumnsStatus.AutoSize = true;
            this.vulnerableColumnsStatus.Depth = 0;
            this.vulnerableColumnsStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.vulnerableColumnsStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.vulnerableColumnsStatus.Location = new System.Drawing.Point(309, 143);
            this.vulnerableColumnsStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.vulnerableColumnsStatus.Name = "vulnerableColumnsStatus";
            this.vulnerableColumnsStatus.Size = new System.Drawing.Size(36, 19);
            this.vulnerableColumnsStatus.TabIndex = 22;
            this.vulnerableColumnsStatus.Text = "N/A";
            // 
            // vulnerableStatus
            // 
            this.vulnerableStatus.AutoSize = true;
            this.vulnerableStatus.Depth = 0;
            this.vulnerableStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.vulnerableStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.vulnerableStatus.Location = new System.Drawing.Point(309, 105);
            this.vulnerableStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.vulnerableStatus.Name = "vulnerableStatus";
            this.vulnerableStatus.Size = new System.Drawing.Size(36, 19);
            this.vulnerableStatus.TabIndex = 21;
            this.vulnerableStatus.Text = "N/A";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 564);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(865, 35);
            this.progressBar1.TabIndex = 13;
            // 
            // databaseInfoTreeView
            // 
            this.databaseInfoTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.databaseInfoTreeView.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseInfoTreeView.Location = new System.Drawing.Point(3, 3);
            this.databaseInfoTreeView.Name = "databaseInfoTreeView";
            treeNode2.Name = "notAvailable";
            treeNode2.Text = "N/A";
            this.databaseInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.databaseInfoTreeView.Size = new System.Drawing.Size(236, 288);
            this.databaseInfoTreeView.TabIndex = 30;
            this.databaseInfoTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.databaseInfoTreeView_AfterSelect);
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.databaseTab);
            this.tabView.Controls.Add(this.adminTab);
            this.tabView.Controls.Add(this.toolsTab);
            this.tabView.Location = new System.Drawing.Point(12, 184);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(593, 325);
            this.tabView.TabIndex = 32;
            this.tabView.SelectedIndexChanged += new System.EventHandler(this.tabView_SelectedIndexChanged);
            // 
            // databaseTab
            // 
            this.databaseTab.Controls.Add(this.databaseGridView);
            this.databaseTab.Controls.Add(this.databaseInfoTreeView);
            this.databaseTab.Location = new System.Drawing.Point(4, 27);
            this.databaseTab.Name = "databaseTab";
            this.databaseTab.Padding = new System.Windows.Forms.Padding(3);
            this.databaseTab.Size = new System.Drawing.Size(585, 294);
            this.databaseTab.TabIndex = 0;
            this.databaseTab.Text = "Database Info";
            this.databaseTab.UseVisualStyleBackColor = true;
            // 
            // databaseGridView
            // 
            this.databaseGridView.AllowUserToAddRows = false;
            this.databaseGridView.AllowUserToDeleteRows = false;
            this.databaseGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.databaseGridView.BackgroundColor = System.Drawing.Color.White;
            this.databaseGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.databaseGridView.Location = new System.Drawing.Point(239, 3);
            this.databaseGridView.Name = "databaseGridView";
            this.databaseGridView.ReadOnly = true;
            this.databaseGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.databaseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.databaseGridView.Size = new System.Drawing.Size(343, 288);
            this.databaseGridView.TabIndex = 31;
            this.databaseGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.databaseGridView_ColumnAdded);
            this.databaseGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.databaseGridView_ColumnHeaderMouseClick);
            // 
            // adminTab
            // 
            this.adminTab.BackColor = System.Drawing.Color.White;
            this.adminTab.Controls.Add(this.maybeAdminURLListBox);
            this.adminTab.Controls.Add(this.adminURLListBox);
            this.adminTab.Controls.Add(this.possibleAdminlabel);
            this.adminTab.Controls.Add(this.findAdminButton);
            this.adminTab.Controls.Add(this.websiteURLAdmin);
            this.adminTab.Location = new System.Drawing.Point(4, 27);
            this.adminTab.Name = "adminTab";
            this.adminTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminTab.Size = new System.Drawing.Size(585, 294);
            this.adminTab.TabIndex = 1;
            this.adminTab.Text = "Find Admin Page";
            this.adminTab.Click += new System.EventHandler(this.adminTab_Click);
            // 
            // maybeAdminURLListBox
            // 
            this.maybeAdminURLListBox.FormattingEnabled = true;
            this.maybeAdminURLListBox.ItemHeight = 18;
            this.maybeAdminURLListBox.Location = new System.Drawing.Point(243, 53);
            this.maybeAdminURLListBox.Name = "maybeAdminURLListBox";
            this.maybeAdminURLListBox.Size = new System.Drawing.Size(336, 202);
            this.maybeAdminURLListBox.TabIndex = 38;
            this.maybeAdminURLListBox.Click += new System.EventHandler(this.maybeAdminURLListBox_Click);
            this.maybeAdminURLListBox.DoubleClick += new System.EventHandler(this.maybeAdminURLListBox_DoubleClick);
            // 
            // adminURLListBox
            // 
            this.adminURLListBox.FormattingEnabled = true;
            this.adminURLListBox.ItemHeight = 18;
            this.adminURLListBox.Items.AddRange(new object[] {
            "URLS"});
            this.adminURLListBox.Location = new System.Drawing.Point(10, 35);
            this.adminURLListBox.Name = "adminURLListBox";
            this.adminURLListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.adminURLListBox.Size = new System.Drawing.Size(227, 220);
            this.adminURLListBox.TabIndex = 37;
            // 
            // possibleAdminlabel
            // 
            this.possibleAdminlabel.AutoSize = true;
            this.possibleAdminlabel.Depth = 0;
            this.possibleAdminlabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.possibleAdminlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.possibleAdminlabel.Location = new System.Drawing.Point(334, 31);
            this.possibleAdminlabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.possibleAdminlabel.Name = "possibleAdminlabel";
            this.possibleAdminlabel.Size = new System.Drawing.Size(154, 19);
            this.possibleAdminlabel.TabIndex = 36;
            this.possibleAdminlabel.Text = "Possible Admin URLS";
            // 
            // findAdminButton
            // 
            this.findAdminButton.BackColor = System.Drawing.Color.Black;
            this.findAdminButton.Depth = 0;
            this.findAdminButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.findAdminButton.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findAdminButton.Location = new System.Drawing.Point(446, 6);
            this.findAdminButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.findAdminButton.Name = "findAdminButton";
            this.findAdminButton.Primary = true;
            this.findAdminButton.Size = new System.Drawing.Size(133, 23);
            this.findAdminButton.TabIndex = 35;
            this.findAdminButton.Text = "Find Admin Page";
            this.findAdminButton.UseVisualStyleBackColor = false;
            this.findAdminButton.Click += new System.EventHandler(this.findAdminButton_Click);
            // 
            // websiteURLAdmin
            // 
            this.websiteURLAdmin.Depth = 0;
            this.websiteURLAdmin.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.websiteURLAdmin.Hint = "";
            this.websiteURLAdmin.Location = new System.Drawing.Point(6, 6);
            this.websiteURLAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.websiteURLAdmin.Name = "websiteURLAdmin";
            this.websiteURLAdmin.PasswordChar = '\0';
            this.websiteURLAdmin.SelectedText = "";
            this.websiteURLAdmin.SelectionLength = 0;
            this.websiteURLAdmin.SelectionStart = 0;
            this.websiteURLAdmin.Size = new System.Drawing.Size(434, 23);
            this.websiteURLAdmin.TabIndex = 34;
            this.websiteURLAdmin.Text = "Base website URL";
            this.websiteURLAdmin.UseSystemPasswordChar = false;
            this.websiteURLAdmin.Click += new System.EventHandler(this.websiteURLAdmin_Click);
            this.websiteURLAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.websiteURLAdmin_KeyPress);
            // 
            // toolsTab
            // 
            this.toolsTab.BackColor = System.Drawing.Color.White;
            this.toolsTab.Controls.Add(this.copyHashButton);
            this.toolsTab.Controls.Add(this.decodeHashStatus);
            this.toolsTab.Controls.Add(this.decodeHashButton);
            this.toolsTab.Controls.Add(this.decodeHashText);
            this.toolsTab.Location = new System.Drawing.Point(4, 27);
            this.toolsTab.Name = "toolsTab";
            this.toolsTab.Size = new System.Drawing.Size(585, 294);
            this.toolsTab.TabIndex = 2;
            this.toolsTab.Text = "Other Tools";
            // 
            // copyHashButton
            // 
            this.copyHashButton.AutoSize = true;
            this.copyHashButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.copyHashButton.Depth = 0;
            this.copyHashButton.Location = new System.Drawing.Point(14, 50);
            this.copyHashButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.copyHashButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.copyHashButton.Name = "copyHashButton";
            this.copyHashButton.Primary = false;
            this.copyHashButton.Size = new System.Drawing.Size(48, 36);
            this.copyHashButton.TabIndex = 38;
            this.copyHashButton.Text = "Copy";
            this.copyHashButton.UseVisualStyleBackColor = true;
            this.copyHashButton.Click += new System.EventHandler(this.copyHashButton_click);
            // 
            // decodeHashStatus
            // 
            this.decodeHashStatus.AutoSize = true;
            this.decodeHashStatus.Depth = 0;
            this.decodeHashStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.decodeHashStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.decodeHashStatus.Location = new System.Drawing.Point(69, 59);
            this.decodeHashStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.decodeHashStatus.Name = "decodeHashStatus";
            this.decodeHashStatus.Size = new System.Drawing.Size(90, 19);
            this.decodeHashStatus.TabIndex = 37;
            this.decodeHashStatus.Text = "Hash status";
            // 
            // decodeHashButton
            // 
            this.decodeHashButton.Depth = 0;
            this.decodeHashButton.Location = new System.Drawing.Point(441, 20);
            this.decodeHashButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.decodeHashButton.Name = "decodeHashButton";
            this.decodeHashButton.Primary = true;
            this.decodeHashButton.Size = new System.Drawing.Size(129, 23);
            this.decodeHashButton.TabIndex = 36;
            this.decodeHashButton.Text = "Decode Hash";
            this.decodeHashButton.UseVisualStyleBackColor = true;
            this.decodeHashButton.Click += new System.EventHandler(this.decodeHashButton_Click);
            // 
            // decodeHashText
            // 
            this.decodeHashText.Depth = 0;
            this.decodeHashText.Hint = "5f4dcc3b5aa765d61d8327deb882cf99";
            this.decodeHashText.Location = new System.Drawing.Point(14, 20);
            this.decodeHashText.MouseState = MaterialSkin.MouseState.HOVER;
            this.decodeHashText.Name = "decodeHashText";
            this.decodeHashText.PasswordChar = '\0';
            this.decodeHashText.SelectedText = "";
            this.decodeHashText.SelectionLength = 0;
            this.decodeHashText.SelectionStart = 0;
            this.decodeHashText.Size = new System.Drawing.Size(421, 23);
            this.decodeHashText.TabIndex = 35;
            this.decodeHashText.UseSystemPasswordChar = false;
            // 
            // findAdminPageWorker
            // 
            this.findAdminPageWorker.WorkerReportsProgress = true;
            this.findAdminPageWorker.WorkerSupportsCancellation = true;
            this.findAdminPageWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.findAdminPageWorker_DoWork);
            this.findAdminPageWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.findAdminPageWorker_ProgressChanged);
            this.findAdminPageWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.findAdminPageWorker_RunWorkerCompleted);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.darkCheckBox);
            this.settingsGroupBox.Controls.Add(this.lightCheckBox);
            this.settingsGroupBox.Controls.Add(this.themeColorLabel);
            this.settingsGroupBox.Controls.Add(this.accentColorComboBox);
            this.settingsGroupBox.Controls.Add(this.accentColorLabel);
            this.settingsGroupBox.Controls.Add(this.primaryColorComboBox);
            this.settingsGroupBox.Controls.Add(this.primaryColorLabel);
            this.settingsGroupBox.Controls.Add(this.textShadeBlackButton);
            this.settingsGroupBox.Controls.Add(this.textShadeWhiteButton);
            this.settingsGroupBox.Controls.Add(this.textShadeLabel);
            this.settingsGroupBox.Controls.Add(this.proxyPassword);
            this.settingsGroupBox.Controls.Add(this.proxyUsername);
            this.settingsGroupBox.Controls.Add(this.proxyPort);
            this.settingsGroupBox.Controls.Add(this.proxyIP);
            this.settingsGroupBox.Controls.Add(this.proxyPasswordLabel);
            this.settingsGroupBox.Controls.Add(this.proxyUsernameLabel);
            this.settingsGroupBox.Controls.Add(this.proxyPortLabel);
            this.settingsGroupBox.Controls.Add(this.proxyIPLabel);
            this.settingsGroupBox.Controls.Add(this.proxySettingsLabel);
            this.settingsGroupBox.Controls.Add(this.saveSettings);
            this.settingsGroupBox.Controls.Add(this.internetTimeoutText);
            this.settingsGroupBox.Controls.Add(this.adminPageTimeoutLabel);
            this.settingsGroupBox.Location = new System.Drawing.Point(625, 70);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(228, 490);
            this.settingsGroupBox.TabIndex = 34;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            this.settingsGroupBox.Visible = false;
            // 
            // darkCheckBox
            // 
            this.darkCheckBox.AutoSize = true;
            this.darkCheckBox.Depth = 0;
            this.darkCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.darkCheckBox.Location = new System.Drawing.Point(116, 275);
            this.darkCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.darkCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.darkCheckBox.Name = "darkCheckBox";
            this.darkCheckBox.Ripple = true;
            this.darkCheckBox.Size = new System.Drawing.Size(58, 30);
            this.darkCheckBox.TabIndex = 21;
            this.darkCheckBox.Text = "Dark";
            this.darkCheckBox.UseVisualStyleBackColor = true;
            this.darkCheckBox.Click += new System.EventHandler(this.darkCheckBox_Click);
            // 
            // lightCheckBox
            // 
            this.lightCheckBox.AutoSize = true;
            this.lightCheckBox.Depth = 0;
            this.lightCheckBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.lightCheckBox.Location = new System.Drawing.Point(55, 275);
            this.lightCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.lightCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lightCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.lightCheckBox.Name = "lightCheckBox";
            this.lightCheckBox.Ripple = true;
            this.lightCheckBox.Size = new System.Drawing.Size(61, 30);
            this.lightCheckBox.TabIndex = 20;
            this.lightCheckBox.Text = "Light";
            this.lightCheckBox.UseVisualStyleBackColor = true;
            this.lightCheckBox.Click += new System.EventHandler(this.lightCheckBox_Click);
            // 
            // themeColorLabel
            // 
            this.themeColorLabel.AutoSize = true;
            this.themeColorLabel.Depth = 0;
            this.themeColorLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.themeColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.themeColorLabel.Location = new System.Drawing.Point(66, 256);
            this.themeColorLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.themeColorLabel.Name = "themeColorLabel";
            this.themeColorLabel.Size = new System.Drawing.Size(96, 19);
            this.themeColorLabel.TabIndex = 19;
            this.themeColorLabel.Text = "Theme Color";
            // 
            // accentColorComboBox
            // 
            this.accentColorComboBox.FormattingEnabled = true;
            this.accentColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Pink",
            "Purple",
            "DeepPurple",
            "Indigo",
            "Blue",
            "LightBlue",
            "Cyan",
            "Teal",
            "Green",
            "LightGreen",
            "Lime",
            "Yellow",
            "Amber",
            "Orange",
            "DeepOrange"});
            this.accentColorComboBox.Location = new System.Drawing.Point(54, 424);
            this.accentColorComboBox.Name = "accentColorComboBox";
            this.accentColorComboBox.Size = new System.Drawing.Size(121, 26);
            this.accentColorComboBox.TabIndex = 18;
            this.accentColorComboBox.TextChanged += new System.EventHandler(this.accentColorComboBox_TextChanged);
            // 
            // accentColorLabel
            // 
            this.accentColorLabel.AutoSize = true;
            this.accentColorLabel.Depth = 0;
            this.accentColorLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.accentColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.accentColorLabel.Location = new System.Drawing.Point(66, 405);
            this.accentColorLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.accentColorLabel.Name = "accentColorLabel";
            this.accentColorLabel.Size = new System.Drawing.Size(97, 19);
            this.accentColorLabel.TabIndex = 17;
            this.accentColorLabel.Text = "Accent Color";
            // 
            // primaryColorComboBox
            // 
            this.primaryColorComboBox.FormattingEnabled = true;
            this.primaryColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Pink",
            "Purple",
            "DeepPurple",
            "Indigo",
            "Blue",
            "LightBlue",
            "Cyan",
            "Teal",
            "Green",
            "LightGreen",
            "Lime",
            "Yellow",
            "Amber",
            "Orange",
            "DeepOrange",
            "Brown",
            "Grey",
            "BlueGrey"});
            this.primaryColorComboBox.Location = new System.Drawing.Point(54, 376);
            this.primaryColorComboBox.Name = "primaryColorComboBox";
            this.primaryColorComboBox.Size = new System.Drawing.Size(121, 26);
            this.primaryColorComboBox.TabIndex = 16;
            this.primaryColorComboBox.TextChanged += new System.EventHandler(this.primaryColorComboBox_TextChanged);
            // 
            // primaryColorLabel
            // 
            this.primaryColorLabel.AutoSize = true;
            this.primaryColorLabel.Depth = 0;
            this.primaryColorLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.primaryColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.primaryColorLabel.Location = new System.Drawing.Point(64, 354);
            this.primaryColorLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.primaryColorLabel.Name = "primaryColorLabel";
            this.primaryColorLabel.Size = new System.Drawing.Size(101, 19);
            this.primaryColorLabel.TabIndex = 15;
            this.primaryColorLabel.Text = "Primary Color";
            // 
            // textShadeBlackButton
            // 
            this.textShadeBlackButton.AutoSize = true;
            this.textShadeBlackButton.Depth = 0;
            this.textShadeBlackButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.textShadeBlackButton.Location = new System.Drawing.Point(115, 324);
            this.textShadeBlackButton.Margin = new System.Windows.Forms.Padding(0);
            this.textShadeBlackButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.textShadeBlackButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.textShadeBlackButton.Name = "textShadeBlackButton";
            this.textShadeBlackButton.Ripple = true;
            this.textShadeBlackButton.Size = new System.Drawing.Size(63, 30);
            this.textShadeBlackButton.TabIndex = 14;
            this.textShadeBlackButton.TabStop = true;
            this.textShadeBlackButton.Text = "Black";
            this.textShadeBlackButton.UseVisualStyleBackColor = true;
            this.textShadeBlackButton.Click += new System.EventHandler(this.textShadeBlackButton_Click);
            // 
            // textShadeWhiteButton
            // 
            this.textShadeWhiteButton.AutoSize = true;
            this.textShadeWhiteButton.Depth = 0;
            this.textShadeWhiteButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.textShadeWhiteButton.Location = new System.Drawing.Point(51, 324);
            this.textShadeWhiteButton.Margin = new System.Windows.Forms.Padding(0);
            this.textShadeWhiteButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.textShadeWhiteButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.textShadeWhiteButton.Name = "textShadeWhiteButton";
            this.textShadeWhiteButton.Ripple = true;
            this.textShadeWhiteButton.Size = new System.Drawing.Size(64, 30);
            this.textShadeWhiteButton.TabIndex = 13;
            this.textShadeWhiteButton.TabStop = true;
            this.textShadeWhiteButton.Text = "White";
            this.textShadeWhiteButton.UseVisualStyleBackColor = true;
            this.textShadeWhiteButton.Click += new System.EventHandler(this.textShadeWhiteButton_Click);
            // 
            // textShadeLabel
            // 
            this.textShadeLabel.AutoSize = true;
            this.textShadeLabel.Depth = 0;
            this.textShadeLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.textShadeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textShadeLabel.Location = new System.Drawing.Point(73, 305);
            this.textShadeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.textShadeLabel.Name = "textShadeLabel";
            this.textShadeLabel.Size = new System.Drawing.Size(83, 19);
            this.textShadeLabel.TabIndex = 12;
            this.textShadeLabel.Text = "Text Shade";
            // 
            // proxyPassword
            // 
            this.proxyPassword.Depth = 0;
            this.proxyPassword.Hint = "";
            this.proxyPassword.Location = new System.Drawing.Point(92, 148);
            this.proxyPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyPassword.Name = "proxyPassword";
            this.proxyPassword.PasswordChar = '\0';
            this.proxyPassword.SelectedText = "";
            this.proxyPassword.SelectionLength = 0;
            this.proxyPassword.SelectionStart = 0;
            this.proxyPassword.Size = new System.Drawing.Size(116, 23);
            this.proxyPassword.TabIndex = 11;
            this.proxyPassword.UseSystemPasswordChar = true;
            // 
            // proxyUsername
            // 
            this.proxyUsername.Depth = 0;
            this.proxyUsername.Hint = "";
            this.proxyUsername.Location = new System.Drawing.Point(92, 119);
            this.proxyUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyUsername.Name = "proxyUsername";
            this.proxyUsername.PasswordChar = '\0';
            this.proxyUsername.SelectedText = "";
            this.proxyUsername.SelectionLength = 0;
            this.proxyUsername.SelectionStart = 0;
            this.proxyUsername.Size = new System.Drawing.Size(116, 23);
            this.proxyUsername.TabIndex = 10;
            this.proxyUsername.UseSystemPasswordChar = false;
            // 
            // proxyPort
            // 
            this.proxyPort.Depth = 0;
            this.proxyPort.Hint = "";
            this.proxyPort.Location = new System.Drawing.Point(92, 90);
            this.proxyPort.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyPort.Name = "proxyPort";
            this.proxyPort.PasswordChar = '\0';
            this.proxyPort.SelectedText = "";
            this.proxyPort.SelectionLength = 0;
            this.proxyPort.SelectionStart = 0;
            this.proxyPort.Size = new System.Drawing.Size(116, 23);
            this.proxyPort.TabIndex = 9;
            this.proxyPort.UseSystemPasswordChar = false;
            // 
            // proxyIP
            // 
            this.proxyIP.Depth = 0;
            this.proxyIP.Hint = "";
            this.proxyIP.Location = new System.Drawing.Point(92, 61);
            this.proxyIP.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyIP.Name = "proxyIP";
            this.proxyIP.PasswordChar = '\0';
            this.proxyIP.SelectedText = "";
            this.proxyIP.SelectionLength = 0;
            this.proxyIP.SelectionStart = 0;
            this.proxyIP.Size = new System.Drawing.Size(116, 23);
            this.proxyIP.TabIndex = 8;
            this.proxyIP.UseSystemPasswordChar = false;
            // 
            // proxyPasswordLabel
            // 
            this.proxyPasswordLabel.AutoSize = true;
            this.proxyPasswordLabel.Depth = 0;
            this.proxyPasswordLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.proxyPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.proxyPasswordLabel.Location = new System.Drawing.Point(8, 150);
            this.proxyPasswordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyPasswordLabel.Name = "proxyPasswordLabel";
            this.proxyPasswordLabel.Size = new System.Drawing.Size(79, 19);
            this.proxyPasswordLabel.TabIndex = 7;
            this.proxyPasswordLabel.Text = "Password:";
            // 
            // proxyUsernameLabel
            // 
            this.proxyUsernameLabel.AutoSize = true;
            this.proxyUsernameLabel.Depth = 0;
            this.proxyUsernameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.proxyUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.proxyUsernameLabel.Location = new System.Drawing.Point(6, 121);
            this.proxyUsernameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyUsernameLabel.Name = "proxyUsernameLabel";
            this.proxyUsernameLabel.Size = new System.Drawing.Size(81, 19);
            this.proxyUsernameLabel.TabIndex = 6;
            this.proxyUsernameLabel.Text = "Username:";
            // 
            // proxyPortLabel
            // 
            this.proxyPortLabel.AutoSize = true;
            this.proxyPortLabel.Depth = 0;
            this.proxyPortLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.proxyPortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.proxyPortLabel.Location = new System.Drawing.Point(46, 92);
            this.proxyPortLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyPortLabel.Name = "proxyPortLabel";
            this.proxyPortLabel.Size = new System.Drawing.Size(41, 19);
            this.proxyPortLabel.TabIndex = 5;
            this.proxyPortLabel.Text = "Port:";
            // 
            // proxyIPLabel
            // 
            this.proxyIPLabel.AutoSize = true;
            this.proxyIPLabel.Depth = 0;
            this.proxyIPLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.proxyIPLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.proxyIPLabel.Location = new System.Drawing.Point(61, 63);
            this.proxyIPLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxyIPLabel.Name = "proxyIPLabel";
            this.proxyIPLabel.Size = new System.Drawing.Size(26, 19);
            this.proxyIPLabel.TabIndex = 4;
            this.proxyIPLabel.Text = "IP:";
            // 
            // proxySettingsLabel
            // 
            this.proxySettingsLabel.AutoSize = true;
            this.proxySettingsLabel.Depth = 0;
            this.proxySettingsLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.proxySettingsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.proxySettingsLabel.Location = new System.Drawing.Point(62, 35);
            this.proxySettingsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.proxySettingsLabel.Name = "proxySettingsLabel";
            this.proxySettingsLabel.Size = new System.Drawing.Size(105, 19);
            this.proxySettingsLabel.TabIndex = 3;
            this.proxySettingsLabel.Text = "Proxy Settings";
            // 
            // saveSettings
            // 
            this.saveSettings.Depth = 0;
            this.saveSettings.Location = new System.Drawing.Point(6, 456);
            this.saveSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Primary = true;
            this.saveSettings.Size = new System.Drawing.Size(216, 23);
            this.saveSettings.TabIndex = 2;
            this.saveSettings.Text = "Save Settings";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // internetTimeoutText
            // 
            this.internetTimeoutText.Depth = 0;
            this.internetTimeoutText.Hint = "";
            this.internetTimeoutText.Location = new System.Drawing.Point(16, 217);
            this.internetTimeoutText.MouseState = MaterialSkin.MouseState.HOVER;
            this.internetTimeoutText.Name = "internetTimeoutText";
            this.internetTimeoutText.PasswordChar = '\0';
            this.internetTimeoutText.SelectedText = "";
            this.internetTimeoutText.SelectionLength = 0;
            this.internetTimeoutText.SelectionStart = 0;
            this.internetTimeoutText.Size = new System.Drawing.Size(192, 23);
            this.internetTimeoutText.TabIndex = 1;
            this.internetTimeoutText.Text = "5000";
            this.internetTimeoutText.UseSystemPasswordChar = false;
            this.internetTimeoutText.Leave += new System.EventHandler(this.internetTimeoutText_Leave);
            // 
            // adminPageTimeoutLabel
            // 
            this.adminPageTimeoutLabel.AutoSize = true;
            this.adminPageTimeoutLabel.Depth = 0;
            this.adminPageTimeoutLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.adminPageTimeoutLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.adminPageTimeoutLabel.Location = new System.Drawing.Point(4, 191);
            this.adminPageTimeoutLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.adminPageTimeoutLabel.Name = "adminPageTimeoutLabel";
            this.adminPageTimeoutLabel.Size = new System.Drawing.Size(220, 19);
            this.adminPageTimeoutLabel.TabIndex = 0;
            this.adminPageTimeoutLabel.Text = "Internet Timeout (Milliseconds)";
            // 
            // statusInfo
            // 
            this.statusInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusInfo.Depth = 0;
            this.statusInfo.Font = new System.Drawing.Font("Roboto", 11F);
            this.statusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusInfo.Location = new System.Drawing.Point(12, 515);
            this.statusInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(484, 45);
            this.statusInfo.TabIndex = 31;
            this.statusInfo.Text = "Status";
            this.statusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusInfo.Click += new System.EventHandler(this.statusInfo_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Depth = 0;
            this.settingsButton.Location = new System.Drawing.Point(502, 515);
            this.settingsButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Primary = true;
            this.settingsButton.Size = new System.Drawing.Size(103, 45);
            this.settingsButton.TabIndex = 33;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click_1);
            // 
            // checkUpdates
            // 
            this.checkUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkUpdates_DoWork);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // databaseGridViewMenuStrip
            // 
            this.databaseGridViewMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.databaseGridViewMenuStrip.Depth = 0;
            this.databaseGridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.databaseGridViewMenuStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.databaseGridViewMenuStrip.Name = "databaseGridViewMenuStrip";
            this.databaseGridViewMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // decodeHashWorker
            // 
            this.decodeHashWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.decodeHashWorker_DoWork);
            this.decodeHashWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.decodeHashWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 599);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.tabView);
            this.Controls.Add(this.statusInfo);
            this.Controls.Add(this.usernamesLabel);
            this.Controls.Add(this.versionNumberLabel);
            this.Controls.Add(this.columnsLabel);
            this.Controls.Add(this.vulnerableColumnsLabel);
            this.Controls.Add(this.vulnerableLabel);
            this.Controls.Add(this.usernameStatus);
            this.Controls.Add(this.versionNumberStatus);
            this.Controls.Add(this.columnsStatus);
            this.Controls.Add(this.vulnerableColumnsStatus);
            this.Controls.Add(this.vulnerableStatus);
            this.Controls.Add(this.scanWebsite);
            this.Controls.Add(this.websiteURL);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "DGWebScanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabView.ResumeLayout(false);
            this.databaseTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.databaseGridView)).EndInit();
            this.adminTab.ResumeLayout(false);
            this.adminTab.PerformLayout();
            this.toolsTab.ResumeLayout(false);
            this.toolsTab.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.databaseGridViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker getVulnerableInfo;
        private MaterialSkin.Controls.MaterialSingleLineTextField websiteURL;
        private MaterialSkin.Controls.MaterialRaisedButton scanWebsite;
        private MaterialSkin.Controls.MaterialLabel vulnerableLabel;
        private MaterialSkin.Controls.MaterialLabel vulnerableColumnsLabel;
        private MaterialSkin.Controls.MaterialLabel columnsLabel;
        private MaterialSkin.Controls.MaterialLabel versionNumberLabel;
        private MaterialSkin.Controls.MaterialLabel usernamesLabel;
        private MaterialSkin.Controls.MaterialLabel usernameStatus;
        private MaterialSkin.Controls.MaterialLabel versionNumberStatus;
        private MaterialSkin.Controls.MaterialLabel columnsStatus;
        private MaterialSkin.Controls.MaterialLabel vulnerableColumnsStatus;
        private MaterialSkin.Controls.MaterialLabel vulnerableStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TreeView databaseInfoTreeView;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage databaseTab;
        private System.Windows.Forms.TabPage adminTab;
        private System.Windows.Forms.TabPage toolsTab;
        private System.Windows.Forms.DataGridView databaseGridView;
        private MaterialSkin.Controls.MaterialRaisedButton findAdminButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField websiteURLAdmin;
        private System.ComponentModel.BackgroundWorker findAdminPageWorker;
        private System.Windows.Forms.ListBox adminURLListBox;
        private MaterialSkin.Controls.MaterialLabel possibleAdminlabel;
        private System.Windows.Forms.ListBox maybeAdminURLListBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private MaterialSkin.Controls.MaterialLabel adminPageTimeoutLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField internetTimeoutText;
        private MaterialSkin.Controls.MaterialLabel statusInfo;
        private MaterialSkin.Controls.MaterialRaisedButton settingsButton;
        private MaterialSkin.Controls.MaterialRaisedButton saveSettings;
        private System.ComponentModel.BackgroundWorker checkUpdates;
        private MaterialSkin.Controls.MaterialLabel proxySettingsLabel;
        private MaterialSkin.Controls.MaterialLabel proxyPasswordLabel;
        private MaterialSkin.Controls.MaterialLabel proxyUsernameLabel;
        private MaterialSkin.Controls.MaterialLabel proxyPortLabel;
        private MaterialSkin.Controls.MaterialLabel proxyIPLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField proxyPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField proxyUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField proxyPort;
        private MaterialSkin.Controls.MaterialSingleLineTextField proxyIP;
        private System.Windows.Forms.ToolTip toolTip1;
        private MaterialSkin.Controls.MaterialContextMenuStrip databaseGridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MaterialSkin.Controls.MaterialLabel textShadeLabel;
        private MaterialSkin.Controls.MaterialRadioButton textShadeBlackButton;
        private MaterialSkin.Controls.MaterialRadioButton textShadeWhiteButton;
        private MaterialSkin.Controls.MaterialLabel primaryColorLabel;
        private System.Windows.Forms.ComboBox primaryColorComboBox;
        private System.Windows.Forms.ComboBox accentColorComboBox;
        private MaterialSkin.Controls.MaterialLabel accentColorLabel;
        private MaterialSkin.Controls.MaterialLabel themeColorLabel;
        private MaterialSkin.Controls.MaterialCheckBox darkCheckBox;
        private MaterialSkin.Controls.MaterialCheckBox lightCheckBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField decodeHashText;
        private MaterialSkin.Controls.MaterialRaisedButton decodeHashButton;
        private MaterialSkin.Controls.MaterialLabel decodeHashStatus;
        private MaterialSkin.Controls.MaterialFlatButton copyHashButton;
        private System.ComponentModel.BackgroundWorker decodeHashWorker;
    }
}

