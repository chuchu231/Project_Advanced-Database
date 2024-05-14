using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CSDLNC
{
    public partial class UC_TaiKhoan : UserControl
    {
        public UC_TaiKhoan()
        {
            InitializeComponent();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.FindForm().Hide();

            LoginForm lg = new LoginForm();
            lg.Show();
        }

    }
}
