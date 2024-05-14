using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
namespace CSDLNC
{



    public partial class HomeAdmin : Form
    {


        // mng them cai nay theo ten sever o may minh roi cmt code cu lai nhe
        string strCon = @"Data Source=LAPTOP-M7E40EH8;Initial Catalog = test5; Integrated Security = True";
        SqlConnection sqlCon = null;
        //public Form1();

        public HomeAdmin()
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

   
        private void btnTaiKhoan_Click_1(object sender, EventArgs e)
        {
            UC_TaiKhoan uc=new UC_TaiKhoan();
            addUserControl(uc);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UC_ThongKe uc = new UC_ThongKe();
            addUserControl(uc);

           
        }

    

        private void UC_Container_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLichCaNhan_Click(object sender, EventArgs e)
        {
            UC_LichNhaSi uc = new UC_LichNhaSi();
            addUserControl(uc);
        }

        private void btnDSHoaDon_Click(object sender, EventArgs e)
        {
            UC_DSHoaDon uc = new UC_DSHoaDon();
            addUserControl(uc);
            
        }

        private void btnLinkDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("ket noi csdl thanh cong");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

       
        private void btnBenhNhan_Click(object sender, EventArgs e)
        {
            UC_Patient uc = new UC_Patient();
            addUserControl(uc);
            /*UC_Staff uc = new UC_Staff();
            addUserControl(uc);*/
            
        }

        private void btnNhaSi_Click_1(object sender, EventArgs e)
        {
            UC_Dentist uc = new UC_Dentist();
            addUserControl(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            UC_Staff uc = new UC_Staff();
            addUserControl(uc);
        }

        private void btnMed_Click(object sender, EventArgs e)
        {
            UC_EditMed uc = new UC_EditMed();
            addUserControl(uc);
        }

        private void lbDentalCare_Click(object sender, EventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
