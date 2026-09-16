using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.Presentation.applications;
using DrivingLicense.Presentation.users;

namespace DrivingLicense.Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new frmTest());
            //return;
            bool keepRunning = true;

            while (keepRunning) {
                frmLogin frmLogin = new frmLogin();

                Application.Run(frmLogin);

                if (frmLogin.DialogResult != DialogResult.OK) {
                    keepRunning = false;
                    break;
                }


                frmMain frmMain = new frmMain();
                Application.Run(frmMain);

                if (frmMain.DialogResult != DialogResult.Retry)
                {
                    keepRunning = false;
                }
            }
        }
    }
}
