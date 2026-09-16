using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic;

namespace DrivingLicense.Presentation
{
    internal class clsSettings
    {
        public static readonly string storageDirectory = Path.Combine(GetSolutionDirectory(), "images");

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

        public static clsUser CurrentLoggedInUser = null;
    }
}
