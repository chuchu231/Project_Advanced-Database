using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    class MainControl
    {
        public static void addUserControl(System.Windows.Forms.Control uc, System.Windows.Forms.Control content)
        {
            content.BringToFront();
            content.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            uc.Focus();

            content.Controls.Add(uc);

        }
    }
}
