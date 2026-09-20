using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsDriver
    {
       

        public int DriverID { get; private set; }
        public int PersonID { get;  set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; private set; }

        public clsPerson PersonInfo { get; private set; }
        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate, clsPerson personInfo)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            PersonInfo = personInfo;
        }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();
        }
        public static clsDriver FindByID(int driverId)
        {
            int personId, createdByUserId;
            DateTime createdDate;

         bool isFound =  clsDriverDataAccess.GetByID
                (
                    driverId, out personId, out createdByUserId, out createdDate
                );

            if (!isFound)
            {
                return null;
            }

            clsPerson personInfo = clsPerson.FindById(personId);

            return new clsDriver
                (
                    driverId, personId, createdByUserId, createdDate, personInfo
                );
        }
        public static clsDriver FindByPersonID(int personId)
        {
            int driverId,createdByUserId;
            DateTime createdDate;
            bool isFound = clsDriverDataAccess.GetByPersonID
                (
                personId,out driverId,out createdByUserId,out createdDate
                );

            if (!isFound)
            {
                return null;
            }

            clsPerson personInfo = clsPerson.FindById(personId);
            return new clsDriver
                (
                    driverId,personId,createdByUserId,createdDate,personInfo
                );
        }

        internal bool AddNew
            (
                out string errorMessage
            )
        {
            errorMessage = string.Empty;
            if(this.DriverID != -1)
            {
                errorMessage = "Driver Already Exists";
                return false;
            }
            if(this.PersonID == -1)
            {
                errorMessage = "Person Is Required";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Created THis Driver";
                return false;
            }

            this.DriverID = clsDriverDataAccess.Insert
                (
                    this.PersonID, this.CreatedByUserID
                );

            return this.DriverID != -1;
        }
    }
}
