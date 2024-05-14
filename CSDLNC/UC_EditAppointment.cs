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
    public partial class UC_EditAppointment : UserControl
    {
        SqlConnection conn = new SqlConnection("Data source =.; initial catalog = CSDLNC04;integrated security=true");
        public string IDText
        {
            get { return guna2TextBox1.Text; }
            set { guna2TextBox1.Text = value; }
        }
        public string PatientText
        {
            get { return guna2TextBox1.Text; }
            set { guna2TextBox1.Text = value; }
        }
        public string DentistText
        {
            get { return guna2ComboBox1.Text; }
            set { guna2ComboBox1.Text = value; }
        }
        public string PhoneText
        {
            get { return guna2TextBox2.Text; }
            set { guna2TextBox2.Text = value; }
        }
        public string DateText
        {
            get { return guna2DateTimePicker2.Text; }
            set { guna2DateTimePicker2.Text = value; }
        }
        public string TimeText
        {
            get { return guna2ComboBox3.Text; }
            set { guna2ComboBox3.Text = value; }
        }
        public string RoomText
        {
            get { return guna2TextBox4.Text; }
            set { guna2TextBox4.Text = value; }
        }
        public string StatusText
        {
            get { return guna2ComboBox4.Text; }
            set { guna2ComboBox4.Text = value; }
        }
        public UC_EditAppointment()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = guna2TextBox1.Text;
            string dentist = guna2ComboBox1 .Text;
            string date = guna2DateTimePicker2.Text;
            string time = guna2ComboBox3.Text;
            string room = guna2TextBox4.Text;
            string status = guna2ComboBox4.Text;
            SqlCommand cmd = new SqlCommand("EXEC UPDATE_BOOKING " + id + ", '" + dentist + "', '" + date + "', '" + time + "', '" + room + "', '" + status + "'");
            //MessageBox.Show("Edited sucessfully.");
            conn.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string id = guna2TextBox1.Text;
            SqlCommand cmd = new SqlCommand("DELETE FROM BOOKING WHERE BOOKINGID = " + id);
            //MessageBox.Show("Deleted sucessfully.");
            conn.Close();
        }
    }
}
