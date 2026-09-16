using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsCountryDataAccess
    {
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                              FROM Countries";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) {
                connection.Close();
                throw ex;
            }
            return dt;
        }

        public static bool GetCountryByID
            (
                int countryId, out string countryName
            )
        {
            countryName = "";
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                             FROM Countries C
                             WHERE C.CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", countryId);

            try
            {
                connection.Open();
                SqlDataReader reader =  command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    countryName = reader["CountryName"].ToString();
                } else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) {
                connection.Close();
                throw ex;
            }
            return isFound;
        }
    }
}
