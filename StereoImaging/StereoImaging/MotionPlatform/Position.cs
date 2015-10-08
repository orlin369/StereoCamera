using System;

namespace StereoImaging.MotionPlatform
{
    [Serializable]
    public class Position : EventArgs
    {
        public float Pan = 0.0f;
        public float Tilt = 0.0f;

        public Position()
        {

        }

        public Position(float pan, float tilt)
        {
            this.Pan = pan;
            this.Tilt = tilt;
        }
    }
}
