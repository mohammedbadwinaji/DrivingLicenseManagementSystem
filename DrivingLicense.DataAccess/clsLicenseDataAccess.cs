using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsLicenseDataAccess
    {
        public static int Insert
            (
                int applicationId, int driverId, int licenseClassId,
                string notes, decimal paidFees, int issueReason,
                int createdByUserId
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO Licenses
                            (
                                ApplicationID, DriverID, LicenseClass, IssueDate, 
                                ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID
                            )
                            SELECT 
                                @ApplicationID, 
                                @DriverID, 
                                LC.LicenseClassID,
                                GETDATE(), 
                                DATEADD(year, LC.DefaultValidityLength, GETDATE()), 
                                @Notes, 
                                @PaidFees, 
                                1, 
                                @IssueReason,
                                @CreatedByUserID
                            FROM LicenseClasses LC
                            WHERE LC.LicenseClassID = @LicenseClass;
                            SELECT SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);      
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@DriverID", driverId);
            command.Parameters.AddWithValue("@LicenseClass", licenseClassId);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@IssueReason", issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);

                   
            if (string.IsNullOrEmpty(notes))
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", notes);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    insertedId = inserted;
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

        public static bool GetByID
            (
                int licenseId, out int applicationId, out int driverId,
                out int licenseClassId, out DateTime issueDate, out DateTime expirationDate,
                out string notes,out decimal paidFees,out bool isActive,
                out int issueReason,out int createdByUserId,out bool isDetained
            )
        {
            bool isFound = false;
            applicationId = driverId = licenseClassId = createdByUserId = issueReason= -1;
            issueDate = expirationDate = DateTime.Now;
            isActive = isDetained =  false;
            paidFees = 0;
            notes = string.Empty;
           
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	L.*,
		                            (
			                            CASE 
				                            WHEN DL.DetainID IS NULL THEN 0
				                            ELSE 1
			                            END
		                            ) AS IsDetained
                            FROM Licenses L
                            LEFT JOIN DetainedLicenses DL
                            ON L.LicenseID = DL.LicenseID
                            WHERE L.LicenseID = @LicenseID
                            ";

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("LicenseID", licenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    applicationId = Convert.ToInt32(reader["ApplicationID"]);
                    driverId = Convert.ToInt32(reader["DriverID"]);
                    licenseClassId = Convert.ToInt32(reader["LicenseClass"]);
                    issueReason = Convert.ToInt32(reader["IssueReason"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);

                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                    notes = Convert.ToString(reader["Notes"]);
                    paidFees = Convert.ToDecimal(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    isDetained = Convert.ToBoolean(reader["IsDetained"]);
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
     
        
        public static DataTable GetPersonLicenses(int personId)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	L.LicenseID,
		                            L.ApplicationID,
		                            L.LicenseClass,
		                            L.IssueDate,
		                            L.ExpirationDate,
		                            L.IsActive
                            FROM Licenses L
                            INNER JOIN Drivers D
                            ON L.DriverID = D.DriverID
                            WHERE D.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
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
