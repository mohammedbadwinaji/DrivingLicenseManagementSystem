using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Licenses
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get;set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDriver DriverInfo { get; private set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.Today;
            this.ExpirationDate= DateTime.Today;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.DriverInfo = null;
        }
        private clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID, clsDriver driverInfo)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            DriverInfo = driverInfo;
        }

        public static DataTable GetPersonLicneses(int personId)
        {
            return clsInternationalLicenseDataAccess.GetPersonLicenses(personId);
        }

        public static clsInternationalLicense FindByLocalLicenseID(int localLicenseId)
        {
            int internationalLicenseId, applicationId, driverId, createdByUserId;
            DateTime issueDate, expirationDate;
            bool isActive;
            bool isFound = clsInternationalLicenseDataAccess.GetByLocalLicenseId
                (
                    localLicenseId,out internationalLicenseId,out applicationId,out driverId,
                    out issueDate,out expirationDate , out isActive,out createdByUserId
                );

            if (!isFound)
            {
                return null;
            }

            clsDriver driverInfo = clsDriver.FindByID(driverId);

            return new clsInternationalLicense
                (
                internationalLicenseId,applicationId,driverId,localLicenseId,
                issueDate,expirationDate,isActive,createdByUserId,driverInfo
                );
        }
        public static clsInternationalLicense FindByID(int internationalLicenseId)
        {

            int applicationId, driverId, createdByUserId,issuedUsingLicenseId;
            DateTime issueDate, expirationDate;
            bool isActive;
            bool isFound = clsInternationalLicenseDataAccess.GetByID
                (
                    internationalLicenseId,out applicationId,out driverId,out issuedUsingLicenseId,
                    out issueDate,out expirationDate,out isActive,out createdByUserId
                );
            if (!isFound)
            {
                return null;
            }

            clsDriver driverInfo = clsDriver.FindByID(driverId);

            return new clsInternationalLicense
                (
                    internationalLicenseId, applicationId, driverId,
                    issuedUsingLicenseId, issueDate, expirationDate,
                    isActive, createdByUserId, driverInfo
                );
        }

        public bool IssueFirstTime(out string errorMessage)
        {
            if(this.ApplicationID == -1)
            {
                errorMessage = "No Application For Issue International License";
                return false;
            }
            if(this.DriverID == -1)
            {
                errorMessage = "The License Must Be Issued For Driver";
                return false;
            }
            if (this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Issue This License";
                return false;
            }

            errorMessage = string.Empty;
            clsLicense license = clsLicense.FindByID(this.IssuedUsingLocalLicenseID);
            if(license == null)
            {
                errorMessage = $"No Local License With ID {this.IssuedUsingLocalLicenseID}";
                return false;
            }

            if(license.LicenseClass != Models.enLicenseClass.Class3)
            {
                errorMessage = "Only International License With Class 3 Can Be issued ";
                return false;
            }
            if (!license.IsActive)
            {
                errorMessage = "Local License Is Not Active";
                return false;
            }
            if(license.ExpirationDate < DateTime.Today)
            {
                errorMessage = "Local License Has Been Expired";
                return false;
            }


            clsInternationalLicense internatinoalLicense = clsInternationalLicense.FindByLocalLicenseID(this.IssuedUsingLocalLicenseID);

            if(internatinoalLicense != null)
            {
                if (internatinoalLicense.IsActive)
                {
                    errorMessage = $"Person Already Has An Active International License With ID {internatinoalLicense.InternationalLicenseID}"; 
                    return false;
                }
            }

            this.InternationalLicenseID =  clsInternationalLicenseDataAccess.Insert
                (
                    this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                    this.CreatedByUserID
                );

            if(this.InternationalLicenseID != -1)
            {
                clsApplicationDataAccess.Update(ApplicationID,(int)enApplicationStatus.Completed);
            }

            return this.InternationalLicenseID != -1;
        }



    }
}
