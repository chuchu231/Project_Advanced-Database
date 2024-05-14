using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class UC_Staff : UserControl
    {
        public UC_Staff()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=NLEETHUONG\\SQLLEETHUONG;Initial Catalog=CSDLNC05;Integrated Security=True");
        private void populateGrid()
        {
            conn.Open();
            string query = "SELECT ID, FIRSTNAME, LASTNAME, PHONENUMBER, DOB, ADDRESS FROM STAFF";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder cd = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UC_AddNewStaff uc = new UC_AddNewStaff();
            MainControl.addUserControl(uc, Content);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////iDDataGridViewTextBoxColumn

            string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM DENTIST WHERE ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", iDDataGridViewTextBoxColumn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UC_Edit_Staff uc = new UC_Edit_Staff();
                    uc.IdText = reader["ID"].ToString();
                    uc.LNameText = reader["FIRSTNAME"].ToString();
                    uc.FNameText = reader["LASTNAME"].ToString();
                    uc.DOBText = reader["DOB"].ToString();
                    uc.PhoneNumberText = reader["PHONENUMBER"].ToString();
                    uc.AddrText = reader["ADDRESS"].ToString();
                    uc.PosText = "Nhân viên";
                    MainControl.addUserControl(uc, Content);
                }
            }

            // Close the reader and the connection
            reader.Close();
            conn.Close();
        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {

        }
    }
}
