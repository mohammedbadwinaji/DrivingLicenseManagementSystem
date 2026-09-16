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
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; private set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }
        private clsApplicationType(int applicationTypeID, string applicationTypeTitle, decimal applicationTypeFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationTypeFees = applicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }
        public static clsApplicationType FindByID(int applicationTypeID) {
            string applicationTypeTitle;
            decimal applicationTypeFees;
           bool isExists=  clsApplicationTypeDataAccess.GetByID(applicationTypeID, out applicationTypeTitle, out applicationTypeFees);

            if (!isExists)
            {
                return null;
            }

            return new clsApplicationType(applicationTypeID, applicationTypeTitle, applicationTypeFees);    
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(ApplicationTypeTitle))
            {
                errorMessage += "Title Must Contains Value"; 
                return false;
            }
            if(errorMessage != string.Empty)
            {
                return false;
            }

            bool isUpdated = clsApplicationTypeDataAccess.Update(ApplicationTypeID,ApplicationTypeTitle, ApplicationTypeFees, out errorMessage);

            return isUpdated;
        }


        public static decimal GetFees(enApplicationType applicationType)
        {
            string applicationTypeTitle;
            decimal applicationTypeFees;
            clsApplicationTypeDataAccess.GetByID((int)applicationType, out applicationTypeTitle, out applicationTypeFees);

            return applicationTypeFees;
        }
    }
}
