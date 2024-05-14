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
    public partial class UC_Patient : UserControl
    {
        
        public UC_Patient()
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
        public static string PatientID = "";
        public void show()
        {
            guna2DataGridView1.DataSource = null; // Gỡ bỏ nguồn dữ liệu hiện tại
            guna2DataGridView1.Rows.Clear(); 
            connection.Open();
            sql = @"SELECT ID AS N'Mã', LASTNAME + ' ' +  FIRSTNAME  AS N'Họ Tên', CONVERT(DATE,DOB) AS N'Ngày Sinh', PHONENUMBER AS 'Số điện thoại', ADDRESS AS 'Địa chỉ' FROM PATIENT";
            cmd = new SqlCommand(sql);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            connection.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtFName.Text!="" && txtLName.Text!="" && txtPhoneNumber.Text != "")
            {
                cmd = new SqlCommand("insert into patient(PHONENUMBER, FIRSTNAME, LASTNAME, DOB) values(@phonenumber,@firstname,@lastname,@DOB)", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@phonenumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@firstname", txtFName.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLName.Text);
                cmd.Parameters.AddWithValue("@DOB", dateDOB.Value.Date.ToString());
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Thêm thành công\n Thêm điều trị cho bệnh nhân");
                show();

                /* UC_AddTreatment uc = new UC_AddTreatment();
                 uc.Dock = DockStyle.Fill;
                 this.Controls.Clear();
                 this.Controls.Add(uc);
                 uc.BringToFront();*/
            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ","Error",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }

        private void UC_Patient_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(chuoiketnoi);
            show();
        }

     

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView1.CurrentRow.Selected = true; // click vào line thì sẽ link và pass data qua paymentlist 
            PatientID = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            UC_Treatment uc = new UC_Treatment();
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
            
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                cmd = new SqlCommand("delete patient where ID=@id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Xóa thành công!","Xóa dữ liệu", MessageBoxButtons.OK,MessageBoxIcon.Information);
                show();
                txtID.Text= null;
                
            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtFName.Text != "" && txtLName.Text != "" && txtPhoneNumber.Text != "")
            {
                cmd = new SqlCommand("update patient set firstname = @firstname, lastname = @lastname, phonenumber = @phonenumber where ID=@id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Cập nhật thành công!", "Cập nhật dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                show();
                txtID.Text = null;

            }
            else
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dateDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPhoneNumber.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateDOB.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

        }
    }
}
