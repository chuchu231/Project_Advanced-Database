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
    public partial class UC_DentistList : UserControl
    {
        public UC_DentistList()
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
            sql = @"SELECT ID AS N'Mã', LASTNAME + ' ' +  FIRSTNAME  AS N'Họ Tên', CONVERT(DATE,DOB) AS N'Ngày Sinh', PHONENUMBER AS 'Số điện thoại', ADDRESS AS 'Địa chỉ' FROM DENTIST";
            cmd = new SqlCommand(sql);
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            connection.Close();
        }

        private void UC_DentistList_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(chuoiketnoi);
            show();
        }

        

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                // Replace "your_connection_string" with the actual connection string for your database
                sql = @"SELECT ID AS N'Mã', LASTNAME + ' ' +  FIRSTNAME  AS N'Họ Tên', CONVERT(DATE,DOB) AS N'Ngày Sinh', 
                                PHONENUMBER AS 'Số điện thoại', ADDRESS AS 'Địa chỉ'   
                        FROM DENTIST
                        WHERE LASTNAME + ' ' +  FIRSTNAME = @txtFname";
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@txtFname", txtFname.Text);
                        

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            guna2DataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
           
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
