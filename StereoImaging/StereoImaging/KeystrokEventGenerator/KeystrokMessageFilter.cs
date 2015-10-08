using System;
using System.Windows.Forms;

namespace GUI.InputMethods.KeystrokEventGenerator
{
    public class KeystrokMessageFilter : System.Windows.Forms.IMessageFilter
    {

        #region Events

        /// <summary>
        /// Calls when user need to open applicationConfiguration manager form.
        /// </summary>
        public event EventHandler<EventArgs> OnOpenReald3D;

        /// <summary>
        /// Calls when user need to close applicationConfiguration manager form.
        /// </summary>
        public event EventHandler<EventArgs> OnOpenAnaglyph;

        /// <summary>
        /// Close the application when we need.
        /// </summary>
        public event EventHandler<EventArgs> OnExitForm;

        /// <summary>
        /// Raice when full screen needed.
        /// </summary>
        public event EventHandler<EventArgs> OnFullScreen;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public KeystrokMessageFilter()
        {
        
        }

        #endregion

        #region Implementation of IMessageFilter

        /// <summary>
        /// Filter of the key strokes.
        /// </summary>
        /// <param name="m">Message argument.</param>
        /// <returns></returns>
        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg == 256 /*0x0100*/))
            {
                switch (((int)m.WParam) | ((int)Control.ModifierKeys))
                {
                    case KeyCombinations.OPEN_REALD3D:
                        if(this.OnOpenReald3D != null)
                        {
                            this.OnOpenReald3D(this, new EventArgs());
                        }

                        break;

                    case KeyCombinations.OPEN_ANAGLYPH:
                        if (this.OnOpenAnaglyph != null)
                        {
                            this.OnOpenAnaglyph(this, new EventArgs());
                        }

                        break;

                    case KeyCombinations.EXIT_FORM:
                        if (this.OnExitForm != null)
                        {
                            this.OnExitForm(this, new EventArgs());
                        }

                        break;

                    case KeyCombinations.FULL_SCREEN:
                        if (this.OnFullScreen != null)
                        {
                            this.OnFullScreen(this, new EventArgs());
                        }

                        break;
                    //This does not work. It seems you can only check single character along with CTRL and ALT.
                    //case (int)(Keys.Control | Keys.Alt | Keys.K | Keys.P):
                    //    MessageBox.Show("You pressed ctrl + alt + k + p");
                    //    break;
                }
            }
            return false;
        }

        #endregion

    }
}
