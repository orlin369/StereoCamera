using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

//EMGU
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

//DiresctShow
using DirectShowLib;
using System.Drawing.Drawing2D;

using GUI.InputMethods.KeystrokEventGenerator;
using StereoImaging.MotionPlatform;


namespace StereoImaging
{
    public partial class MainForm : Form
    {
        #region Constants
        
        /// <summary>
        /// Define the aquasition length of the buffer.
        /// </summary>
        private const int BUFFER_LENGTH = 100;

        /// <summary>
        /// Calibration board square size. [mm]
        /// </summary>
        private const float SQ_SIZE = 13.0F;

        /// <summary>
        ///  Calibration board crosses width.
        /// </summary>
        private const int SQ_WIDTH = 19;

        /// <summary>
        ///  Calibration board crosses heigth.
        /// </summary>
        private const int SQ_HEIGHT = 13;

        #endregion

        #region Devices

        /// <summary>
        /// Video capture devices.
        /// </summary>
        private VideoDevice[] videoDevices;

        /// <summary>
        /// It is used for frame aquisition.
        /// </summary>
        private System.Windows.Forms.Timer frameAcquirer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Camera 1
        /// </summary>
        private Capture captureLeft;
        
        /// <summary>
        /// Camera 2
        /// </summary>
        private Capture captureRight;

        /// <summary>
        /// 
        /// </summary>
        private bool syncFlag = true;

        /// <summary>
        /// 
        /// </summary>
        private bool enableDisparity = false;

        #endregion
        
        #region Frames

        private Image<Bgr, Byte> frameColorLeft;
        private Image<Gray, Byte> frameGrayLeft;
        private Image<Bgr, Byte> frameColorRight;
        private Image<Gray, Byte> frameGrayRight;

        #endregion

        #region Chessboard detection

        /// <summary>
        /// Size of chess board to be detected.
        /// </summary>
        private Size patternSize = new Size(SQ_WIDTH, SQ_HEIGHT);

        /// <summary>
        /// Just for displaying coloured lines of detected chessboard.
        /// </summary>
        private Bgr[] lineColours = new Bgr[SQ_WIDTH * SQ_HEIGHT];
 
        /// <summary>
        /// Corners in left image.
        /// </summary>
        private PointF[] cornersLeft;

        /// <summary>
        /// Corners in right image.
        /// </summary>
        private PointF[] cornersRight;

        /// <summary>
        /// Start calibration process.
        /// </summary>
        private bool beginCalibrationProcess = false;

        #endregion

        #region Buffers

        /// <summary>
        /// Tracks the filled partition of the buffer.
        /// </summary>
        private int savedBufferIndex = 0;

        /// <summary>
        /// Stores the calculated size for the chessboard.
        /// </summary>
        MCvPoint3D32f[][] cornersObjectPoints = new MCvPoint3D32f[BUFFER_LENGTH][];

        /// <summary>
        /// Stores the calculated points from chessboard detection Camera 1
        /// </summary>
        PointF[][] cornersPointsLeft = new PointF[BUFFER_LENGTH][];

        /// <summary>
        /// Stores the calculated points from chessboard detection Camera 2
        /// </summary>
        PointF[][] cornersPointsRight = new PointF[BUFFER_LENGTH][];

        #endregion

        #region Calibration parmeters

        /// <summary>
        /// Camera 1
        /// </summary>
        private IntrinsicCameraParameters icpLeft = new IntrinsicCameraParameters();

        /// <summary>
        /// Camera 2
        /// </summary>
        private IntrinsicCameraParameters icpRight = new IntrinsicCameraParameters();

        /// <summary>
        /// Output of Extrinsics for Camera 1 & 2
        /// </summary>
        private ExtrinsicCameraParameters ecp;

        /// <summary>
        /// Fundemental output matrix for StereoCalibrate.
        /// </summary>
        private Matrix<double> fundamental;

        /// <summary>
        /// Essential output matrix for StereoCalibrate.
        /// </summary>
        private Matrix<double> essential;

        /// <summary>
        /// Rectangle Calibrated in camera 1.
        /// </summary>
        private Rectangle rectangleLeft = new Rectangle();

