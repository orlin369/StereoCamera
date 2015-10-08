using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StereoImaging
{
    public partial class RealD3DForm : Form
    {

        #region Variables

        /// <summary>
        /// Last form location.
        /// </summary>
        private Point lastFormLocation = new Point();

        /// <summary>
        /// Last cursor location.
        /// </summary>
        private Point lastCursorLocation = new Point();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public RealD3DForm()
        {
            InitializeComponent();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);

            this.DoubleBuffered = true;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;


            this.pbVideoSourceLeft.SizeMode = PictureBoxSizeMode.CenterImage;
            this.pbVideoSourceRight.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Draw left image.
        /// </summary>
        /// <param name="image"></param>
        public void DrawLeft(Bitmap image)
        {
            // Because we are using an autosize picturebox we need to do a thread safe update
            if (this.pbVideoSourceLeft.InvokeRequired)
            {
                this.pbVideoSourceLeft.BeginInvoke((MethodInvoker)delegate()
                {
                    this.pbVideoSourceLeft.Image = this.ResizeImage(image, this.pbVideoSourceLeft.Size);
                });
            }
            else
            {
                this.pbVideoSourceLeft.Image = this.ResizeImage(image, this.pbVideoSourceLeft.Size);
            }
        }

        /// <summary>
        /// Draw right image.
        /// </summary>
        /// <param name="image"></param>
        public void DrawRight(Bitmap image)
        {
            // Because we are using an autosize picturebox we need to do a thread safe update
            if (this.pbVideoSourceRight.InvokeRequired)
            {
                this.pbVideoSourceRight.BeginInvoke((MethodInvoker)delegate()
                {
                    this.pbVideoSourceRight.Image = this.ResizeImage(image, this.pbVideoSourceRight.Size);
                });
            }
            else
            {
                this.pbVideoSourceRight.Image = this.ResizeImage(image, this.pbVideoSourceRight.Size);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Resize bitmap images.
        /// </summary>
        /// <param name="imgToResize">Source image.</param>
        /// <param name="size">Output size.</param>
        /// <returns>Resized new bitmap.</returns>
        private Bitmap ResizeImage(Bitmap sourceImage, Size size)
        {

            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bitmapImage = new Bitmap(destWidth, destHeight);
            Graphics graphics = Graphics.FromImage((Image)bitmapImage);

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(sourceImage, 0, 0, destWidth, destHeight);
            graphics.Dispose();

            return bitmapImage;
        }

        #endregion

        #region Picture boxes events

        private void pictureBoxes_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                int x = this.lastFormLocation.X + (System.Windows.Forms.Cursor.Position.X - this.lastCursorLocation.X);
                int y = this.lastFormLocation.Y + (System.Windows.Forms.Cursor.Position.Y - this.lastCursorLocation.Y);
                this.Location = new Point(x, y);
            }
        }

        private void pictureBoxes_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastFormLocation = this.Location;
            this.lastCursorLocation = System.Windows.Forms.Cursor.Position;
        }

        private void pictureBoxes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        #endregion

    }
}
