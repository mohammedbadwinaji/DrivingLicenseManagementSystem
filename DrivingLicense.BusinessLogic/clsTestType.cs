using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsTestType
    {
        public int TestTypeID { get; private set; } 
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get;set; }

        private clsTestType(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeDataAccess.GetAllTestTypes();
        }

        public static clsTestType FindByID(int testTypeID)
        {
            string testTypeTitle, testTypeDescription;
            decimal testTypeFees;
            
            bool isExists =  clsTestTypeDataAccess.GetByID(testTypeID,out testTypeTitle,out testTypeDescription,out testTypeFees);
            if (!isExists)
            {
                return null;
            }
            return new clsTestType(testTypeID, testTypeTitle, testTypeDescription, testTypeFees);
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(TestTypeTitle))
            {
                errorMessage += "Title Required";
            }
            if (string.IsNullOrEmpty(TestTypeDescription))
            {
                errorMessage += "Desciption Required";
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return false;
            }
            return clsTestTypeDataAccess.Update(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees, out errorMessage);
        }

    }
}
