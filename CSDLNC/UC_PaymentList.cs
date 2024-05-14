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
    public partial class UC_PaymentList : UserControl
    {
        public UC_PaymentList()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView1.CurrentRow.Selected = true; // click vào line thì sẽ link và pass data qua paymentdetail 
            UC_Payment_Detail uc = new UC_Payment_Detail();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
