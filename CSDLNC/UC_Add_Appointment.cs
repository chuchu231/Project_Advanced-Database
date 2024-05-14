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
using System.Xml.Linq;

namespace CSDLNC
{
    public partial class UC_Add_Appointment : UserControl
    {
        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        public UC_Add_Appointment()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string patient = guna2TextBox1.Text;
            string dentist = guna2TextBox3.Text;
            string date = guna2DateTimePicker2.Text;
            string time = guna2TextBox5.Text;
            string room = guna2TextBox4.Text;
            string status = guna2ComboBox4.Text;
            SqlCommand cmd = new SqlCommand("EXEC ADD_BOOKING '" + patient + "', '" + dentist + "', '" + date + "', '" + time + "', '" + room + "', '" + status + "'");
            MessageBox.Show("Added sucessfully.");
            conn.Close();
        }

        private void UC_Add_Appointment_Load(object sender, EventArgs e)
        {

        }
    }
}
