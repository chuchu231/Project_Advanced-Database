using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class UC_LichNhaSi : UserControl
    {
        #region Peoperties
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion
        public UC_LichNhaSi()
        {
            InitializeComponent();
            LoadMatrix();

        }


        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.margin, oldBtn.Location.Y);
                    btn.Click += btn_Click;
                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldBtn.Location.Y + Cons.dateButtonHeight) };
            }

            SetDefaultDate();
 
        }
        private void addUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMatrix.Controls.Clear();
            panel4.Controls.Clear();
            panel3.Controls.Clear();

            panel1.Controls.Add(uc);
            uc.BringToFront();

        }
        void btn_Click(object sender, EventArgs e)
        {
            Form currentForm = this.FindForm();

            if (currentForm is HomeAdmin)
            {
                HomeAdmin homeAdmin = (HomeAdmin)currentForm;
                UC_Job uc = new UC_Job();
                addUserControl(uc);
            }
            else if (currentForm is Dentist)
            {
                Dentist homeAdmin = (Dentist)currentForm;
                UC_Job_Dentist uc = new UC_Job_Dentist();
                string textBoxValue = ((Button)sender).Text;
                DateTime selectedDate = dtpkDate.Value;
                string monthYearString = selectedDate.ToString("MM/yyyy");
                string datechoose = textBoxValue + "/" + monthYearString;
                uc.tbxDateChoose.Text = datechoose.ToString();
                addUserControl(uc);
            }
            else if (currentForm is HomeStaff)
            {
                HomeStaff homeAdmin = (HomeStaff)currentForm;
                UC_LichNhaSi_Staff uc = new UC_LichNhaSi_Staff();
                addUserControl(uc);
            }

        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30; ;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;

            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Aqua;
                }
                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }

            

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        }

        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnToDay_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void UC_LichNhaSi_Load(object sender, EventArgs e)
        {

        }

        private void pnlMatrix_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}