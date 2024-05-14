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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CSDLNC
{
    public partial class Dentist : Form
    {
        public Dentist()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            UC_Container.Controls.Clear();
            UC_Container.Controls.Add(uc);
            uc.BringToFront();
        }
        private void UC_Container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            UC_Patient uc = new UC_Patient();
            addUserControl(uc);
        }

        private void Dentist_Load(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            UC_TaiKhoan uc = new UC_TaiKhoan();

            string Username = Properties.Settings.Default.UserName;
            string Password = Properties.Settings.Default.PassWord;
            
            DataTable dataTable = GetUserData(Username, Password);
            uc.lbTTUserID.Text = dataTable.Rows[0]["ID"].ToString();
            uc.lbTTUsername.Text = dataTable.Rows[0]["USERNAME"].ToString();
            uc.lbTTHoTen.Text = dataTable.Rows[0]["LASTNAME"].ToString() + dataTable.Rows[0]["FIRSTNAME"].ToString();
            uc.lbTTNgaySinh.Text = dataTable.Rows[0]["DOB"].ToString();
            uc.lbTTDiaChi.Text = dataTable.Rows[0]["ADDRESS"].ToString();
            addUserControl(uc);

        }

        private void btnLichCaNhan_Click(object sender, EventArgs e)
        {
            UC_LichNhaSi uc = new UC_LichNhaSi();
            addUserControl(uc);
        }

        private void btnMed_Click(object sender, EventArgs e)
        {
            UC_MedList uc = new UC_MedList();
            addUserControl(uc);
        }

        private void btnLichHen_Click(object sender, EventArgs e)
        {
            UC_AddAppointment uc = new UC_AddAppointment();
            addUserControl(uc);
        }

        private void btnNhaSi_Click(object sender, EventArgs e)
        {
            UC_DentistList uc = new UC_DentistList();
            addUserControl(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_StaffList uc = new UC_StaffList();
            addUserControl(uc);
        }
        private DataTable GetUserData(string username, string password)
        {
            string chuoiketnoi = @"Data Source=NLEETHUONG\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True";
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("FindUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@InputUsername", username);
                        cmd.Parameters.AddWithValue("@InputPassword", password);


                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return dataTable;

        }

    }
}