        /// <summary>
        /// Rectangle Caliubrated in camera 2.
        /// </summary>
        private Rectangle rectangleRight = new Rectangle();

        /// <summary>
        /// This is what were interested in the disparity-to-depth mapping matrix
        /// </summary>
        private Matrix<double> Q = new Matrix<double>(4, 4);

        /// <summary>
        /// Rectification transforms (rotation matrices) for Camera 1.
        /// </summary>
        private Matrix<double> R1Left = new Matrix<double>(3, 3);

        /// <summary>
        /// Rectification transforms (rotation matrices) for Camera 2.
        /// </summary>
        private Matrix<double> R2Right = new Matrix<double>(3, 3);

        /// <summary>
        /// Projection matrices in the new (rectified) coordinate systems for Camera 1.
        /// </summary>
        private Matrix<double> P1 = new Matrix<double>(3, 4);

        /// <summary>
        /// Projection matrices in the new (rectified) coordinate systems for Camera 2.
        /// </summary>
        private Matrix<double> P2 = new Matrix<double>(3, 4);

        /// <summary>
        /// Computer 3D points from stereo pair.
        /// </summary>
        private MCvPoint3D32f[] streoPearPoints;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private RealD3DForm reald3DForm = new RealD3DForm();

        /// <summary>
        /// 
        /// </summary>
        private AnaglyphForm anaglyphForm = new AnaglyphForm();

        /// <summary>
        /// Match drawer.
        /// </summary>
        private MatchForm matchForm = new MatchForm();

        /// <summary>
        /// Stereo mode.
        /// </summary>
        private Emgu.CV.StereoSGBM.Mode stereoMode = Emgu.CV.StereoSGBM.Mode.SGBM;

        /// <summary>
        /// Working mode.
        /// </summary>
        private Mode currentMode = Mode.None;

        /// <summary>
        /// Progres form.
        /// </summary>
        private ProgresForm progresForm = new ProgresForm();

        /// <summary>
        /// 
        /// </summary>
        private Gimble gimble;

        #region Delegates

        /// <summary>
        /// Thread safe method to get a slider value from form
        /// </summary>
        /// <param name="Control"></param>
        /// <returns></returns>
        private delegate int GetSlideValueDelgate(TrackBar Control);

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            
            // Check to see what video inputs we have available.
            this.videoDevices = this.GetDevices();

