using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsPerson
    {
        private enum enMode
        {
            AddNew,
            Edit
        }
        private enMode _Mode;
        public int PersonId { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get;set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public byte Gendor {  get; set; }
        public string Address { get; set; } 
        public string Phone { get;set;}
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        public clsCountry CountryInfo { get; private set; }


        public string GetFullName
        {
            get
            {
                return  this.FirstName + " " +
                        this.SecondName + " " +
                        this.ThirdName + " " +
                        this.LastName + " ";
            }
        }
        public clsPerson()
        {
            this.PersonId = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = null;
            this.CountryInfo = null;
        }

        private clsPerson
            (
            int personId, string firstName, string secondName, 
            string thirdName, string lastName, string nationalNo,
            DateTime dateOfBirth, byte gendor, string address,
            string phone, string email, int nationalityCountryID,
            string imagePath, clsCountry countryInfo
            )
        {
            PersonId = personId;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNo = nationalNo;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            CountryInfo = countryInfo;
            _Mode = enMode.Edit;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }

        public static clsPerson FindByNationalNo(string nationalNo)
        {
            int personId, nationalityCountryId;
            string firstName, secondName, thirdName, lastName, phone, email, address, imagePath;
            DateTime dateOfBirth;
            byte gendor;
            bool isPersonExists = clsPersonDataAccess.GetPersonByNationalNo(nationalNo, out personId, out firstName, out secondName, out thirdName, out lastName, out dateOfBirth, out gendor, out phone, out email, out nationalityCountryId, out address, out imagePath);
            if (isPersonExists)
            {
                clsCountry countryInfo = clsCountry.FindById(nationalityCountryId);
                return new clsPerson
                    (
                        personId, firstName, secondName, thirdName, lastName,
                        nationalNo, dateOfBirth, gendor, address, phone, email, nationalityCountryId,
                        imagePath, countryInfo
                    );
            }
            return null;
        }
        public static clsPerson FindById(int personId)
        {
            string firstName, secondName, thirdName, lastName, nationalNo, phone, email, address, imagePath;
            DateTime dateOfBirth;
            byte gendor;
            int nationalityCountryId;
            bool isPersonExists = clsPersonDataAccess.GetPersonByID(personId, out firstName, out secondName, out thirdName, out lastName, out nationalNo, out dateOfBirth, out gendor, out phone, out email, out nationalityCountryId, out address, out imagePath);

            if (isPersonExists)
            {
                clsCountry countryInfo = clsCountry.FindById(nationalityCountryId);
                return new clsPerson
                    (
                        personId, firstName, secondName, thirdName, lastName,
                        nationalNo, dateOfBirth, gendor, address, phone, email , nationalityCountryId,
                        imagePath,countryInfo
                    );

            }


            return null;
        }


        public bool _AddNew(out string errorMessage)
        {
            errorMessage = "";

            bool isNationalNoAlreadyExists = clsPersonDataAccess.IsNationalNoExists(this.NationalNo);

            if (isNationalNoAlreadyExists)
            {
                errorMessage = $"National No {this.NationalNo} Already Exists";
                return false;
            }
            this.PersonId =
                clsPersonDataAccess.Insert
                (
                    this.NationalNo,this.FirstName,this.SecondName,this.ThirdName,
                    this.LastName,this.DateOfBirth,this.Gendor,this.Address,this.Phone,
                    this.Email,this.NationalityCountryID,this.ImagePath
                );

            if(PersonId != -1)
            {
                this.CountryInfo = clsCountry.FindById(this.NationalityCountryID);
            }

            return this.PersonId != -1;
        }
        private bool _Edit(out string errorMessage)
        {
            errorMessage = "";

            bool isNationalNoAlreadyExists = clsPersonDataAccess.IsNationalNoExists(this.NationalNo, this.PersonId);

            if (isNationalNoAlreadyExists)
            {
                errorMessage = $"Another Person Has Natinal No {this.NationalNo}";
                return false;
            }

            bool isUpdated =
                clsPersonDataAccess.Update
                (
                    this.PersonId,this.FirstName,this.SecondName,this.ThirdName,this.LastName,
                    this.NationalNo,this.DateOfBirth,this.Gendor,this.Address,this.Phone,
                    this.Email,this.NationalityCountryID,this.ImagePath
                );

            if (isUpdated)
            {
                this.CountryInfo = clsCountry.FindById(this.NationalityCountryID);
            }

            return isUpdated;
        }
        public bool Save(out string errorMessage)
        {
            errorMessage = "";
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNew(out errorMessage);
                case enMode.Edit:
                    return _Edit(out errorMessage);

            }
            return false;
        }

        public static bool CheckNationalNoExists(string nationalNo,int exeptPersonId)
        {
            return clsPersonDataAccess.IsNationalNoExists(nationalNo, exeptPersonId);
        }

        public static bool CheckIsUser(int personId)
        {
            return clsPersonDataAccess.IsPersonAUser(personId);    
        }
    }
}
