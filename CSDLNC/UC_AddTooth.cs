using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class UC_AddTooth : UserControl
    {
        public UC_AddTooth()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UC_AddTreatment uc = new UC_AddTreatment();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UC_Complete_Plan uc = new UC_Complete_Plan();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
