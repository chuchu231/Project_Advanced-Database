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
    public partial class UC_Patient_Info : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=NLEETHUONG\\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True");
        public string IdText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
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
        public string PaidFeeText
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string TotalFeeText
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string OverallText
        {
            get { return richTextBox2.Text; }
            set { richTextBox2.Text = value; }
        }
        public string AllergyText
        {
            get { return richTextBox3.Text; }
            set { richTextBox3.Text = value; }
        }
        public UC_Patient_Info()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = int.Parse(textBox1.Text);
            string lname = textBox2.Text;
            string fname = textBox3.Text;
            string dob = dateTimePicker1.Text;
            string phone = txtPhoneNumber.Text;
            string addr = richTextBox1.Text;
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_PATIENT '" + fname + "', '" + lname + "', '" + dob + "', '" + phone + "', '" + addr + "'");
            MessageBox.Show("Edited sucessfully.");
            conn.Close();
        }
    }
}