            if (videoDevices.Length == 0)
            {
                DialogResult res = MessageBox.Show("A camera device was not detected. Do you want to exit?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (videoDevices.Length < 2)
            {
                DialogResult res = MessageBox.Show("Only 1 camera detected. Stero Imaging can not be emulated. Do you want to exit?", "",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            // Add cameras to the menus.
            this.AddCameras(this.videoDevices, this.mItLeft, this.mItCaptureLeft_Click);
            this.AddCameras(this.videoDevices, this.mItRight, this.mItCaptureRight_Click);
            // Add ports to the menu items.
            this.SearchForPorts();

            // Set up chessboard drawing array.
            Random R = new Random();
            for (int i = 0; i < lineColours.Length; i++)
            {
                this.lineColours[i] = new Bgr(R.Next(0, 255), R.Next(0, 255), R.Next(0, 255));
            }

            // Frame acquirer timer. 
            this.frameAcquirer.Stop();
            this.frameAcquirer.Tick += this.frameAcquirer_Tick;
            this.frameAcquirer.Interval = 10;
            this.frameAcquirer.Start();

            //
            this.progresForm.FormClosing += progresForm_FormClosing;
            this.progresForm.SetValue(0);

            // Attach keyboard strokes events.
            KeystrokMessageFilter kbMsg = new KeystrokMessageFilter();
            kbMsg.OnOpenReald3D += kbMsg_OnOpenReald3D;
            kbMsg.OnOpenAnaglyph += kbMsg_OnOpenAnaglyph;
            kbMsg.OnExitForm += kbMsg_OnExitForm;
            kbMsg.OnFullScreen += kbMsg_OnFullScreen;
            // Attach the handler.
            Application.AddMessageFilter(kbMsg);
            
        }

        #endregion

        #region Keyboard stroke filter

        private void kbMsg_OnFullScreen(object sender, EventArgs e)
        {
            if (this.reald3DForm != null && this.reald3DForm.Visible && this.reald3DForm.Focused)
            {
                this.reald3DForm.WindowState = FormWindowState.Maximized;
            }

            if (this.anaglyphForm != null && this.anaglyphForm.Visible && this.anaglyphForm.Focused)
            {
                this.anaglyphForm.WindowState = FormWindowState.Maximized;
            }

            if (this.matchForm != null && this.matchForm.Visible && this.matchForm.Focused)
            {
                this.matchForm.WindowState = FormWindowState.Maximized;
            }
        }

        private void kbMsg_OnOpenAnaglyph(object sender, EventArgs e)
        {
            this.anaglyphForm = new AnaglyphForm();
            this.anaglyphForm.Show();
        }

        private void kbMsg_OnOpenReald3D(object sender, EventArgs e)
        {
            this.reald3DForm = new RealD3DForm();
            this.reald3DForm.Show();
        }

        private void kbMsg_OnExitForm(object sender, EventArgs e)
        {
            if (this.reald3DForm != null && this.reald3DForm.Visible && this.reald3DForm.Focused)
            {
                this.reald3DForm.Close();
            }

            if (this.anaglyphForm != null && this.anaglyphForm.Visible && this.anaglyphForm.Focused)
            {
                this.anaglyphForm.Close();
            }

            if (this.matchForm != null && this.matchForm.Visible && this.matchForm.Focused)
            {
                this.matchForm.Close();
            }
        }

        #endregion

        #region Private Methods

        private VideoDevice[] GetDevices()
        {
            //Set up the capture method 
            //-> Find systems cameras with DirectShow.Net dll, thanks to Carles Lloret.
            DsDevice[] systemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            
            VideoDevice[] videoDevices = new VideoDevice[systemCamereas.Length];

            for (int index = 0; index < systemCamereas.Length; index++)
            {
                videoDevices[index] = new VideoDevice(index, systemCamereas[index].Name, systemCamereas[index].ClassID);
            }

            return videoDevices;
        }

        private void AddCameras(VideoDevice[] videoDevices, ToolStripMenuItem menu, EventHandler callback)
        {
            if (videoDevices.Length == 0)
            {
                return;
            }

            menu.DropDown.Items.Clear();

            foreach (VideoDevice device in videoDevices)
            {
                // Store the each retrieved available capture device into the MenuItems.
                ToolStripMenuItem mItem = new ToolStripMenuItem();

                mItem.Text = String.Format("{0:D2} / {1}", device.Index, device.Name);
                mItem.Tag = device.Index;
                mItem.Enabled = true;
                mItem.Checked = false;

                //TODO: Grozno
                mItem.Click += callback;

                menu.DropDown.Items.Add(mItem);
            }
        }

        private int GetSliderValue(TrackBar Control)
        {
            if (Control.InvokeRequired)
            {
                try
                {
                    return (int)Control.Invoke(new Func<int>(() => GetSliderValue(Control)));
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return Control.Value;
            }
        }

        private void SearchForPorts()
        {
            this.portsToolStripMenuItem.DropDown.Items.Clear();

            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                return;
            }

            foreach (string item in portNames)
            {
                //store the each retrieved available prot names into the MenuItems...
                this.portsToolStripMenuItem.DropDown.Items.Add(item);
            }

            foreach (ToolStripMenuItem item in this.portsToolStripMenuItem.DropDown.Items)
            {
                item.Click += mItPorts_Click;
                item.Enabled = true;
                item.Checked = false;
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

        #endregion

        #region Menu Items

        private void mItCaptureLeft_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            this.pbVideoSourceLeft.Tag = item.Text;

            int index = (int)item.Tag;

            if (this.captureLeft != null)
            {
                this.captureLeft.Stop();
            }

            this.captureLeft = new Capture(index);

            // We will only use 1 frame ready event this is not really safe but it fits the purpose.
            //this.captureLeft.ImageGrabbed += captureLeft_ImageGrabbed;

            //_Capture2.Start(); //We make sure we start Capture device 2 first.
            this.captureLeft.Start();
        }

        private void mItCaptureRight_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            this.pbVideoSourceRight.Tag = item.Text;

            int index = (int)item.Tag;

            if (this.captureRight != null)
            {
                this.captureRight.Stop();
            }

            this.captureRight = new Capture(index);

            // We will only use 1 frame ready event this is not really safe but it fits the purpose.
            //this.captureRight.ImageGrabbed += captureRight_ImageGrabbed;

            //_Capture2.Start(); //We make sure we start Capture device 2 first.
            this.captureRight.Start();
        }

        private void mItCaptureeDevice_Click(object sender, EventArgs e)
        {
            // Check to see what video inputs we have available.
            this.videoDevices = this.GetDevices();

            if (videoDevices.Length == 0)
            {
                DialogResult res = MessageBox.Show("A camera device was not detected. Do you want to exit?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (videoDevices.Length < 2)
            {
                DialogResult res = MessageBox.Show("Only 1 camera detected. Stero Imaging can not be emulated. Do you want to exit?", "",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }

            this.AddCameras(this.videoDevices, this.mItLeft, this.mItCaptureLeft_Click);

            this.AddCameras(this.videoDevices, this.mItRight, this.mItCaptureRight_Click);
        }

        private void mItCalibrate_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to enter in Calibration mode?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                this.enableDisparity = true;

                this.currentMode = Mode.SavingFrames;
                
                this.beginCalibrationProcess = true;
                
                if (this.progresForm.InvokeRequired)
                {
                    this.progresForm.BeginInvoke((MethodInvoker)delegate()
                    {
                        this.progresForm = new ProgresForm();
                        this.progresForm.FormClosing += this.progresForm_FormClosing;
                        this.progresForm.Show();
                    });
                }
                else
                {
                    this.progresForm = new ProgresForm();
                    this.progresForm.FormClosing += this.progresForm_FormClosing;
                    this.progresForm.Show();
                }
            }
        }

        private void mItRealD3D_Click(object sender, EventArgs e)
        {
            this.reald3DForm = new RealD3DForm();
            this.reald3DForm.Show();
        }

        private void mItKeyCombination_Click(object sender, EventArgs e)
        {
            string message =
                "Ctrl + Shift + D => RealD3D Image" + Environment.NewLine +
                "Ctrl + Shift + A => Anaglyph Image." + Environment.NewLine +
                "Ctrl + Shift + F => Image form full screen." + Environment.NewLine +
                "Escape           => Image form exit screen.";

            MessageBox.Show(message, "Key combinations", MessageBoxButtons.OK);
        }

        private void mItAnaglyph_Click(object sender, EventArgs e)
        {
            this.anaglyphForm = new AnaglyphForm();
            this.anaglyphForm.Show();
        }

        private void matchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.matchForm = new MatchForm();
            this.matchForm.Show();
        }

        private void mItSettings_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mItDisparityMap_Click(object sender, EventArgs e)
        {

        }

        private void mItGimble_Click(object sender, EventArgs e)
        {
            // When you click to the menu, update ports.
            this.SearchForPorts();
        }

        private void mItPorts_Click(object sender, EventArgs e)
        {

            this.DisconnectFromGimble();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.gimble = new Gimble(item.Text);
            this.ConnectToGimble();

            if (this.gimble.IsConnected)
            {
                this.lblIsConnected.Text = String.Format("Connected@{0}", this.gimble.PortName);
            }
            else
            {
                this.lblIsConnected.Text = "Not Connected";
            }
        }

        #endregion

        #region Time Tick

        private void frameAcquirer_Tick(object sender, EventArgs e)
        {
            if (this.syncFlag)
            {
                this.syncFlag = false;

                if (this.captureLeft != null)
                {
                    this.frameColorLeft = this.captureLeft.QueryFrame().ToImage<Bgr, byte>();

                    if (this.frameColorLeft == null)
                    {
                        return;
                    }

                    this.frameGrayLeft = this.frameColorLeft.Convert<Gray, Byte>();

                    // Because we are using an autosize picturebox we need to do a thread safe update
                    if (this.pbVideoSourceLeft.InvokeRequired)
                    {
                        this.pbVideoSourceLeft.BeginInvoke((MethodInvoker)delegate()
                        {
                            this.pbVideoSourceLeft.Image = this.ResizeImage(this.frameColorLeft.ToBitmap(), this.pbVideoSourceLeft.Size);
                            //this.pbVideoSourceLeft.Image = this.frameColorLeft.ToBitmap();
                            this.pbVideoSourceLeft.Refresh();
                        });
                    }
                    else
                    {
                        this.pbVideoSourceLeft.Image = this.ResizeImage(this.frameColorLeft.ToBitmap(), this.pbVideoSourceLeft.Size);
                        this.pbVideoSourceLeft.Refresh();
                    }
                }

                if (this.captureRight != null)
                {
                    //this.frameColorRight = this.captureRight.QueryFrame().ToImage<Bgr, byte>();
                    
                    if (this.frameColorRight == null)
                    {
                        return;
                    }

                    this.frameGrayRight = this.frameColorRight.Convert<Gray, Byte>();

                    // Because we are using an autosize picturebox we need to do a thread safe update
                    if (this.pbVideoSourceRight.InvokeRequired)
                    {
                        this.pbVideoSourceRight.BeginInvoke((MethodInvoker)delegate()
                        {
                            this.pbVideoSourceRight.Image = this.ResizeImage(this.frameColorRight.ToBitmap(), this.pbVideoSourceRight.Size);
                            this.pbVideoSourceRight.Refresh();
                        });
                    }
                    else
                    {
                        this.pbVideoSourceRight.Image = this.ResizeImage(this.frameColorRight.ToBitmap(), this.pbVideoSourceRight.Size);
                        this.pbVideoSourceRight.Refresh();
                    }
                }

                if (this.reald3DForm != null && this.reald3DForm.Visible && this.frameColorLeft != null && this.frameColorRight != null)
                {
                    this.reald3DForm.DrawLeft(this.frameColorLeft.ToBitmap());
                    this.reald3DForm.DrawRight(this.frameColorRight.ToBitmap());
                }

                if (this.anaglyphForm != null && this.anaglyphForm.Visible && this.anaglyphForm.Focused && this.frameColorLeft != null && this.frameColorRight != null)
                {
                    this.anaglyphForm.DrawImage(this.frameColorLeft.ToBitmap(), this.frameColorRight.ToBitmap());
                }

                if (this.matchForm != null && this.matchForm.Visible && this.matchForm.Focused && this.frameColorLeft != null && this.frameColorRight != null)
                {
                    this.matchForm.DrawImage(this.frameColorLeft.ToBitmap(), this.frameColorRight.ToBitmap());
                }

                if (this.enableDisparity)
                {
                    // TODO: Control this via new form. Delete enableDisparity.
                    //this.Triangulate();
                }

                this.syncFlag = true;
            }
        }

        #endregion

        #region MainForm

        /// <summary>
        /// Overide form closing event to release cameras
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.frameAcquirer.Stop();

            if (this.captureLeft != null)
            {
                this.captureLeft.Stop();
                //this.captureLeft.ImageGrabbed -= this.captureLeft_ImageGrabbed;
                this.captureLeft.Dispose();
            }

            if (this.captureRight != null)
            {
                this.captureRight.Stop();
                //this.captureRight.ImageGrabbed -= this.captureRight_ImageGrabbed;
                this.captureRight.Dispose();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosing(null);
        }

        #endregion

        #region Track Bars

        /// <summary>
        /// The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range
        /// Each time the slider moves the value is checked and made odd if even
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbSADWindow_Scroll(object sender, EventArgs e)
        {
            /*The matched block size. Must be an odd number >=1 . Normally, it should be somewhere in 3..11 range*/
            //This ensures only odd numbers are allowed from slider value
            if (trbSADWindow.Value % 2 == 0)
            {
                if (trbSADWindow.Value == trbSADWindow.Maximum) trbSADWindow.Value = trbSADWindow.Maximum - 2;
                else trbSADWindow.Value++;
            } 
        }

        /// <summary>
        /// This is maximum disparity minus minimum disparity. Always greater than 0. In the current implementation this parameter must be divisible by 16.
        /// Each time the slider moves the value is checked and made a factor of 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbDisparities_Scroll(object sender, EventArgs e)
        {

            if (trbDisparities.Value % 16 != 0)
            {
                //value must be divisable by 16
                if (trbDisparities.Value >= 152) trbDisparities.Value = 160;
                else if (trbDisparities.Value >= 136) trbDisparities.Value = 144;
                else if (trbDisparities.Value >= 120) trbDisparities.Value = 128;
                else if (trbDisparities.Value >= 104) trbDisparities.Value = 112;
                else if (trbDisparities.Value >= 88) trbDisparities.Value = 96;
                else if (trbDisparities.Value >= 72) trbDisparities.Value = 80;
                else if (trbDisparities.Value >= 56) trbDisparities.Value = 64;
                else if (trbDisparities.Value >= 40) trbDisparities.Value = 48;
                else if (trbDisparities.Value >= 24) trbDisparities.Value = 32;
                else trbDisparities.Value = 16;
            }
        }
        
        /// <summary>
        /// Maximum disparity variation within each connected component. If you do speckle filtering, set it to some positive value, multiple of 16. Normally, 16 or 32 is good enough.
        /// Each time the slider moves the value is checked and made a factor of 16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbSpeckleRange_Scroll(object sender, EventArgs e)
        {
            if (trbSpeckleRange.Value % 16 != 0)
            {
                //value must be divisable by 16
                //TODO: we can do this in a loop
                if (trbSpeckleRange.Value >= 152) trbSpeckleRange.Value = 160;
                else if (trbSpeckleRange.Value >= 136) trbSpeckleRange.Value = 144;
                else if (trbSpeckleRange.Value >= 120) trbSpeckleRange.Value = 128;
                else if (trbSpeckleRange.Value >= 104) trbSpeckleRange.Value = 112;
                else if (trbSpeckleRange.Value >= 88) trbSpeckleRange.Value = 96;
                else if (trbSpeckleRange.Value >= 72) trbSpeckleRange.Value = 80;
                else if (trbSpeckleRange.Value >= 56) trbSpeckleRange.Value = 64;
                else if (trbSpeckleRange.Value >= 40) trbSpeckleRange.Value = 48;
                else if (trbSpeckleRange.Value >= 24) trbSpeckleRange.Value = 32;
                else if (trbSpeckleRange.Value >= 8) trbSpeckleRange.Value = 16;
                else trbSpeckleRange.Value = 0;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Sets the state of fulldp in the StereoSGBM algorithm allowing full-scale 2-pass dynamic programming algorithm. 
        /// It will consume O(W*H*numDisparities) bytes, which is large for 640x480 stereo and huge for HD-size pictures. By default this is false
        /// </summary>
        private void btnFullDPState_Click(object sender, EventArgs e)
        {
            if (btnFullDPState.Text == "HH")
            {
                this.stereoMode = StereoSGBM.Mode.SGBM;
                btnFullDPState.Text = "SGBM";
            }
            else
            {
                this.stereoMode = StereoSGBM.Mode.HH;
                btnFullDPState.Text = "HH";
            }
        }

        #endregion

        #region Pictur Boxes

        private void pbVideoSourceLeft_Paint(object sender, PaintEventArgs e)
        {
            // Setup the graphics.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Red);

            e.Graphics.DrawString(String.Format("({0})", (string)this.pbVideoSourceLeft.Tag), font, brush, new Point(10, 10));
        }

        private void pbVideoSourceRight_Paint(object sender, PaintEventArgs e)
        {
            // Setup the graphics.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Red);

            e.Graphics.DrawString(String.Format("({0})", (string)this.pbVideoSourceRight.Tag), font, brush, new Point(10, 10));
        }

        #endregion

        #region Progres Form

        private void progresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.beginCalibrationProcess = false;
        }

        #endregion

        #region Gimble

        private void DisconnectFromGimble()
        {
            try
            {
                if (this.gimble != null && this.gimble.IsConnected)
                {
                    this.gimble.Disconnect();
                }
            }
            catch (Exception exception)
            {
                //this.AddLogRow(exception.ToString());
            }
        }

        private void ConnectToGimble()
        {
            try
            {
                this.gimble.OnMesage += this.gimble_OnMesage;
                this.gimble.Connect();
            }
            catch (Exception exception)
            {
                //this.AddLogRow(exception.ToString());
            }
        }

        private void gimble_OnMesage(object sender, MotionPlatform.Messages.MessageString e)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}

