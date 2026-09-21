using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsInternationalLicenseApplicationDataAccess
    {

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	IL.InternationalLicenseID,
		                            IL.ApplicationID,
		                            IL.DriverID,
		                            IL.IssuedUsingLocalLicenseID,
		                            IL.IssueDate,
		                            IL.ExpirationDate,
		                            IL.IsActive
                            FROM Applications A
                            INNER JOIN InternationalLicenses IL
                            ON A.ApplicationID = IL.ApplicationID
                            WHERE A.ApplicationTypeID = 6";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return dt;
        }
    }
}
