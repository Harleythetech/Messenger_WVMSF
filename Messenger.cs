using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Messenger : Form
    {
        public Messenger()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Check if the close was triggered by the user or the OS
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Terminate the entire application
            }
        }
    }
}
