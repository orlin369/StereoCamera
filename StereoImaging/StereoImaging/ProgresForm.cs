using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StereoImaging
{
    public partial class ProgresForm : Form
    {
        public ProgresForm()
        {
            InitializeComponent();
        }

        public void SetValue(int value)
        {
            if (this.prbProcess.InvokeRequired)
            {
                this.prbProcess.BeginInvoke((MethodInvoker)delegate()
                {
                    this.prbProcess.Value = value;
                });
            }
            else
            {
                this.prbProcess.Value = value;
            }

            if (this.lblValue.InvokeRequired)
            {
                this.lblValue.BeginInvoke((MethodInvoker)delegate()
                {
                    this.lblValue.Text = String.Format("{0}%", value);
                });
            }
            else
            {
                this.lblValue.Text = String.Format("{0}%", value);
            }
        }
    }
}
