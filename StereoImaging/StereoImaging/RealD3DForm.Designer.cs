namespace StereoImaging
{
    partial class RealD3DForm
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
            this.tblpImageContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pbVideoSourceLeft = new System.Windows.Forms.PictureBox();
            this.pbVideoSourceRight = new System.Windows.Forms.PictureBox();
            this.tblpImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceRight)).BeginInit();
            this.SuspendLayout();
            // 
            // tblpImageContainer
            // 
            this.tblpImageContainer.AutoSize = true;
            this.tblpImageContainer.BackColor = System.Drawing.Color.Black;
            this.tblpImageContainer.ColumnCount = 2;
            this.tblpImageContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpImageContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpImageContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblpImageContainer.Controls.Add(this.pbVideoSourceLeft, 0, 0);
            this.tblpImageContainer.Controls.Add(this.pbVideoSourceRight, 1, 0);
            this.tblpImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpImageContainer.Location = new System.Drawing.Point(0, 0);
            this.tblpImageContainer.Name = "tblpImageContainer";
            this.tblpImageContainer.RowCount = 1;
            this.tblpImageContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpImageContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpImageContainer.Size = new System.Drawing.Size(622, 229);
            this.tblpImageContainer.TabIndex = 1;
            // 
            // pbVideoSourceLeft
            // 
            this.pbVideoSourceLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVideoSourceLeft.Location = new System.Drawing.Point(3, 3);
            this.pbVideoSourceLeft.Name = "pbVideoSourceLeft";
            this.pbVideoSourceLeft.Size = new System.Drawing.Size(305, 223);
            this.pbVideoSourceLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVideoSourceLeft.TabIndex = 0;
            this.pbVideoSourceLeft.TabStop = false;
            this.pbVideoSourceLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseDoubleClick);
            this.pbVideoSourceLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseDown);
            this.pbVideoSourceLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseMove);
            // 
            // pbVideoSourceRight
            // 
            this.pbVideoSourceRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVideoSourceRight.Location = new System.Drawing.Point(314, 3);
            this.pbVideoSourceRight.Name = "pbVideoSourceRight";
            this.pbVideoSourceRight.Size = new System.Drawing.Size(305, 223);
            this.pbVideoSourceRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVideoSourceRight.TabIndex = 1;
            this.pbVideoSourceRight.TabStop = false;
            this.pbVideoSourceRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseDoubleClick);
            this.pbVideoSourceRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseDown);
            this.pbVideoSourceRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxes_MouseMove);
            // 
            // RealD3DForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 229);
            this.Controls.Add(this.tblpImageContainer);
            this.Name = "RealD3DForm";
            this.Text = "RealD3DForm";
            this.tblpImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoSourceRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblpImageContainer;
        private System.Windows.Forms.PictureBox pbVideoSourceRight;
        private System.Windows.Forms.PictureBox pbVideoSourceLeft;
    }
}