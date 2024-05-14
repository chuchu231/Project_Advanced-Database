using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class UC_MedList : UserControl
    {
        public UC_MedList()
        {
            InitializeComponent();
        }
        /*SqlConnection conn = new SqlConnection("Data Source=DESKTOP-KD5EUDQ;Initial Catalog=CSDLNC05;Integrated Security=True");
        private void populateGrid()
        {
            conn.Open();
            string query = "SELECT * FROM MEDICATION";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder cd = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guna2DataGridView2.DataSource = ds.Tables[0];

            conn.Close();
        }*/
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
            sql = @"SELECT MEDICATIONID AS N'Mã', MEDICATIONNAME AS N'Tên thuốc', Description as N'Mô tả', QUANTITYINSTOCK AS 'Số lượng tồn' FROM MEDICATION";
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

        private void UC_MedList_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(chuoiketnoi);
            show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                // Replace "your_connection_string" with the actual connection string for your database
                sql = @"SELECT MEDICATIONID AS N'Mã', MEDICATIONNAME AS N'Tên thuốc', Description as N'Mô tả', QUANTITYINSTOCK AS 'Số lượng tồn' 
                        FROM MEDICATION
                        WHERE MEDICATIONNAME = @txtname";
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@txtname", txtMedName.Text);


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
