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
    public partial class UC_Treatment : UserControl
    {
        public UC_Treatment()
        {
            InitializeComponent();
        }
        string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";


        private void UC_Treatment_Load(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();

            if (currentForm is Dentist)
            {
                txtboxMaBN.Text = UC_Patient.PatientID;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string ID_BN = txtboxMaBN.Text;
            string sqlconstr = "";
            string qu = "exec PlanListByPA @IDBN = @ID_BN ";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_BN", ID_BN);
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

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID_Plan = "";
            // Check if the cell is valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the value of the selected cell
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //MessageBox.Show(value.ToString());
                ID_Plan = value.ToString();

            }

            string sqlconstr = "";
            string qu2 = "exec TeethByPlan @IDPlan = @ID_Plan";
            string qu = "exec PlanDetailByPlan @IDPlan = @ID_Plan";
            string qu3 = "exec MedByPlan @ID_Plan = @ID_Plan";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_Plan", ID_Plan);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataGridView2.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView2.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                        tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1) % tabControl1.TabCount;

                    }
                    else { cx.Close(); }
                }
                if(cx.State==ConnectionState.Closed ) cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_Plan", ID_Plan);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataGridView5.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView5.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                        //tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1) % tabControl1.TabCount;

                    }
                    else { cx.Close(); }
                }
                if (cx.State == ConnectionState.Closed) cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu3, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_Plan", ID_Plan);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        dataGridView3.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView3.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].
                        //tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1) % tabControl1.TabCount;

                    }
                    else { cx.Close(); }
                }

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu = "exec addTreatmentPlan @ID_BN = @ID_BN, @ID_NS = @ID_NS, @NGAY = @NGAY, @ID_TK = @ID_TK,@NOTE = @NOTE, @STATUS = @STATUS";
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
                    cmd.Parameters.Add("@ID_BN", SqlDbType.Int).Value = int.Parse(txtboxIDBN.Text);
                    //cmd.Parameters.AddWithValue("@NOTE", txtboxGhiChu.Text);
                    // cmd.Parameters.AddWithValue("@STATUS", txtboxStatus.Text);
                    cmd.Parameters.Add("@NOTE", SqlDbType.NVarChar,50).Value = txtboxGhiChu.Text;
                    cmd.Parameters.AddWithValue("@NGAY", dtpickNgay.Value);
                    cmd.Parameters.Add("@STATUS", SqlDbType.NVarChar, 50).Value = txtboxStatus.Text;

                    cmd.Parameters.Add("@ID_NS", SqlDbType.Int).Value = int.Parse(txtboxIDNS.Text);
                    cmd.Parameters.Add("@ID_TK", SqlDbType.Int).Value = int.Parse(txIDTK.Text);
                    //cmd.Parameters.AddWithValue("@ID_TK", txIDTK.Text);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            //string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu = "exec addTreatmentDetail  @ID_Plan= @ID_Plan ,@ID_TEETH= @ID_TEETH ,@FEE= @FEE ,@DES =@DES";
            string qu2 = "exec TeethByPlan @IDPlan = @ID_Plan";

            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_Plan", txtboxIDPlan.Text);
                    cmd.Parameters.AddWithValue("@ID_TEETH", txtboxTeeth.Text);
                    cmd.Parameters.AddWithValue("@FEE", txtboxPrice.Text);
                   // cmd.Parameters.AddWithValue("@DES", txtboxDes.Text
                    cmd.Parameters.Add("@DES", SqlDbType.NVarChar,50).Value = txtboxDes.Text;

                    SqlDataReader reader = cmd.ExecuteReader();
                
                    cx.Close();
                   


                   
                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu2, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_Plan", txtboxIDPlan.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView5.DataSource = dase.Tables["test_table"].DefaultView;
                        // dataGridView1.Rows[1].


                    }
                    else { cx.Close(); }




                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu3 = "exec MedByPlan @ID_PLAN = @ID_PLAN";

            string qu = "exec addMedPre @ID_MED= @ID_MED ,@ID_PLAN= @ID_PLAN ,@AMOUNT= @AMOUNT ,@DES= @DES";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_MED", txtboxMED.Text);
                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);
                    cmd.Parameters.AddWithValue("@AMOUNT", txtboxAmount.Text);
                    // cmd.Parameters.AddWithValue("@DES", txtboxDES_MED.Text);
                    cmd.Parameters.Add("@DES", SqlDbType.NVarChar).Value = txtboxIDNS.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    cx.Close();


                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu3, cx))
                {
                    
                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);
                   

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dataGridView3.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView3.DataSource = dase.Tables["test_table"].DefaultView;



                    }
                    else { cx.Close(); }


                }
            }
        }

        

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";

            string qu3 = "exec MedByPlan @ID_PLAN = @ID_PLAN";

            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu = "exec editMedByPlan @ID_MED= @ID_MED, @ID_PLAN= @ID_PLAN, @DES= @DES, @AMOUNT= @AMOUNT";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_MED", txtboxMED.Text);
                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);
                    cmd.Parameters.AddWithValue("@AMOUNT", txtboxAmount.Text);
                    cmd.Parameters.AddWithValue("@DES", txtboxDES_MED.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    cx.Close();


                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu3, cx))
                {

                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dataGridView3.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView3.DataSource = dase.Tables["test_table"].DefaultView;

                    }
                    else { cx.Close(); }

                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //string sqlconstr = "Data Source=LAPTOP-M7E40EH8;Initial Catalog=CSDLNC05;Integrated Security=True";
            string qu3 = "exec MedByPlan @ID_PLAN = @ID_PLAN";

            //string qu2 = "SELECT t.TEETHNAME AS Răng, t.SIDE AS Mặt\r\nFROM dbo.TREATMENTPLAN tp \r\nLEFT JOIN dbo.TREATMENTDETAIL td ON td.PLANID = tp.PLANID\r\nLEFT JOIN dbo.TEETH t ON t.TEETHID = td.TEETH\r\nWHERE tp.PLANID = @ID_Plan";
            string qu = "exec deleteMedPre @ID_PLAN = @ID_PLAN, @ID_MED = @ID_MED";
            using (SqlConnection cx = new SqlConnection(sqlconstr))
            {

                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu, cx))
                {
                    cmd.Parameters.AddWithValue("@ID_MED", txtboxMED.Text);
                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);
                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    cx.Close();


                }
                cx.Open();
                using (SqlCommand cmd = new SqlCommand(qu3, cx))
                {

                    cmd.Parameters.AddWithValue("@ID_PLAN", txtboxPLAN_MED.Text);


                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dataGridView3.DataSource = null;
                        SqlDataAdapter dt = new SqlDataAdapter(cmd);
                        cx.Close();
                        DataSet dase = new DataSet();
                        dt.Fill(dase, "test_table");
                        dataGridView3.DataSource = dase.Tables["test_table"].DefaultView;



                    }
                    else { cx.Close(); }


                }
            }
        }

        private void txtboxMaBN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            SqlConnection cx = new SqlConnection(sqlconstr);
            cx.Open();
            SqlCommand cmd = new SqlCommand(@"SELECT PLANID FROM TREATMENTPLAN WHERE STATUS = N'KẾ HOẠCH'", cx);
            SqlDataReader reader = cmd.ExecuteReader();

            List<int> tmp = new List<int>(); // Use a List<int> instead of an array

            if (reader != null)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0); // Assuming the ID is in the first column, adjust index if needed
                    tmp.Add(id);
                }
                reader.Close(); // Don't forget to close the reader when you're done
            }

            SqlCommand cmd1 = new SqlCommand(@"SELECT PLANID FROM TREATMENTPLAN WHERE STATUS = N'ĐÃ HỦY'", cx);
            SqlDataReader reader1 = cmd.ExecuteReader();

            List<int> tmp1 = new List<int>(); // Use a List<int> instead of an array

            if (reader1 != null)
            {
                while (reader1.Read())
                {
                    int id = reader1.GetInt32(0); // Assuming the ID is in the first column, adjust index if needed
                    tmp1.Add(id);
                }
                reader1.Close(); // Don't forget to close the reader when you're done
            }

            SqlCommand cmd2 = new SqlCommand(@"SELECT PLANID FROM TREATMENTPLAN WHERE STATUS = N'ĐÃ HOÀN THÀNH'", cx);
            SqlDataReader reader2 = cmd.ExecuteReader();

            List<int> tmp2 = new List<int>(); // Use a List<int> instead of an array

            if (reader1 != null)
            {
                while (reader1.Read())
                {
                    int id = reader2.GetInt32(0); // Assuming the ID is in the first column, adjust index if needed
                    tmp2.Add(id);
                }
                reader1.Close(); // Don't forget to close the reader when you're done
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                for(int i = 0; i < count; i++)
                {
                    if (tmp.Contains(Convert.ToInt32(row.Cells[i].Value)))
                    {
                        row.Cells[i].Style.BackColor = Color.LightSkyBlue;
                    }
                    if (tmp1.Contains(Convert.ToInt32(row.Cells[i].Value)))
                    {
                        row.Cells[i].Style.BackColor = Color.Orange;
                    }
                    if (tmp2.Contains(Convert.ToInt32(row.Cells[i].Value)))
                    {
                        row.Cells[i].Style.BackColor = Color.LightGreen;
                    }
                }
            }

            cx.Close();
        }
    }
}