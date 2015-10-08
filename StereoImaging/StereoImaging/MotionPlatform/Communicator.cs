using StereoImaging.MotionPlatform.Messages;
using System;
using System.IO.Ports;
using System.Threading;

namespace StereoImaging.MotionPlatform
{
    /// <summary>
    /// 
    /// </summary>
    public class Communicator : IDisposable, ICommunicator
    {

        #region Variables

        /// <summary>
        /// Comunication port.
        /// </summary>
        protected SerialPort SerialPort;

        /// <summary>
        /// Comunication lock object.
        /// </summary>
        private Object requestLock = new Object();

        /// <summary>
        /// When is connected to the robot.
        /// </summary>
        private bool isConnected = false;

        #endregion

        #region Properties

        /// <summary>
        /// If the board is correctly connected.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }
        }

        public string PortName
        {
            get
            {
                return this.SerialPort.PortName;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Recieved command message.
        /// </summary>
        public event EventHandler<MessageString> OnMesage;

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Comunication port.</param>
        public Communicator(string portName)
        {
            // Save the port name.
            this.SerialPort = new SerialPort(portName);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~Communicator()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Add resources for disposing.
            }

            this.Disconnect();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Data recievce handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Wait ...
            Thread.Sleep(550);

            if (sender != null)
            {
                // Make serial port to get data from.
                SerialPort sp = (SerialPort)sender;

                if (sp == null)
                {
                    return;
                }
                try
                {
                    string inData = sp.ReadExisting();

                    if (this.OnMesage != null)
                    {
                        this.OnMesage(this, new MessageString(inData));
                    }

                    // Discart the duffer.
                    sp.DiscardInBuffer();
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Send request to the device.
        /// </summary>
        /// <param name="command"></param>
        protected void SendRequest(string command)
        {
            lock (this.requestLock)
            {
                try
                {
                    if (this.isConnected)
                    {
                        this.SerialPort.Write(command);
                    }
                }
                catch (Exception exception)
                {
                    this.isConnected = false;
                    // Reconnect.
                    this.Connect();
                }
            }
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Connetc to the serial port.
        /// </summary>
        public void Connect()
        {
            try
            {
                if (!this.isConnected)
                {
                    this.SerialPort.BaudRate = 9600;
                    this.SerialPort.DataBits = 8;
                    this.SerialPort.StopBits = StopBits.One;
                    this.SerialPort.Parity = Parity.None;
                    this.SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    this.SerialPort.Open();

                    this.isConnected = true;
                }
            }
            catch (Exception exception)
            {
                this.isConnected = false;
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect()
        {
            if (this.isConnected)
            {
                this.SerialPort.Close();
                this.isConnected = false;
            }
        }

        public void SendRawRequest(string command)
        {
            lock (this.requestLock)
            {
                try
                {
                    if (this.isConnected)
                    {
                        this.SerialPort.Write(command);

                        if (this.OnMesage != null)
                        {
                            this.OnMesage(this, new MessageString(command));
                        }

                    }
                }
                catch (Exception exception)
                {
                    this.isConnected = false;
                    // Reconnect.
                    this.Connect();
                }
            }
        }

        #endregion
    }
}
