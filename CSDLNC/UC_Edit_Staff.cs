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

namespace CSDLNC
{
    public partial class UC_Edit_Staff : UserControl
    {
        public UC_Edit_Staff()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        public string IdText
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string LNameText
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string FNameText
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string PosText
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public string UsernameText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string DOBText
        {
            get { return dateTimePicker1.Text; }
            set { dateTimePicker1.Text = value; }
        }
        public string PhoneNumberText
        {
            get { return txtPhoneNumber.Text; }
            set { txtPhoneNumber.Text = value; }
        }
        public string AddrText
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = textBox4.Text;
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            string pos = comboBox1.Text;
            string dob = dateTimePicker1.Text;
            string phone = txtPhoneNumber.Text;
            string addr = richTextBox1.Text;
            string uname = textBox1.Text;
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_STAFF " + id + ", '" + fname + "', '" + lname + "', '" + phone + "', '" + dob + "', '" + addr + "', '" + pos + ", '" + uname + "'");
            //MessageBox.Show("Edited sucessfully.");
            conn.Close();
        }
    }
}
