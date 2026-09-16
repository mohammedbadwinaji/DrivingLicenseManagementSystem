using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsRemeberMe
    {
        internal static bool doNotRemeber()
        {
            return clsRemeberMeDataAccess.Delete();
        }
        internal static bool remeber(string username , string password)
        {
            return clsRemeberMeDataAccess.Save(username, password);
        }

        public static stCredentials getStoredData()
        {
            stCredentials credentials = new stCredentials();
            clsRemeberMeDataAccess.GetStoredCredentials(out credentials.UserName,out credentials.Password);
            return credentials;
        }
      
    }
}
