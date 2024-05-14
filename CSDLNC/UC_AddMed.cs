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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSDLNC
{
    public partial class UC_AddMed : UserControl
    {
        public UC_AddMed()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string name = guna2TextBox1.Text;
            string quant = guna2TextBox3.Text;
            string price = guna2TextBox5.Text;
            string status = guna2ComboBox1.Text;
            string desc = guna2TextBox2.Text;
            SqlCommand cmd = new SqlCommand("EXEC ADD_MEDICATION '" + name + "', " + quant + ", " + price + ", '" + status + "'");
            //MessageBox.Show("Added sucessfully.");
            conn.Close();
        }
    }
}
