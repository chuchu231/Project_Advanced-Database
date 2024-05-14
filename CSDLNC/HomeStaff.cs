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
    public partial class HomeStaff : Form
    {
        public HomeStaff()
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

        private void btnLichHen_Click(object sender, EventArgs e)
        {
            UC_AppointmentList uc = new UC_AppointmentList();
            addUserControl(uc);
        }

        private void btnNhaSi_Click(object sender, EventArgs e)
        {
            UC_Dentist uc = new UC_Dentist();
            addUserControl(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_Staff uc = new UC_Staff();
            addUserControl(uc);
        }

        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            UC_Patient uc = new UC_Patient();
            addUserControl(uc);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UC_ThongKe uc = new UC_ThongKe();
            addUserControl(uc);
        }

        private void btnLichCaNhan_Click(object sender, EventArgs e)
        {
            UC_LichNhaSi uc = new UC_LichNhaSi();
            addUserControl(uc);
        }

        private void btnMed_Click(object sender, EventArgs e)
        {
            UC_EditMed uc = new UC_EditMed();
            addUserControl(uc);
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {
            UC_DSHoaDon uc = new UC_DSHoaDon();
            addUserControl(uc);
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

        private void btnHoSoBenhAn_Click(object sender, EventArgs e)
        {
            UC_Treatment uc = new UC_Treatment();
            addUserControl(uc);
        }
        private DataTable GetUserData(string username, string password)
        {
            string chuoiketnoi = "Data Source=DESKTOP-KD5EUDQ;Initial Catalog=CSDLNC05;Integrated Security=True";
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
