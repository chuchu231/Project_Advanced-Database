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
    public partial class UC_AddJob : UserControl
    {
        public UC_AddJob()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            guna2Panel2.Controls.Clear();

            guna2Panel2.Controls.Add(uc);
            uc.BringToFront();

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Job_Dentist uc = new UC_Job_Dentist();
            addUserControl(uc);
        }
    }
}
