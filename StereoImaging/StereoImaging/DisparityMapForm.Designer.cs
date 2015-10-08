namespace StereoImaging
{
    partial class DisparityMapForm
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
            this.trbMinDisparities = new System.Windows.Forms.TrackBar();
            this.lblCalibration = new System.Windows.Forms.Label();
            this.lblMinDisparities = new System.Windows.Forms.Label();
            this.lblDisparities = new System.Windows.Forms.Label();
            this.trbDisparities = new System.Windows.Forms.TrackBar();
            this.trbDisp12MaxDiff = new System.Windows.Forms.TrackBar();
            this.lblDisp12MaxDiff = new System.Windows.Forms.Label();
            this.lblSADWindow = new System.Windows.Forms.Label();
            this.trbSADWindow = new System.Windows.Forms.TrackBar();
            this.lblSpeckleWindow = new System.Windows.Forms.Label();
            this.trbSpeckleWindow = new System.Windows.Forms.TrackBar();
            this.lblPreFilterCap = new System.Windows.Forms.Label();
            this.trbPreFilterCap = new System.Windows.Forms.TrackBar();
            this.lblUniquenessRatio = new System.Windows.Forms.Label();
            this.trbUniquenessRatio = new System.Windows.Forms.TrackBar();
            this.lblSpeckleRange = new System.Windows.Forms.Label();
            this.trbSpeckleRange = new System.Windows.Forms.TrackBar();
            this.btnFullDPState = new System.Windows.Forms.Button();
            this.lblFullDPState = new System.Windows.Forms.Label();
            this.pnlParametters = new System.Windows.Forms.Panel();
            this.pbDisparityMap = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbMinDisparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisparities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisp12MaxDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSADWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPreFilterCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUniquenessRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleRange)).BeginInit();
            this.pnlParametters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisparityMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pnlParametters, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pbDisparityMap, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.23967F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.76033F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 605);
            this.tableLayoutPanel1.TabIndex = 1;
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
            // trbSpeckleWindow
            // 
            this.trbSpeckleWindow.Location = new System.Drawing.Point(136, 364);
            this.trbSpeckleWindow.Maximum = 64;
            this.trbSpeckleWindow.Name = "trbSpeckleWindow";
            this.trbSpeckleWindow.Size = new System.Drawing.Size(313, 45);
            this.trbSpeckleWindow.TabIndex = 13;
            this.trbSpeckleWindow.TickFrequency = 8;
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
            // trbPreFilterCap
            // 
            this.trbPreFilterCap.Location = new System.Drawing.Point(136, 265);
            this.trbPreFilterCap.Maximum = 1000;
            this.trbPreFilterCap.Name = "trbPreFilterCap";
            this.trbPreFilterCap.Size = new System.Drawing.Size(313, 45);
            this.trbPreFilterCap.TabIndex = 15;
            this.trbPreFilterCap.TickFrequency = 100;
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
            // trbUniquenessRatio
            // 
            this.trbUniquenessRatio.Location = new System.Drawing.Point(136, 316);
            this.trbUniquenessRatio.Maximum = 30;
            this.trbUniquenessRatio.Name = "trbUniquenessRatio";
            this.trbUniquenessRatio.Size = new System.Drawing.Size(313, 45);
            this.trbUniquenessRatio.TabIndex = 17;
            this.trbUniquenessRatio.TickFrequency = 2;
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
            // trbSpeckleRange
            // 
            this.trbSpeckleRange.Location = new System.Drawing.Point(136, 415);
            this.trbSpeckleRange.Maximum = 160;
            this.trbSpeckleRange.Name = "trbSpeckleRange";
            this.trbSpeckleRange.Size = new System.Drawing.Size(313, 45);
            this.trbSpeckleRange.TabIndex = 19;
            this.trbSpeckleRange.TickFrequency = 16;
            // 
            // btnFullDPState
            // 
            this.btnFullDPState.Location = new System.Drawing.Point(136, 459);
            this.btnFullDPState.Name = "btnFullDPState";
            this.btnFullDPState.Size = new System.Drawing.Size(313, 30);
            this.btnFullDPState.TabIndex = 20;
            this.btnFullDPState.Text = "False";
            this.btnFullDPState.UseVisualStyleBackColor = true;
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
            this.pnlParametters.Location = new System.Drawing.Point(3, 434);
            this.pnlParametters.Name = "pnlParametters";
            this.pnlParametters.Size = new System.Drawing.Size(654, 168);
            this.pnlParametters.TabIndex = 3;
            // 
            // pbDisparityMap
            // 
            this.pbDisparityMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDisparityMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDisparityMap.Location = new System.Drawing.Point(3, 3);
            this.pbDisparityMap.Name = "pbDisparityMap";
            this.pbDisparityMap.Size = new System.Drawing.Size(654, 425);
            this.pbDisparityMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDisparityMap.TabIndex = 6;
            this.pbDisparityMap.TabStop = false;
            // 
            // DisparityMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 605);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DisparityMapForm";
            this.Text = "DisparityMapForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbMinDisparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisparities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDisp12MaxDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSADWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPreFilterCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbUniquenessRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeckleRange)).EndInit();
            this.pnlParametters.ResumeLayout(false);
            this.pnlParametters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisparityMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlParametters;
        private System.Windows.Forms.Label lblFullDPState;
        private System.Windows.Forms.Button btnFullDPState;
        private System.Windows.Forms.TrackBar trbSpeckleRange;
        private System.Windows.Forms.Label lblSpeckleRange;
        private System.Windows.Forms.TrackBar trbUniquenessRatio;
        private System.Windows.Forms.Label lblUniquenessRatio;
        private System.Windows.Forms.TrackBar trbPreFilterCap;
        private System.Windows.Forms.Label lblPreFilterCap;
        private System.Windows.Forms.TrackBar trbSpeckleWindow;
        private System.Windows.Forms.Label lblSpeckleWindow;
        private System.Windows.Forms.TrackBar trbSADWindow;
        private System.Windows.Forms.Label lblSADWindow;
        private System.Windows.Forms.Label lblDisp12MaxDiff;
        private System.Windows.Forms.TrackBar trbDisp12MaxDiff;
        private System.Windows.Forms.TrackBar trbDisparities;
        private System.Windows.Forms.Label lblDisparities;
        private System.Windows.Forms.Label lblMinDisparities;
        private System.Windows.Forms.Label lblCalibration;
        private System.Windows.Forms.TrackBar trbMinDisparities;
        private System.Windows.Forms.PictureBox pbDisparityMap;
    }
}