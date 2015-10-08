using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StereoImaging.MotionPlatform
{
    public class Gimble : Communicator
    {

        #region Events

        public event EventHandler<Position> OnNewPosition;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">Name</param>
        public Gimble(string portName) : base(portName)
        {
            this.OnMesage += Gimble_OnMesage;
        }

        #endregion

        private void Gimble_OnMesage(object sender, Messages.MessageString e)
        {
            string message = e.Message;
        }

        public void GetPosition()
        {
            this.SendRequest(ProtocolStrigifier.GetPosition());
        }

        public void SetPosition(Position position)
        {
            this.SendRequest(ProtocolStrigifier.ToCommand(position));
        }


    }
}
