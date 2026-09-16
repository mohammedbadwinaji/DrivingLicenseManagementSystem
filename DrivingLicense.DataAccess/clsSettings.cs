using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    internal class clsSettings
    {
        public static readonly string connectionString = "Server=.;Database=DVLD;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa,Password=123456";
        public static readonly string imageStorageDirectory = Path.Combine(GetSolutionDirectory(), "PeopleImages");
        public static readonly string rememberMeStoragePath = Path.Combine(GetSolutionDirectory(), "files","remeberme.txt");


        private static string GetSolutionDirectory()
        {
            DirectoryInfo currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (currentDir != null)
            {
                if (currentDir.GetFiles("*.sln").Any())
                {
                    return currentDir.FullName;
                }
                currentDir = currentDir.Parent;
            }
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
