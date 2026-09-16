using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsTestTypeDataAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT *
                                FROM TestTypes";
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

        public static bool GetByID
            (
                int testTypeID, out string testTypeTitle,
                out string testTypeDescription, out decimal testTypeFees
            )
        {
            bool isFound = false;
            testTypeTitle = testTypeDescription = string.Empty;
            testTypeFees = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT *
                                FROM TestTypes
                                WHERE TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testTypeTitle = (string)reader["TestTypeTitle"];
                    testTypeDescription = (string)reader["TestTypeDescription"];
                    testTypeFees = Convert.ToDecimal(reader["TestTypeFees"]);
                    isFound = true;
                }
                else
                {
                    isFound = false;
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

        public static bool Update
            (
                int testTypeID , string testTypeTitle,
                string testTypeDescription, decimal testTypeFees,
                out string errorMessage
            )
        {
            errorMessage = string.Empty;
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"   UPDATE TestTypes
                                SET TestTypeTitle = @TestTypeTitle,
	                                TestTypeDescription = @TestTypeDescription,
	                                TestTypeFees = @TestTypeFees
                                WHERE TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", testTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", testTypeFees);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                errorMessage = ex.StackTrace;
                return false;
            }

            return affectedRows > 0;
        }

        
    }
}
