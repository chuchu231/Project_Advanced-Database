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

namespace CSDLNC
{
    public partial class UC_AddTreatment : UserControl
    {
        public UC_AddTreatment()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=NLEETHUONG\SQLLEETHUONG;Initial Catalog=CSDLNC04;Integrated Security=True";
        string sql;
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_AddTreatment_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UC_AddTooth uc = new UC_AddTooth();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
