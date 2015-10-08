using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StereoImaging
{
    public partial class AnaglyphForm : Form
    {
        public AnaglyphForm()
        {
            InitializeComponent();
        }

        public void DrawImage(Bitmap leftImage, Bitmap rightImage)
        {
            // Because we are using an autosize picturebox we need to do a thread safe update
            if (this.pbImage.InvokeRequired)
            {
                this.pbImage.BeginInvoke((MethodInvoker)delegate()
                {
                    this.pbImage.Image = this.ResizeImage(this.Anaglyph(leftImage, rightImage), this.pbImage.Size);
                });
            }
            else
            {
                this.pbImage.Image = this.ResizeImage(this.Anaglyph(leftImage, rightImage), this.pbImage.Size);
            }
        }

        /// <summary>
        /// Create anaglyph image.
        /// </summary>
        /// <param name="leftImage"></param>
        /// <param name="rightImage"></param>
        /// <returns>Anaglyph image.</returns>
        private Bitmap Anaglyph(Bitmap leftImage, Bitmap rightImage)
        {
            DevilVision.Drawing.Image<DevilVision.Drawing.Colors.Rgb> dvLeftImage = new DevilVision.Drawing.Image<DevilVision.Drawing.Colors.Rgb>(leftImage);
            DevilVision.Drawing.Image<DevilVision.Drawing.Colors.Rgb> dvRightImage = new DevilVision.Drawing.Image<DevilVision.Drawing.Colors.Rgb>(rightImage);

            byte[] leftImageBytes = dvLeftImage.Bytes;
            byte[] rightImageBytes = dvRightImage.Bytes;

            // Result array.
            //byte[] result = new byte[dvLeftImage.Bytes.Length];

            for (int i = 0; i < dvLeftImage.Bytes.Length; i += 3)
            {
                // Red chanel.
                leftImageBytes[i] = rightImageBytes[i];
                // Green chanel.
                //leftImageBytes[++i] = leftImageBytes[i];
                // Blue chanel.
                //leftImageBytes[++i] = leftImageBytes[i];
            }

            return new DevilVision.Drawing.Image<DevilVision.Drawing.Colors.Rgb>(leftImage.Width, leftImage.Height, leftImageBytes).ToBitmap();
        }

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
    }
}
