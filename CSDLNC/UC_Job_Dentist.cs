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
    public partial class UC_Job_Dentist : UserControl
    {
        public UC_Job_Dentist()
        {
            InitializeComponent();
        }
        // where id=@id_dentist 

        string connectionString = "Data Source=NLEETHUONG\\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True";
        string sql;
        SqlConnection connection;
        SqlCommand cmd;
        
        public void show()
        { 
            try
            {

                // Replace "your_connection_string" with the actual connection string for your database
                string sql = @"SELECT P.PERSONALSCHEDULEID AS N'Mã', D.LASTNAME + ' ' + D.FIRSTNAME AS N'Họ Tên', 
                                CONVERT(DATE, [P].[DATETIME]) AS N'Ngày', CONVERT(TIME, [P].[DATETIME]) AS N'Giờ' 
                        FROM PERSONALSCHEDULE P JOIN DENTIST D ON P.ID=D.ID 
                        WHERE D.USERNAME = @username and  CONVERT(DATE, [P].[DATETIME]) = @txtDateChoose";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        DateTime tmp = DateTime.Parse(tbxDateChoose.Text);
                        cmd.Parameters.AddWithValue("@txtDateChoose", tmp);
                        cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                        

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            dataGridView1.Controls.Clear();
            panel1.Controls.Clear();

            UC_Container.Controls.Add(uc);
            uc.BringToFront();

        }

        // delete
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "")
            {
                cmd = new SqlCommand("exec delete_per_schedule @username = @fillname, @time=@txtTime, @date = @txtDate", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@fillname", txtUserName.Text);
                cmd.Parameters.AddWithValue("@txtTime", txtTime.Text);
                DateTime tmp = DateTime.Parse(tbxDateChoose.Text);
                cmd.Parameters.AddWithValue("@txtDateChoose", tmp);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Xóa thành công!", "Xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
                show();
                //txtID.Text = null;

            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void UC_Container_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "")
            {

                cmd = new SqlCommand("exec add_per_schedule @username = @fillname, @time=@txtTime, @date = @txtDate", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@fillname", txtUserName.Text);
                cmd.Parameters.AddWithValue("@txtTime", txtTime.Text);
                DateTime tmp = DateTime.Parse(tbxDateChoose.Text);
                cmd.Parameters.AddWithValue("@txtDate", tmp);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Thêm thành công!", "Thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
                show();
                //txtID.Text = null;

            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Job_Dentist_Load(object sender, EventArgs e)
        {
            txtUserName.Text = LoginForm.UserName;
            connection = new SqlConnection(connectionString);
            show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "")
            {
                cmd = new SqlCommand("exec update_per_schedule @username = @fillname, @time=@txtTime, @date = @txtDate", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@fillname", txtUserName.Text);
                cmd.Parameters.AddWithValue("@txtTime", txtTime.Text);
                DateTime tmp = DateTime.Parse(tbxDateChoose.Text);
                cmd.Parameters.AddWithValue("@txtDate", tmp);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Cập nhật thành công!", "Cập nhật dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Refresh();
                show();
                //txtID.Text = null;

            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
