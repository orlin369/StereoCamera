using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StereoImaging.MotionPlatform
{
    class ProtocolStrigifier
    {
        public static string ToCommand(Position position)
        {
            Int16 pan = Convert.ToInt16(position.Pan);
            Int16 tilt = Convert.ToInt16(position.Tilt);

            return String.Format("SETP,P:{0:D4},T:{1:D4}", pan, tilt);
        }

        public static string GetPosition()
        {
            return "GETP";
        }


    }
}
