namespace StereoImaging
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbVideoSourceRight = new System.Windows.Forms.PictureBox();
            this.pbVideoSourceLeft = new System.Windows.Forms.PictureBox();
            this.pbDisparityMap = new System.Windows.Forms.PictureBox();
            this.pnlParametters = new System.Windows.Forms.Panel();
            this.lblFullDPState = new System.Windows.Forms.Label();
            this.btnFullDPState = new System.Windows.Forms.Button();
            this.trbSpeckleRange = new System.Windows.Forms.TrackBar();
            this.lblSpeckleRange = new System.Windows.Forms.Label();
            this.trbUniquenessRatio = new System.Windows.Forms.TrackBar();
            this.lblUniquenessRatio = new System.Windows.Forms.Label();
            this.trbPreFilterCap = new System.Windows.Forms.TrackBar();
            this.lblPreFilterCap = new System.Windows.Forms.Label();
            this.trbSpeckleWindow = new System.Windows.Forms.TrackBar();
            this.lblSpeckleWindow = new System.Windows.Forms.Label();
            this.trbSADWindow = new System.Windows.Forms.TrackBar();
            this.lblSADWindow = new System.Windows.Forms.Label();
            this.lblDisp12MaxDiff = new System.Windows.Forms.Label();
            this.trbDisp12MaxDiff = new System.Windows.Forms.TrackBar();
            this.trbDisparities = new System.Windows.Forms.TrackBar();
            this.lblDisparities = new System.Windows.Forms.Label();
            this.lblMinDisparities = new System.Windows.Forms.Label();
            this.lblCalibration = new System.Windows.Forms.Label();
            this.trbMinDisparities = new System.Windows.Forms.TrackBar();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mItCaptureDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mItLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mItRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mItCalibration = new System.Windows.Forms.ToolStripMenuItem();
            this.mItCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.mItSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItRealD3D = new System.Windows.Forms.ToolStripMenuItem();
            this.mItAnaglyph = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItDisparityMap = new System.Windows.Forms.ToolStripMenuItem();
            this.gimbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mItHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mItKeyCombination = new System.Windows.Forms.ToolStripMenuItem();
            this.mItAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblIsConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisparityMap)).BeginInit();
            this.pnlParametters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUniquenessRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPreFilterCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSADWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisp12MaxDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinDisparities)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pbVideoSourceRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbVideoSourceLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbDisparityMap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlParametters, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbVideoSourceRight
            // 
            this.pbVideoSourceRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVideoSourceRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideoSourceRight.Location = new System.Drawing.Point(361, 3);
            this.pbVideoSourceRight.Name = "pbVideoSourceRight";
            this.pbVideoSourceRight.Size = new System.Drawing.Size(352, 259);
            this.pbVideoSourceRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVideoSourceRight.TabIndex = 1;
            this.pbVideoSourceRight.TabStop = false;
            this.pbVideoSourceRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pbVideoSourceRight_Paint);
            // 
            // pbVideoSourceLeft
            // 
            this.pbVideoSourceLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVideoSourceLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVideoSourceLeft.Location = new System.Drawing.Point(3, 3);
            this.pbVideoSourceLeft.Name = "pbVideoSourceLeft";
            this.pbVideoSourceLeft.Size = new System.Drawing.Size(352, 259);
            this.pbVideoSourceLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVideoSourceLeft.TabIndex = 0;
            this.pbVideoSourceLeft.TabStop = false;
            this.pbVideoSourceLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pbVideoSourceLeft_Paint);
            // 
            // pbDisparityMap
            // 
            this.pbDisparityMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDisparityMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDisparityMap.Location = new System.Drawing.Point(361, 268);
            this.pbDisparityMap.Name = "pbDisparityMap";
            this.pbDisparityMap.Size = new System.Drawing.Size(352, 260);
            this.pbDisparityMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDisparityMap.TabIndex = 2;
            this.pbDisparityMap.TabStop = false;
            // 
            // pnlParametters
            // 
            this.pnlParametters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParametters.AutoScroll = true;
            this.pnlParametters.Controls.Add(this.lblFullDPState);
            this.pnlParametters.Controls.Add(this.btnFullDPState);
            this.pnlParametters.Controls.Add(this.trbSpeckleRange);
            this.pnlParametters.Controls.Add(this.lblSpeckleRange);
            this.pnlParametters.Controls.Add(this.trbUniquenessRatio);
            this.pnlParametters.Controls.Add(this.lblUniquenessRatio);
            this.pnlParametters.Controls.Add(this.trbPreFilterCap);
            this.pnlParametters.Controls.Add(this.lblPreFilterCap);
            this.pnlParametters.Controls.Add(this.trbSpeckleWindow);
            this.pnlParametters.Controls.Add(this.lblSpeckleWindow);
            this.pnlParametters.Controls.Add(this.trbSADWindow);
            this.pnlParametters.Controls.Add(this.lblSADWindow);
            this.pnlParametters.Controls.Add(this.lblDisp12MaxDiff);
            this.pnlParametters.Controls.Add(this.trbDisp12MaxDiff);
            this.pnlParametters.Controls.Add(this.trbDisparities);
            this.pnlParametters.Controls.Add(this.lblDisparities);
            this.pnlParametters.Controls.Add(this.lblMinDisparities);
            this.pnlParametters.Controls.Add(this.lblCalibration);
            this.pnlParametters.Controls.Add(this.trbMinDisparities);
            this.pnlParametters.Location = new System.Drawing.Point(3, 268);
            this.pnlParametters.Name = "pnlParametters";
            this.pnlParametters.Size = new System.Drawing.Size(352, 260);
            this.pnlParametters.TabIndex = 3;
            // 
            // lblFullDPState
            // 
            this.lblFullDPState.AutoSize = true;
            this.lblFullDPState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullDPState.Location = new System.Drawing.Point(72, 466);
            this.lblFullDPState.Name = "lblFullDPState";
            this.lblFullDPState.Size = new System.Drawing.Size(58, 16);
            this.lblFullDPState.TabIndex = 21;
            this.lblFullDPState.Text = "FullDP:";
            // 
            // btnFullDPState
            // 
            this.btnFullDPState.Location = new System.Drawing.Point(136, 459);
            this.btnFullDPState.Name = "btnFullDPState";
            this.btnFullDPState.Size = new System.Drawing.Size(313, 30);
            this.btnFullDPState.TabIndex = 20;
            this.btnFullDPState.Text = "False";
            this.btnFullDPState.UseVisualStyleBackColor = true;
            this.btnFullDPState.Click += new System.EventHandler(this.btnFullDPState_Click);
            // 
            // trbSpeckleRange
            // 
            this.trbSpeckleRange.Location = new System.Drawing.Point(136, 415);
            this.trbSpeckleRange.Maximum = 160;
            this.trbSpeckleRange.Name = "trbSpeckleRange";
            this.trbSpeckleRange.Size = new System.Drawing.Size(313, 45);
            this.trbSpeckleRange.TabIndex = 19;
            this.trbSpeckleRange.TickFrequency = 16;
            this.trbSpeckleRange.Scroll += new System.EventHandler(this.trbSpeckleRange_Scroll);
            // 
            // lblSpeckleRange
            // 
            this.lblSpeckleRange.AutoSize = true;
            this.lblSpeckleRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeckleRange.Location = new System.Drawing.Point(11, 415);
            this.lblSpeckleRange.Name = "lblSpeckleRange";
            this.lblSpeckleRange.Size = new System.Drawing.Size(119, 16);
            this.lblSpeckleRange.TabIndex = 18;
            this.lblSpeckleRange.Text = "Speckle Range:";
            // 
            // trbUniquenessRatio
            // 
            this.trbUniquenessRatio.Location = new System.Drawing.Point(136, 316);
            this.trbUniquenessRatio.Maximum = 30;
            this.trbUniquenessRatio.Name = "trbUniquenessRatio";
            this.trbUniquenessRatio.Size = new System.Drawing.Size(313, 45);
            this.trbUniquenessRatio.TabIndex = 17;
            this.trbUniquenessRatio.TickFrequency = 2;
            // 
            // lblUniquenessRatio
            // 
            this.lblUniquenessRatio.AutoSize = true;
            this.lblUniquenessRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUniquenessRatio.Location = new System.Drawing.Point(43, 316);
            this.lblUniquenessRatio.Name = "lblUniquenessRatio";
            this.lblUniquenessRatio.Size = new System.Drawing.Size(94, 16);
            this.lblUniquenessRatio.TabIndex = 16;
            this.lblUniquenessRatio.Text = "Uniqueness:";
            // 
            // trbPreFilterCap
            // 
            this.trbPreFilterCap.Location = new System.Drawing.Point(136, 265);
            this.trbPreFilterCap.Maximum = 1000;
            this.trbPreFilterCap.Name = "trbPreFilterCap";
            this.trbPreFilterCap.Size = new System.Drawing.Size(313, 45);
            this.trbPreFilterCap.TabIndex = 15;
            this.trbPreFilterCap.TickFrequency = 100;
            // 
            // lblPreFilterCap
            // 
            this.lblPreFilterCap.AutoSize = true;
            this.lblPreFilterCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreFilterCap.Location = new System.Drawing.Point(55, 265);
            this.lblPreFilterCap.Name = "lblPreFilterCap";
            this.lblPreFilterCap.Size = new System.Drawing.Size(75, 16);
            this.lblPreFilterCap.TabIndex = 14;
            this.lblPreFilterCap.Text = "Pre Filter:";
            // 
            // trbSpeckleWindow
            // 
            this.trbSpeckleWindow.Location = new System.Drawing.Point(136, 364);
            this.trbSpeckleWindow.Maximum = 64;
            this.trbSpeckleWindow.Name = "trbSpeckleWindow";
            this.trbSpeckleWindow.Size = new System.Drawing.Size(313, 45);
            this.trbSpeckleWindow.TabIndex = 13;
            this.trbSpeckleWindow.TickFrequency = 8;
            // 
            // lblSpeckleWindow
            // 
            this.lblSpeckleWindow.AutoSize = true;
            this.lblSpeckleWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeckleWindow.Location = new System.Drawing.Point(3, 364);
            this.lblSpeckleWindow.Name = "lblSpeckleWindow";
            this.lblSpeckleWindow.Size = new System.Drawing.Size(127, 16);
            this.lblSpeckleWindow.TabIndex = 12;
            this.lblSpeckleWindow.Text = "Speckle Window:";
            // 
            // trbSADWindow
            // 
            this.trbSADWindow.Location = new System.Drawing.Point(136, 163);
            this.trbSADWindow.Maximum = 19;
            this.trbSADWindow.Minimum = 1;
            this.trbSADWindow.Name = "trbSADWindow";
            this.trbSADWindow.Size = new System.Drawing.Size(313, 45);
            this.trbSADWindow.SmallChange = 2;
            this.trbSADWindow.TabIndex = 11;
            this.trbSADWindow.TickFrequency = 2;
            this.trbSADWindow.Value = 1;
            this.trbSADWindow.Scroll += new System.EventHandler(this.trbSADWindow_Scroll);
            // 
            // lblSADWindow
            // 
            this.lblSADWindow.AutoSize = true;
            this.lblSADWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSADWindow.Location = new System.Drawing.Point(29, 163);
            this.lblSADWindow.Name = "lblSADWindow";
            this.lblSADWindow.Size = new System.Drawing.Size(101, 16);
            this.lblSADWindow.TabIndex = 10;
            this.lblSADWindow.Text = "SAD Window:";
            // 
            // lblDisp12MaxDiff
            // 
            this.lblDisp12MaxDiff.AutoSize = true;
            this.lblDisp12MaxDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisp12MaxDiff.Location = new System.Drawing.Point(59, 214);
            this.lblDisp12MaxDiff.Name = "lblDisp12MaxDiff";
            this.lblDisp12MaxDiff.Size = new System.Drawing.Size(71, 16);
            this.lblDisp12MaxDiff.TabIndex = 9;
            this.lblDisp12MaxDiff.Text = "Max Diff :";
            // 
            // trbDisp12MaxDiff
            // 
            this.trbDisp12MaxDiff.Location = new System.Drawing.Point(136, 214);
            this.trbDisp12MaxDiff.Maximum = 100;
            this.trbDisp12MaxDiff.Minimum = -1;
            this.trbDisp12MaxDiff.Name = "trbDisp12MaxDiff";
            this.trbDisp12MaxDiff.Size = new System.Drawing.Size(313, 45);
            this.trbDisp12MaxDiff.TabIndex = 8;
            this.trbDisp12MaxDiff.TickFrequency = 10;
            this.trbDisp12MaxDiff.Value = -1;
            // 
            // trbDisparities
            // 
            this.trbDisparities.Location = new System.Drawing.Point(136, 61);
            this.trbDisparities.Maximum = 160;
            this.trbDisparities.Minimum = 16;
            this.trbDisparities.Name = "trbDisparities";
            this.trbDisparities.Size = new System.Drawing.Size(313, 45);
            this.trbDisparities.TabIndex = 7;
            this.trbDisparities.TickFrequency = 16;
            this.trbDisparities.Value = 64;
            this.trbDisparities.Scroll += new System.EventHandler(this.trbDisparities_Scroll);
            // 
            // lblDisparities
            // 
            this.lblDisparities.AutoSize = true;
            this.lblDisparities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisparities.Location = new System.Drawing.Point(43, 61);
            this.lblDisparities.Name = "lblDisparities";
            this.lblDisparities.Size = new System.Drawing.Size(87, 16);
            this.lblDisparities.TabIndex = 4;
            this.lblDisparities.Text = "Disparities:";
            // 
            // lblMinDisparities
            // 
            this.lblMinDisparities.AutoSize = true;
            this.lblMinDisparities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinDisparities.Location = new System.Drawing.Point(15, 112);
            this.lblMinDisparities.Name = "lblMinDisparities";
            this.lblMinDisparities.Size = new System.Drawing.Size(115, 16);
            this.lblMinDisparities.TabIndex = 2;
            this.lblMinDisparities.Text = "Min Disparities:";
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibration.Location = new System.Drawing.Point(180, 8);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(109, 24);
            this.lblCalibration.TabIndex = 1;
            this.lblCalibration.Text = "Calibration";
            // 
            // trbMinDisparities
            // 
            this.trbMinDisparities.Location = new System.Drawing.Point(136, 112);
            this.trbMinDisparities.Maximum = 159;
            this.trbMinDisparities.Name = "trbMinDisparities";
            this.trbMinDisparities.Size = new System.Drawing.Size(313, 45);
            this.trbMinDisparities.TabIndex = 0;
            this.trbMinDisparities.TickFrequency = 16;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItCaptureDevice,
            this.mItCalibration,
            this.dToolStripMenuItem,
            this.gimbleToolStripMenuItem,
            this.mItHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(740, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mItCaptureDevice
            // 
            this.mItCaptureDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItLeft,
            this.mItRight});
            this.mItCaptureDevice.Name = "mItCaptureDevice";
            this.mItCaptureDevice.Size = new System.Drawing.Size(99, 20);
            this.mItCaptureDevice.Text = "Capture Device";
            this.mItCaptureDevice.Click += new System.EventHandler(this.mItCaptureeDevice_Click);
            // 
            // mItLeft
            // 
            this.mItLeft.Name = "mItLeft";
            this.mItLeft.Size = new System.Drawing.Size(102, 22);
            this.mItLeft.Text = "Left";
            // 
            // mItRight
            // 
            this.mItRight.Name = "mItRight";
            this.mItRight.Size = new System.Drawing.Size(102, 22);
            this.mItRight.Text = "Right";
            // 
            // mItCalibration
            // 
            this.mItCalibration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItCalibrate,
            this.mItSettings});
            this.mItCalibration.Name = "mItCalibration";
            this.mItCalibration.Size = new System.Drawing.Size(77, 20);
            this.mItCalibration.Text = "Calibration";
            // 
            // mItCalibrate
            // 
            this.mItCalibrate.Name = "mItCalibrate";
            this.mItCalibrate.Size = new System.Drawing.Size(121, 22);
            this.mItCalibrate.Text = "Calibrate";
            this.mItCalibrate.Click += new System.EventHandler(this.mItCalibrate_Click);
            // 
            // mItSettings
            // 
            this.mItSettings.Name = "mItSettings";
            this.mItSettings.Size = new System.Drawing.Size(121, 22);
            this.mItSettings.Text = "Settings";
            this.mItSettings.Click += new System.EventHandler(this.mItSettings_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItRealD3D,
            this.mItAnaglyph,
            this.matchToolStripMenuItem,
            this.mItDisparityMap});
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.dToolStripMenuItem.Text = "3D View";
            // 
            // mItRealD3D
            // 
            this.mItRealD3D.Name = "mItRealD3D";
            this.mItRealD3D.Size = new System.Drawing.Size(147, 22);
            this.mItRealD3D.Text = "RealD3D";
            this.mItRealD3D.Click += new System.EventHandler(this.mItRealD3D_Click);
            // 
            // mItAnaglyph
            // 
            this.mItAnaglyph.Name = "mItAnaglyph";
            this.mItAnaglyph.Size = new System.Drawing.Size(147, 22);
            this.mItAnaglyph.Text = "Anaglyph";
            this.mItAnaglyph.Click += new System.EventHandler(this.mItAnaglyph_Click);
            // 
            // matchToolStripMenuItem
            // 
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.matchToolStripMenuItem.Text = "Match";
            this.matchToolStripMenuItem.Click += new System.EventHandler(this.matchToolStripMenuItem_Click);
            // 
            // mItDisparityMap
            // 
            this.mItDisparityMap.Name = "mItDisparityMap";
            this.mItDisparityMap.Size = new System.Drawing.Size(147, 22);
            this.mItDisparityMap.Text = "Disparity Map";
            this.mItDisparityMap.Click += new System.EventHandler(this.mItDisparityMap_Click);
            // 
            // gimbleToolStripMenuItem
            // 
            this.gimbleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portsToolStripMenuItem,
            this.homeToolStripMenuItem});
            this.gimbleToolStripMenuItem.Name = "gimbleToolStripMenuItem";
            this.gimbleToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.gimbleToolStripMenuItem.Text = "Gimble";
            this.gimbleToolStripMenuItem.Click += new System.EventHandler(this.mItGimble_Click);
            // 
            // portsToolStripMenuItem
            // 
            this.portsToolStripMenuItem.Name = "portsToolStripMenuItem";
            this.portsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.portsToolStripMenuItem.Text = "Port";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // mItHelp
            // 
            this.mItHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItKeyCombination,
            this.mItAbout});
            this.mItHelp.Name = "mItHelp";
            this.mItHelp.Size = new System.Drawing.Size(44, 20);
            this.mItHelp.Text = "Help";
            // 
            // mItKeyCombination
            // 
            this.mItKeyCombination.Name = "mItKeyCombination";
            this.mItKeyCombination.Size = new System.Drawing.Size(177, 22);
            this.mItKeyCombination.Text = "Key + Combination";
            this.mItKeyCombination.Click += new System.EventHandler(this.mItKeyCombination_Click);
            // 
            // mItAbout
            // 
            this.mItAbout.Name = "mItAbout";
            this.mItAbout.Size = new System.Drawing.Size(177, 22);
            this.mItAbout.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIsConnected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(740, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(88, 17);
            this.lblIsConnected.Text = "Not Connected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 570);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Stereo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisparityMap)).EndInit();
            this.pnlParametters.ResumeLayout(false);
            this.pnlParametters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUniquenessRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPreFilterCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSADWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisp12MaxDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinDisparities)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbVideoSourceRight;
        private System.Windows.Forms.PictureBox pbVideoSourceLeft;
        private System.Windows.Forms.PictureBox pbDisparityMap;
        private System.Windows.Forms.Panel pnlParametters;
        private System.Windows.Forms.Label lblMinDisparities;
        private System.Windows.Forms.Label lblCalibration;
        private System.Windows.Forms.Label lblDisparities;
        private System.Windows.Forms.Label lblDisp12MaxDiff;
        private System.Windows.Forms.Label lblSADWindow;
        private System.Windows.Forms.Label lblSpeckleWindow;
        private System.Windows.Forms.Label lblPreFilterCap;
        private System.Windows.Forms.Label lblUniquenessRatio;
        private System.Windows.Forms.Label lblSpeckleRange;
        private System.Windows.Forms.Label lblFullDPState;
        private System.Windows.Forms.TrackBar trbDisparities;
        private System.Windows.Forms.TrackBar trbMinDisparities;
        private System.Windows.Forms.TrackBar trbDisp12MaxDiff;
        private System.Windows.Forms.TrackBar trbSADWindow;
        private System.Windows.Forms.TrackBar trbSpeckleWindow;
        private System.Windows.Forms.TrackBar trbPreFilterCap;
        private System.Windows.Forms.TrackBar trbUniquenessRatio;
        private System.Windows.Forms.TrackBar trbSpeckleRange;
        private System.Windows.Forms.Button btnFullDPState;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mItCaptureDevice;
        private System.Windows.Forms.ToolStripMenuItem mItLeft;
        private System.Windows.Forms.ToolStripMenuItem mItRight;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mItRealD3D;
        private System.Windows.Forms.ToolStripMenuItem mItAnaglyph;
        private System.Windows.Forms.ToolStripMenuItem mItHelp;
        private System.Windows.Forms.ToolStripMenuItem mItKeyCombination;
        private System.Windows.Forms.ToolStripMenuItem mItAbout;
        private System.Windows.Forms.ToolStripMenuItem mItDisparityMap;
        private System.Windows.Forms.ToolStripMenuItem mItCalibration;
        private System.Windows.Forms.ToolStripMenuItem mItCalibrate;
        private System.Windows.Forms.ToolStripMenuItem mItSettings;
        private System.Windows.Forms.ToolStripMenuItem gimbleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblIsConnected;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
    }
}

