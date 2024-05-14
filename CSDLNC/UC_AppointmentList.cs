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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSDLNC
{
    public partial class UC_AppointmentList : UserControl
    {
        public UC_AppointmentList()
        {
            InitializeComponent();
        }
        string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            DateTime mydate = dtpNgay.Value.Date + dtpGio.Value.TimeOfDay;
            string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu = "exec addAppointment @ID_BN = @ID_BN ,@ID_BS = @ID_NS ,@DATE = @DATE ,@ID_TK =@ID_TK  ,@ROOM =@ROOM ,@STATUS =@STATUS  ";
            string qu2 = "Select * from BOOKING";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_BN", txtboxIDBN.Text);
                    cmd.Parameters.AddWithValue("@ID_NS", cboxNS.Text);
                    cmd.Parameters.AddWithValue("@DATE", mydate);
                    cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = cboxStatus.Text.ToString();
                    //cmd.Parameters.AddWithValue("@STATUS",cboxStatus.Text);
                    cmd.Parameters.AddWithValue("@ID_TK", cboxTK.Text);
                    cmd.Parameters.AddWithValue("@ROOM", txtPhong.Text);

                    //cmd.Parameters.AddWithValue("@ID_TK", txIDTK.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        ///dataGridView2.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].


                    }
                    else { cx.Close(); }
                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {

                    //cmd.Parameters.AddWithValue("@ID_TK", txIDTK.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        guna2DataGridView1.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].


                    }
                    else { cx.Close(); }
                }
            }
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";


            string qu = " SELECT ID\r\nFROM dbo.DENTIST\r\nWHERE ID NOT IN (SELECT DENTISTID FROM dbo.BOOKING WHERE CAST(TIME AS DATE) = CAST(@DATE AS DATE)  AND DATEPART(HOUR,TIME) = DATEPART(HOUR,@HOUR) )\r\nAND ID NOT IN (SELECT ID FROM dbo.PERSONALSCHEDULE WHERE ID = dbo.DENTIST.ID AND CAST(DATETIME AS DATE) = CAST(@DATE AS DATE) AND DATEPART(HOUR,DATETIME) = DATEPART(HOUR,@HOUR)) ";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    /* cmd.Parameters.AddWithValue("@ID_BN", txtboxIDBN.Text);
                     cmd.Parameters.AddWithValue("@ID_NS", txtboxIDNS.Text);
                     cmd.Parameters.AddWithValue("@NGAY", dtpickNgay.Value);
                     cmd.Parameters.AddWithValue("@NOTE", txtboxGhiChu.Text);
                     cmd.Parameters.AddWithValue("@STATUS", txtboxStatus.Text);
                    ;*/

                    cmd.Parameters.AddWithValue("@DATE", dtpNgay.Value);
                    cmd.Parameters.AddWithValue("@HOUR", dtpGio.Value);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cboxNS.Items.Clear();
                    cboxTK.Items.Clear();
                    while (reader.Read())
                    {

                        cboxNS.Items.Add(reader[0].ToString());
                        cboxTK.Items.Add(reader[0].ToString());
                    }

                    cx.Close();
                }
            }
        }


        string ID_BOOK = "";
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID_BOOK = "";
            // Check if the cell is valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value of the selected cell
                var value = guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //MessageBox.Show(value.ToString());
                ID_BOOK = value.ToString();

            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //sua
            DateTime mydate = dtpNgay.Value.Date + dtpGio.Value.TimeOfDay;
            string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";

            string qu2 = "select * from BOOKING";
            string qu = "exec updateAppointment @ID_BN =@ID_BN  ,@ID_BS =@ID_NS ,@DATE= @DATE ,@ID_TK =@ID_TK ,@ROOM= @ROOM,@STATUS= @STATUS, @ID_BOOK= @ID_BOOK  ";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {

                    //cmd.Parameters.AddWithValue("@ID_BN", txtboxIDBN.Text);
                    //cmd.Parameters.AddWithValue("@ID_NS", cboxNS.Text);
                    cmd.Parameters.AddWithValue("@DATE", mydate);
                    cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar).Value = cboxStatus.Text;
                    // cmd.Parameters.AddWithValue("@ID_TK", cboxTK.Text);
                    cmd.Parameters.AddWithValue("@ROOM", txtPhong.Text);
                    cmd.Parameters.AddWithValue("@ID_BOOK", ID_BOOK);
                    cmd.Parameters.Add("@ID_BN", SqlDbType.Int).Value = int.Parse(txtboxIDBN.Text);
                    cmd.Parameters.Add("@ID_NS", SqlDbType.Int).Value = int.Parse(cboxNS.Text);
                    cmd.Parameters.Add("@ID_TK", SqlDbType.Int).Value = int.Parse(cboxTK.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cx.Close();
                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {


                    SqlDataReader reader2 = cmd.ExecuteReader();


                    if (reader2.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        guna2DataGridView1.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                    }
                    else { cx.Close(); }
                }
            }
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //xoa
            string qu2 = "select * from BOOKING";
            string qu = "Delete from BOOKING Where BOOKINGID = @ID_BOOK ";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {


                    cmd.Parameters.AddWithValue("@ID_BOOK", ID_BOOK);


                    SqlDataReader reader = cmd.ExecuteReader();
                    cx.Close();
                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {


                    SqlDataReader reader2 = cmd.ExecuteReader();


                    if (reader2.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        guna2DataGridView1.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                    }
                    else
                    {
                        guna2DataGridView1.DataSource = null;
                        cx.Close();
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string qu2 = "select * from BOOKING";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {


                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {


                    SqlDataReader reader2 = cmd.ExecuteReader();


                    if (reader2.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        guna2DataGridView1.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                    }
                    else
                    {
                        guna2DataGridView1.DataSource = null;
                        cx.Close();
                    }
                }
            }
        }
    }
}
