using System;

namespace StereoImaging
{
    /// <summary>
    /// Structure to Store Information about Video Devices
    /// </summary>
    class VideoDevice
    {

        #region Variables

        /// <summary>
        /// Name of device.
        /// </summary>
        public string Name;

        /// <summary>
        /// Device index.
        /// </summary>
        public int Index;

        /// <summary>
        /// Device identifier.
        /// </summary>
        public Guid ClassID;

        #endregion

        #region Construcotr

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">Device index</param>
        /// <param name="name">Device name</param>
        /// <param name="classId">Identifyer</param>
        public VideoDevice(int index, string name, Guid classId = new Guid())
        {
            this.Index = index;
            this.Name = name;
            this.ClassID = classId;
        }

        #endregion

        #region ToString()

        /// <summary>
        /// Represent the Device as a String.
        /// </summary>
        /// <returns>
        /// The string representation of this device.
        /// </returns>
        public override string ToString()
        {
            return String.Format("[{0} {1}:{2}]", this.Index, this.Name, this.ClassID);
        }

        #endregion

    }
}
