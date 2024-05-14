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
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string ID_NS = textBox1.Text;
            string startdate = NgayDau.Value.ToString();
            string endate = NgayCuoi.Value.ToString();

            string qu2 = "exec DentistTreatmentByDate @ID_NS = @ID_NS,@START=@START,@END=@END";
            string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            string qu = "exec DentistBookingByDate @ID_NS = @ID_NS,@START=@START,@END=@END ";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_NS", ID_NS);
                    cmd.Parameters.AddWithValue("@START", startdate);
                    cmd.Parameters.AddWithValue("@END", endate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView1.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                    }
                    else { cx.Close(); }
                }
                if (cx.State == ConnectionState.Closed) { cx.Open(); }
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_NS", ID_NS);
                    cmd.Parameters.AddWithValue("@START", startdate);
                    cmd.Parameters.AddWithValue("@END", endate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView2.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                    }
                    else { cx.Close(); }
                }

            }
        }
    }
}
