using System;

namespace StereoImaging
{
    /// <summary>
    /// It's purpose is for synchonizing stereo camera.
    /// </summary>
    class StereoSync
    {

        #region Variables

        /// <summary>
        /// Ready left flag.
        /// </summary>
        private bool readyLeft = false;

        /// <summary>
        /// Ready right flag.
        /// </summary>
        private bool readyRight = false;

        /// <summary>
        /// Enable synchronization.
        /// </summary>
        private bool enableSync = false;

        #endregion

        #region Properties

        /// <summary>
        /// Left camera flag.
        /// </summary>
        public bool ReadyLeft
        {
            get
            {
                return this.readyLeft;
            }
            set
            {
                if (!this.readyLeft)
                {
                    this.readyLeft = true;
                }
                this.CheckSync();
            }
        }

        /// <summary>
        /// Right camera flag.
        /// </summary>
        public bool ReadyRight
        {
            get
            {
                return this.readyRight;
            }
            set
            {
                if (!this.readyRight)
                {
                    this.readyRight = true;
                }
                this.CheckSync();
            }
        }

        /// <summary>
        /// Enable synchronization.
        /// </summary>
        public bool EnableSync
        {
            get
            {
                return this.enableSync;
            }
            set
            {
                this.enableSync = value;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Event handler.
        /// </summary>
        public event EventHandler<EventArgs> Sync;

        #endregion

        #region Private Methiods

        /// <summary>
        /// Check if they are synced.
        /// </summary>
        private void CheckSync()
        {
            if (this.readyLeft && this.readyRight && this.enableSync)
            {
                this.readyLeft = false;
                this.readyRight = false;

                if (this.Sync != null)
                {
                    this.Sync(this, null);
                }
            }
        }

        #endregion

    }
}
