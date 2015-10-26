using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Threading;

// Anaglyph
using StereoScopic;

namespace DiO_CS_SterescopicGenerator
{
    public partial class MainForm : Form
    {

        #region Variables

        /// <summary>
        /// Image path
        /// </summary>
        private string imagePath;

        /// <summary>
        /// Input original image.
        /// </summary>
        private Bitmap inputImage;
        
        /// <summary>
        /// Output processed image.
        /// </summary>
        private Bitmap outputImage;

        /// <summary>
        /// Shift value tels us what is the offset of the on monolith image.
        /// </summary>
        private int shiftValue = 20; 
        // 8 e slabo,
        // Iva ne raboti na 36 ofseta
        // Iva se kefi na 22
        // Po-ploskite (lipsa na izqwena dylbochina) kadri rabotyat dobre na 36.

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods.

        /// <summary>
        /// Resize the bitmap images.
        /// </summary>
        /// <param name="imgToResize">Source image.</param>
        /// <param name="size"></param>
        /// <returns></returns>
        private Bitmap resizeImage(Bitmap sourceImage, Size size)
        {
            // 20140918 JI@DevGroup: За преоразмеряване потърси по-бързи алгоритми, които работят на по-ниско ниво (unsafe code)
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            // 20140918 JI@DevGroup: Мнемонично именуване (унгарска анотация) се използва само в С++ и то в по-старите версии
            //                       nPersent -> persent
            float persent = 0;
            float persentWidth = 0;
            float persentHeight = 0;

            persentWidth = ((float)size.Width / (float)sourceWidth);
            persentHeight = ((float)size.Height / (float)sourceHeight);

            if (persentHeight < persentWidth)
            {
                persent = persentHeight;
            }
            else
            {
                persent = persentWidth;
            }

            int destWidth = (int)(sourceWidth * persent);
            int destHeight = (int)(sourceHeight * persent);

            Bitmap bitmapImage = new Bitmap(destWidth, destHeight);
            Graphics graphics = Graphics.FromImage((Image)bitmapImage);

            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(sourceImage, 0, 0, destWidth, destHeight);
            graphics.Dispose();

            return bitmapImage;
        }

        /// <summary>
        /// Load the image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenOneImage()
        {
            DialogResult dialogResult; // 20140918 JI@DevGroup: dialogResult (missing "a")
            OpenFileDialog loadCcmFile = new OpenFileDialog();

            loadCcmFile.Filter = "Images (.*)|*.*|PNG Image (.png)|*.PNG";
            loadCcmFile.FilterIndex = 1;
            loadCcmFile.Title = "Load image";
            loadCcmFile.Multiselect = false;

            dialogResult = loadCcmFile.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            // Save the image path.
            this.imagePath = loadCcmFile.FileName;

            // Load the image.
            this.inputImage = new Bitmap(this.imagePath);

            // Show the resized image.
            this.pbMain.Image = this.resizeImage(this.inputImage, this.pbMain.Size);
        }

        /// <summary>
        /// Process two separate images.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTwoImages()
        {
            // Images
            Bitmap leftImage = null;
            Bitmap rightImage = null;

            // Images paths.
            string leftImagePath = "";
            string rightImagePath = "";

            // Dialog box
            DialogResult dilogResult;
            OpenFileDialog loadCcmFile = new OpenFileDialog();

            // Common settings.
            loadCcmFile.Filter = "Images (.*)|*.*|PNG Image (.png)|*.PNG";
            loadCcmFile.FilterIndex = 1;
            loadCcmFile.Multiselect = false;


            loadCcmFile.Title = "Load Left image.";
            dilogResult = loadCcmFile.ShowDialog();
            if (dilogResult != DialogResult.OK)
            {
                return;
            }
            // Add file path.
            leftImagePath = loadCcmFile.FileName;

            loadCcmFile.Title = "Load Right image.";
            dilogResult = loadCcmFile.ShowDialog();
            if (dilogResult != DialogResult.OK)
            {
                return;
            }
            // Add file path.
            rightImagePath = loadCcmFile.FileName;

            // Create the images.
            leftImage = new Bitmap(leftImagePath);
            rightImage = new Bitmap(rightImagePath);

            // Verifie the size.
            if(leftImage == null)
            {
                // Incoret image load ...
                return;
            }

            if(rightImage == null)
            {
                // Incorect image load
                return;
            }

            if(!leftImage.Size.Equals((Size)rightImage.Size))
            {
                MessageBox.Show(String.Format("The size of the right image,\ndoes not match to the size,\nof the left image.\n{0} != {1}", leftImage.Size, rightImage.Size), "Inconsistent size.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Incorect image size.
                return;
            }

            // Rend the image.
            this.outputImage = Anaglyph.Make3DFrom2Images(leftImage, rightImage);

            // Show the image.
            this.pbMain.Image = this.resizeImage(this.outputImage, this.pbMain.Size);
        }

        /// <summary>
        /// Prosecc image.
        /// </summary>
        private void ProcessImage()
        {
            // jivanov@repir.eu Julian Ivanov
            // 20140918 JI@DevGroup: Long running task should not be executed in the main thread.
            //                       Thread thread = new Thread(() => 
            //                                                  {
            //                                                      // code executend in another thread
            //                                                  });
            //                       thread.Start();

            Thread workerThread = new Thread(() =>
            {
                // Rend the image.
                this.outputImage = Anaglyph.Make3DPopIn(new Bitmap((Image)this.inputImage), this.shiftValue);
                // Show the nwe mage.
                this.pbMain.Image = this.resizeImage(this.outputImage, this.pbMain.Size);
            });
            workerThread.Start();

        }

        /// <summary>
        /// Save the processed image.
        /// </summary>
        private void SaveImage()
        {
            Thread workerThread = new Thread(() =>
            {
                // Generate the image name.
                string tmpPath = this.imagePath.Replace(Path.GetExtension(this.imagePath), String.Format("_3D_{0}.PNG", this.shiftValue));
                // Save the image.
                this.outputImage.Save(tmpPath);
            });
            workerThread.Start();
        }

        #endregion

        #region Track bar shift value.

        /// <summary>
        /// When the track bar value change update everything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbShiftValue_ValueChanged(object sender, EventArgs e)
        {
            // Update the value.
            this.shiftValue = this.trbShiftValue.Value;
            // Visualise the value.
            this.lblShiftValue.Text = String.Format("Shift: {0}", this.shiftValue);
        }

        #endregion

        #region Main Form

        /// <summary>
        /// When form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Visualise the value.
            this.lblShiftValue.Text = String.Format("Shift: {0}", this.shiftValue);
        }

        #endregion

        #region Tool strip menuitems.

        private void openOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenOneImage();
        }

        private void openTwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenTwoImages();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ProcessImage();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveImage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if (this.pbMain.Image != null)
            //{
            //    // Show the resized image.
            //    this.pbMain.Image = this.resizeImage(this.inputImage, this.pbMain.Size);
            //}
        }


    }
}
