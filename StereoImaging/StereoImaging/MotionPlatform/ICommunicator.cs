using StereoImaging.MotionPlatform.Messages;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace StereoImaging.MotionPlatform
{
    public interface ICommunicator
    {
        #region Events

        /// <summary>
        /// Recieved command message.
        /// </summary>
        event EventHandler<MessageString> OnMesage;

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Connetc to the serial port.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnect
        /// </summary>
        void Disconnect();

        void SendRawRequest(string command);

        #endregion
    }
}
