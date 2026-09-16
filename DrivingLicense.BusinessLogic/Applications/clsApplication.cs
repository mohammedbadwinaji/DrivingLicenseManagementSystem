using System;
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.BusinessLogic
{
    public abstract class clsApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get;  set; }
        public string ApplicantFullName { get; protected set; }
        public DateTime ApplicationDate { get; protected set; }
        public enApplicationType ApplicationType { get; protected set; }
        public string ApplicationTypeTitle { get; protected set; }
        public enApplicationStatus ApplicationStatus { get; protected set; }
        public string ApplicationStatusTitle { get; protected set; }
        public DateTime LastStatusDate { get; protected set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public string CreatedByUserName { get; protected set; }

        protected clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicantFullName = string.Empty;
            ApplicationDate = DateTime.Now;
            ApplicationType = enApplicationType.None;
            ApplicationTypeTitle = string.Empty;
            ApplicationStatus = enApplicationStatus.New;
            ApplicationStatusTitle = string.Empty;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            CreatedByUserName = string.Empty;
        }

        protected clsApplication(
            int applicationID,
            int applicantPersonID,
            string applicantFullName,
            DateTime applicationDate,
            enApplicationType applicationType,
            string applicationTypeTitle,
            enApplicationStatus applicationStatus,
            string applicationStatusTitle,
            DateTime lastStatusDate,
            decimal paidFees,
            int createdByUserID,
            string createdByUserName
        )
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicantFullName = applicantFullName;
            ApplicationDate = applicationDate;
            ApplicationType = applicationType;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationStatus = applicationStatus;
            ApplicationStatusTitle = applicationStatusTitle;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserName = createdByUserName;
        }
    }
}
