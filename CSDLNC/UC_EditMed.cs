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
    public partial class UC_EditMed : UserControl
    {
        public UC_EditMed()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        public string IdText
        {
            get { return guna2TextBox4.Text; }
            set { guna2TextBox4.Text = value; }
        }
        public string NameText
        {
            get { return guna2TextBox1.Text; }
            set { guna2TextBox1.Text = value; }
        }
        public string QuantText
        {
            get { return guna2TextBox3.Text; }
            set { guna2TextBox3.Text = value; }
        }
        public string PriceText
        {
            get { return guna2TextBox5.Text; }
            set { guna2TextBox5.Text = value; }
        }
        public string StatusText
        {
            get { return guna2ComboBox1.Text; }
            set { guna2ComboBox1.Text = value; }
        }
        public string DescText
        {
            get { return guna2TextBox2.Text; }
            set { guna2TextBox2.Text = value; }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = guna2TextBox4.Text;
            string name = guna2TextBox1.Text;
            string quant = guna2TextBox3.Text;
            string price = guna2TextBox5.Text;
            string status = guna2ComboBox1.Text;
            string desc = guna2TextBox2.Text;
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_MEDICAITON " + id + ", '" + name + "', " + quant + ", " + price + ", '" + desc + "', '" + status + "'");
            MessageBox.Show("Edited sucessfully.");
            conn.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = guna2TextBox4.Text;
            SqlCommand cmd = new SqlCommand("DELETE FROM MEDICATION WHERE MEDICAITONID = " + id);
            //MessageBox.Show("Deleted sucessfully.");
            conn.Close();
        }
    }
}
