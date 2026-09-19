using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsApplicationTypeDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"   SELECT *
                                FROM ApplicationTypes ";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }catch
            (Exception)
            {
                connection.Close();
                throw;
            }

            return dt;
        }

        public static bool GetByID
            (
                int applicationTypeID, out string applicationTypeTitle,
                out decimal applicationTypeFees
            )
        {
            bool isFound = false;
            applicationTypeTitle = string.Empty;
            applicationTypeFees = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"   SELECT *
                                FROM ApplicationTypes
                                WHERE ApplicationTypeID = @ApplicationTypeID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    applicationTypeFees = (decimal)reader["ApplicationFees"];
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
            int applicationTypeId,string applicationTypeTitle,
            decimal applicationTypeFees,out string errorMessage
            )
        {
            errorMessage = string.Empty;
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE ApplicationTypes
                                SET ApplicationTypeTitle = @ApplicationTypeTitle,
	                                ApplicationFees = @ApplicationTypeFees
                                WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationTypeFees", applicationTypeFees);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                errorMessage = string.Empty;
                return false;
            }

            return affectedRows > 0;
        }

        public static decimal GetApplicationTypeFeesByID(int applicationTypeId)
        {
            decimal applicationTypeFees = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT ApplicationFees
                                FROM ApplicationTypes
                                WHERE ApplicationTypeID = @ApplicationTypeID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null || result != DBNull.Value)
                {
                    applicationTypeFees = Convert.ToDecimal(result);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return applicationTypeFees;
        }
    }
}
