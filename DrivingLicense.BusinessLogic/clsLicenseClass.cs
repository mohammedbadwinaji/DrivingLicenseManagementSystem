using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; private set; }
        public string ClassDescription { get; private set; }
        public byte MinimumAllowedAge { get; private set; }
        public byte DefaultValidityLength { get; private set; }
        public decimal ClassFess { get; set; }

        private clsLicenseClass(int licenseClassID, string className, string classDescription, byte minimumAllowedAge, byte defaultValidityLength, decimal classFess)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFess = classFess;
        }

        public static string GetLicenseName(enLicenseClass licenseClass)
        {
            return clsLicenseClassDataAccess.GetLicenseClassNameByID((int)licenseClass);
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassDataAccess.GetAllLicenseClasses();
        }

        public static clsLicenseClass FindByID(int licenseClassId)
        {
            string className, classDescription;
            byte minimumAllowedAge, defaultValidityLength;
            decimal classFees;
            bool isFound = clsLicenseClassDataAccess.GetByID(licenseClassId, out className, out classDescription, out minimumAllowedAge, out defaultValidityLength, out classFees);

            if (!isFound)
            {
                return null;
            }

            return new clsLicenseClass(licenseClassId, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(string.IsNullOrWhiteSpace(ClassName))
            {
                errorMessage += "Class Name cannot be empty.\n";
            }
            if (string.IsNullOrWhiteSpace(ClassDescription))
            {
                errorMessage += "Class Description cannot be empty.\n";
            }
            if(MinimumAllowedAge < 18 )
            {
                errorMessage += "Minimum Allowed Age must be at least 18 years.\n";
            }
            if(DefaultValidityLength <= 0)
            {
                errorMessage += "Default Validity Length cannot be zero or less.\n";
            }
            if(ClassFess < 0)
            {
                errorMessage += "Class Fees cannot be negative.\n";
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return false;
            }
            bool isUpdated = clsLicenseClassDataAccess.Update(LicenseClassID, ClassFess);
            if (!isUpdated)
            {
                errorMessage += "Server Error!";
                return false;
            }
            return true;
        }
    }
}
