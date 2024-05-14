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
    public partial class UC_Add_Patient : UserControl
    {
        public UC_Add_Patient()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            string lname = textBox2.Text;
            string fname = textBox3.Text;
            string dob = dateTimePicker1.Text;
            string phone = txtPhoneNumber.Text;
            string addr = richTextBox1.Text;
            SqlCommand cmd = new SqlCommand("EXEC ADD_PATIENT '" + fname + "', '" + lname + "', '" + dob + "', '" + phone + "', '" + addr + "'");
            //MessageBox.Show("Added sucessfully.");
            conn.Close();
        }
    }
}
