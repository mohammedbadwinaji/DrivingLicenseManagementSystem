using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsDriverDataAccess

    {
        public  static bool GetByID
            (
                int driverId, out int personId,out int createdByUserId,
                out DateTime createdDate
            )
        {
            bool isFound = false;
            personId = createdByUserId = -1;
            createdDate = DateTime.Today;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                            FROM Drivers D
                            WHERE D.DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    driverId = Convert.ToInt32(reader["DriverID"]);
                    personId = Convert.ToInt32(reader["PersonID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);
                    createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return isFound;
        }
        public static bool GetByPersonID
            (
                int personId,out int driverId,out int createdByUserId,
                out DateTime createdDate
            )
        {
            bool isFound = false;
            driverId = createdByUserId = -1;
            createdDate = DateTime.Today;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                            FROM Drivers D
                            WHERE D.PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    isFound = true;
                    driverId = Convert.ToInt32(reader["DriverID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);
                    createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return isFound;
        }


        public static int Insert
            (
                int personId,int createdByUserId
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO Drivers
                                   (
		                           PersonID
                                   ,CreatedByUserID
                                   ,CreatedDate
		                           )
                             VALUES
                                   (
		                           @PersonID
                                   ,@CreatedByUserID
                                   ,GETDATE()
		                           );
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value) { 
                    insertedId = Convert.ToInt32(result);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return insertedId;
        }
    }
}
