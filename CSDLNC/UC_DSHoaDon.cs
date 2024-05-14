using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace CSDLNC
{
    public partial class UC_DSHoaDon : UserControl
    {
        public UC_DSHoaDon()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            UC_Container.Controls.Clear();
            UC_Container.Controls.Add(uc);
            uc.BringToFront();

        }
        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            UC_EditInvoice uc = new UC_EditInvoice();
            addUserControl(uc);
        }

        private void dgvInvoiceDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            UC_SearchInvoice uc = new UC_SearchInvoice();
            addUserControl(uc);
        }

        private void dgvInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbxDSHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
