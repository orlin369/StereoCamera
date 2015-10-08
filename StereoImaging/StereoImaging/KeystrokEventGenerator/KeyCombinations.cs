using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.InputMethods.KeystrokEventGenerator
{
    class KeyCombinations
    {
        /// <summary>
        /// Open applicationConfiguration manager.
        /// </summary>
        public const int OPEN_REALD3D = (int)(Keys.Control | Keys.Shift | Keys.D);

        /// <summary>
        /// Open applicationConfiguration manager.
        /// </summary>
        public const int OPEN_ANAGLYPH = (int)(Keys.Control | Keys.Shift | Keys.A);

        /// <summary>
        /// Enter full screen.
        /// </summary>
        public const int FULL_SCREEN = (int)(Keys.Control | Keys.Shift | Keys.F);

        /// <summary>
        /// Configuration manager key combination.
        /// </summary>
        public const int EXIT_FORM = (int)(Keys.Escape);

        /*
        /// <summary>
        /// Copy
        /// </summary>
        public const int CTRL_C = (int)(Keys.Control | Keys.C);

        /// <summary>
        /// Cut
        /// </summary>
        public const int CTRL_X = (int)(Keys.Control | Keys.X);
        
        /// <summary>
        /// Paste
        /// </summary>
        public const int CTRL_V = (int)(Keys.Control | Keys.V);

        /// <summary>
        /// Arow up
        /// </summary>
        public const int AROW_UP = (int)Keys.Up;
        */
    }
}
