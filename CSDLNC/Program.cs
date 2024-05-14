using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string username;
            string password;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
           // Application.Run(new HomeAdmin());
            //Application.Run(new HomeStaff());
            //Application.Run(new Dentist());
            //Application.Run(new HomeStaff());
            //Application.Run(new HomeStaff());
           // Application.Run(new Dentist());
        }
    }
}
