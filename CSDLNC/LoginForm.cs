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
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CSDLNC
{
    public enum UserRole
    {
        Admin,
        Staff,
        Dentist
    }

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static string UserName = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=NLEETHUONG\\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "LOGIN";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Username", tbxUsername.Text);
                        command.Parameters.AddWithValue("@Password", tbxPassword.Text);
                        UserName=tbxUsername.Text;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userRole = reader["UserRole"].ToString().Trim();

                                switch (userRole)
                                {
                                    case "Admin":
                                        this.Hide();
                                        new HomeAdmin().Show();
                                        break;
                                    case "Staff":
                                        this.Hide();
                                        new HomeStaff().Show();
                                        Properties.Settings.Default.UserName = tbxUsername.Text;
                                        Properties.Settings.Default.PassWord = tbxPassword.Text;
                                        Properties.Settings.Default.Save();
                                        break;
                                    case "Dentist":
                                        this.Hide();
                                        Dentist dentist = new Dentist();
                                        dentist.Show();
                                        Properties.Settings.Default.UserName = tbxUsername.Text;
                                        Properties.Settings.Default.PassWord = tbxPassword.Text;
                                        Properties.Settings.Default.Save();
 
                                        break;
                                    case "InvalidInput":
                                        MessageBox.Show("Đăng nhập thất bại.\nTài khoản hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tbxPassword.Clear();
                                        tbxUsername.Clear();
                                        tbxUsername.Focus();
                                        break;
                                    case "UserNotFound":
                                        MessageBox.Show("Đăng nhập thất bại.\nTài khoản hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tbxPassword.Clear();
                                        tbxUsername.Clear();
                                        tbxUsername.Focus();
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        private void picSeen_Click(object sender, EventArgs e)
        {
            picSeen.Hide();
            picNoSeen.Show();
            tbxPassword.PasswordChar = '*';
        }

        private void picNoSeen_Click(object sender, EventArgs e)
        {
            picSeen.Show();
            picNoSeen.Hide();
            tbxPassword.PasswordChar = '\0';
        }

        private void tbxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbxPassword.Focus();
                e.Handled = true;
            }
        }
        private void tbxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
                btnLogin_Click(sender, e);
            }
        }

        private void btnCretaAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
           
        }


    }
}
