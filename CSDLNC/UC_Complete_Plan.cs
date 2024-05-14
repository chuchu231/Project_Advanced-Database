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
    public partial class UC_Complete_Plan : UserControl
    {
        public UC_Complete_Plan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UC_AddTooth uc = new UC_AddTooth();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            UC_Patient uc = new UC_Patient();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
