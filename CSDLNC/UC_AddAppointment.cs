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
    public partial class UC_AddAppointment : UserControl
    {
        public UC_AddAppointment()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=NLEETHUONG\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True";
        string sql;
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        int i = 0;

        

        public void show()
        {
            guna2DataGridView1.Refresh();
            connection.Open();
            sql = @"EXEC SELECT_BOOKING";
            cmd = new SqlCommand(sql);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            connection.Close();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_AddAppointment_Load(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();
            if (currentForm is Dentist) txtDentist.Text = LoginForm.UserName;
            connection = new SqlConnection(chuoiketnoi);
            show();
        }

        // lọc theo bác sĩ
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();
            if (currentForm is Dentist)
            {
                try
                {
                    // Assuming 'connection' is declared and initialized elsewhere in your code
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // Use a using statement to ensure proper disposal of SqlCommand and SqlDataAdapter
                    using (SqlCommand cmd = new SqlCommand("search_booking_dentist_forDentist @username= @fillname", connection))
                    {
                        DataTable dt = new DataTable();

                        // Use parameters to avoid SQL injection and improve security
                        cmd.Parameters.AddWithValue("@fillname", txtDentist.Text);

                        // Use SqlDataAdapter to fill DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                            guna2DataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed, even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                try
                {
                    // Assuming 'connection' is declared and initialized elsewhere in your code
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    // Use a using statement to ensure proper disposal of SqlCommand and SqlDataAdapter
                    using (SqlCommand cmd = new SqlCommand("exec search_booking_dentist_forAdmandStaff @name= @fillname", connection))
                    {
                        DataTable dt = new DataTable();

                        // Use parameters to avoid SQL injection and improve security
                        cmd.Parameters.AddWithValue("@fillname", txtDentist.Text);

                        // Use SqlDataAdapter to fill DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                            guna2DataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed, even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
     

           
        }

        // lọc theo bệnh nhân
        private void guna2Button2_Click(object sender, EventArgs e)
        {
         

            try
            {
                // Assuming 'connection' is declared and initialized elsewhere in your code
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Use a using statement to ensure proper disposal of SqlCommand and SqlDataAdapter
                using (SqlCommand cmd = new SqlCommand("exec search_booking_patient @name= @fillname", connection))
                {
                    DataTable dt = new DataTable();

                    // Use parameters to avoid SQL injection and improve security
                    cmd.Parameters.AddWithValue("@fillname", txtPatient.Text);

                    // Use SqlDataAdapter to fill DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        guna2DataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming 'connection' is declared and initialized elsewhere in your code
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Use a using statement to ensure proper disposal of SqlCommand and SqlDataAdapter
                using (SqlCommand cmd = new SqlCommand("exec search_booking_room @room = @fillroom", connection))
                {
                    DataTable dt = new DataTable();

                    // Use parameters to avoid SQL injection and improve security
                    cmd.Parameters.AddWithValue("@fillroom", txtRoom.Text);

                    // Use SqlDataAdapter to fill DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                        guna2DataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed, even if an exception occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
