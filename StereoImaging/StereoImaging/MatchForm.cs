using DevilVision.Drawing.Colors;
using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;
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
    public partial class MatchForm : Form
    {
        public MatchForm()
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
                    //this.pbImage.Image = this.MatchImages(new Image<Emgu.CV.Structure.Gray, byte>(leftImage), new Image<Emgu.CV.Structure.Gray, byte>(rightImage)).ToBitmap();
                    //this.pbImage.Image = this.ResizeImage(this.Anaglyph(leftImage, rightImage), this.pbImage.Size);
                });
            }
            else
            {
                //this.pbImage.Image = this.MatchImages(new Image<Emgu.CV.Structure.Gray, byte>(leftImage), new Image<Emgu.CV.Structure.Gray, byte>(rightImage)).ToBitmap();
                //this.pbImage.Image = this.ResizeImage(this.Anaglyph(leftImage, rightImage), this.pbImage.Size);
            }
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
        //Emgu.CV.Structure.

    }
}
