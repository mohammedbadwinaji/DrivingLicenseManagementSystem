using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Licenses
{
    public class clsInternationalLicense
    {

        public static DataTable GetPersonLicneses(int personId)
        {
            return clsInternationalLicenseDataAccess.GetPersonLicenses(personId);
        }
    }
}
