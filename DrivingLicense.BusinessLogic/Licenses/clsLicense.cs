using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Licenses
{
    public class clsLicense
    {
        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public enLicenseClass LicenseClass { get; set; }

        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; private set; }
        public enLicenseIssueReason IssueReason { get; private set; }
        public int CreatedByUserID { get; set; }
        
        public bool IsDetained { get; private set; }
        public clsDriver DriverInfo { get; private set; }


        public string GetLicenseClassName
        {
            get
            {
                return clsLicenseClassDataAccess.GetLicenseClassNameByID((int)this.LicenseClass);
            }
        }

        public string GetFullName
        {
            get
            {
                if(this.DriverInfo == null)
                {
                    return null;
                }
                return  this.DriverInfo.PersonInfo.FirstName + " " +
                        this.DriverInfo.PersonInfo.SecondName + " " +
                        this.DriverInfo.PersonInfo.ThirdName + " " +
                        this.DriverInfo.PersonInfo.LastName + " ";
            }
        }
        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.PersonID = -1;
            this.IssueDate = DateTime.Today;
            this.ExpirationDate = DateTime.Today;
            this.Notes = null;
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enLicenseIssueReason.FisrtTime;
            this.CreatedByUserID = -1;
            this.LicenseClass = enLicenseClass.None;
            this.DriverInfo = null;
            this.IsDetained = false;
        }

        private clsLicense(int licenseID, int applicationID, enLicenseClass licenseClass, int driverID, int personID, DateTime issueDate, DateTime expirationDate, string notes, decimal paidFees, bool isActive, enLicenseIssueReason issueReason, int createdByUserID,bool isDetained, clsDriver driverInfo)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            LicenseClass = licenseClass;
            DriverID = driverID;
            PersonID = personID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            IsDetained = isDetained;
            DriverInfo = driverInfo;
        }

        public bool IssueFirstTime
            (
                out string errorMessage
            )
        {
            errorMessage = string.Empty;
            if(this.LicenseID != -1)
            {
                errorMessage = "You Already Issued This License";
                return false;
            }
            if(this.PersonID == -1)
            {
                errorMessage = "The License Must be Linked With Person";
                return false;
            }
            if(this.ApplicationID == -1)
            {
                errorMessage = "The License Must be Linked With Application";
                return false;
            }
            decimal licenseIssueFees = clsApplicationType.GetFees(enApplicationType.NewLocalDrivingLicenseService);
            if (this.PaidFees < licenseIssueFees)
            {
                errorMessage = "You Must Pay All Fees";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Issue This License";
                return false;
            }
            if(this.LicenseClass == enLicenseClass.None)
            {
                errorMessage = "License Must By Linked With License Class";
                return false;
            }
            clsDriver driver = clsDriver.FindByPersonID(PersonID);
            
            if(driver == null)
            {
                driver = new clsDriver();

                driver.PersonID = this.PersonID;
                driver.CreatedByUserID = this.CreatedByUserID;
                bool isDriverInserted =driver.AddNew(out errorMessage);
                if (!isDriverInserted)
                {
                    return false;
                }
            } 
            DriverID = driver.DriverID;

            this.LicenseID =  clsLicenseDataAccess.Insert
                (
                    this.ApplicationID,this.DriverID,(int)this.LicenseClass,this.Notes,
                    this.PaidFees,(int)enLicenseIssueReason.FisrtTime,this.CreatedByUserID
                    
                );

            if(this.LicenseID != -1)
            {
                clsApplicationDataAccess.Update(this.ApplicationID,(int) enApplicationStatus.Completed);
            }

            return this.LicenseID != -1;
        }


        public static clsLicense FindByID(int licenseId)
        {
            int applicationId, driverId, licenseClassId, issueReason, createdByUserId;
            DateTime issueDate, expirationDate;
            string notes;
            decimal paidFees;
            bool isActive,isDetained;

            bool isFound = clsLicenseDataAccess.GetByID
                (
                    licenseId,out applicationId, out driverId,
                    out licenseClassId,out issueDate,out expirationDate,
                    out notes,out paidFees,out isActive,
                    out issueReason,out createdByUserId,out isDetained
                );

            if (!isFound)
            {
                return null;
            }

            clsDriver driverInfo = clsDriver.FindByID(driverId);

            return new clsLicense
                (
                    licenseId, applicationId,(enLicenseClass) licenseClassId, driverId,
                    driverInfo.PersonID, issueDate, expirationDate, notes, paidFees,
                    isActive,(enLicenseIssueReason) issueReason, createdByUserId,isDetained, driverInfo
                );
        }
    }
}
