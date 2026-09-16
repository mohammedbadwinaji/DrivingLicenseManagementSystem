using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsCountry
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int countryId,string countryName)
        {
            this.CountryId = countryId;
            this.CountryName = countryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
        public static clsCountry FindById(int countryId)
        {
            string countryName;
            bool isCountryExists = clsCountryDataAccess.GetCountryByID(countryId, out countryName);

            if (isCountryExists)
            {
                return new clsCountry(countryId, countryName);
            }
            return null;
        }
    }
}
