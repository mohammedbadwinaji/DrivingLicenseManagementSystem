using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @" SELECT 	LDLA.LocalDrivingLicenseApplicationID,	
		                                LC.ClassName,
		                                P.NationalNo,
		                                (
			                                P.FirstName + ' ' +
			                                P.SecondName + ' ' +
			                                ISNULL(P.ThirdName,'') + ' ' +
			                                ISNULL(P.LastName,'')
		                                ) as FullName,
		                                COUNT
		                                (
			                                CASE 
				                                WHEN T.TestResult IS NULL OR T.TestResult = 0 THEN NULL 
				                                ELSE 1 
			                                END
		                                ) as PassedTests,
                                        A.ApplicationDate,
		                                ASS.StatusName
                                FROM LocalDrivingLicenseApplications LDLA
                                INNER JOIN LicenseClasses LC
                                ON LDLA.LicenseClassID = LC.LicenseClassID
                                INNER JOIN Applications A
                                ON LDLA.ApplicationID = A.ApplicationID
                                INNER JOIN People P
                                ON A.ApplicantPersonID = P.PersonID
                                INNER JOIN ApplicationStatuses ASS
                                ON A.ApplicationStatusID = ASS.StatusID
                                LEFT JOIN TestAppointments TA
                                ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                LEFT JOIN Tests T
                                ON TA.TestAppointmentID = T.TestAppointmentID
                                GROUP BY	LDLA.LocalDrivingLicenseApplicationID,
			                                LC.ClassName,
			                                P.NationalNo,
			                                P.FirstName,
			                                P.SecondName,
			                                P.ThirdName,
			                                P.LastName,
			                                A.ApplicationDate,
			                                A.ApplicationStatusID,
			                                ASS.StatusName";

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
            int lDLApplicationId, out int applicationId, out int licenseClassId, out string licenseClassName,
            out int applicantPersonId, out string applicantFullName, out DateTime applicationDate,
            out int applicationTypeId, out string applicationTypeTitle, out int applicationStatusId,
            out string applicationStatusTitle, out DateTime lastStatusDate, out decimal paidFees,
            out int createdByUserId, out string createdByUserName, out int passedTests,out int licenseId
        )
        {
            applicationId = licenseClassId = applicantPersonId = applicationTypeId = applicationStatusId = createdByUserId = licenseId = -1;
            licenseClassName = applicantFullName = applicationTypeTitle = applicationStatusTitle = createdByUserName = string.Empty;
            applicationDate = lastStatusDate = DateTime.MinValue;
            passedTests = 0;
            paidFees = 0;

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 	LDLA.LocalDrivingLicenseApplicationID,
		                                A.ApplicationID,
		                                LC.LicenseClassID,
		                                LC.ClassName,
		                                A.ApplicantPersonID,
		                                P.NationalNo,
		                                (
			                                P.FirstName + ' ' +
			                                P.SecondName + ' ' +
			                                ISNULL(P.ThirdName,'') + ' ' +
			                                ISNULL(P.LastName,'')
		                                ) as FullName,
		                                A.ApplicationDate,
		                                A.ApplicationTypeID,
		                                AT.ApplicationTypeTitle,
		                                A.ApplicationStatusID,
		                                ASS.StatusName,
		                                A.LastStatusDate,
		                                A.PaidFees,
		                                A.CreatedByUserID,
		                                U.UserName,
		                                COUNT
		                                (
			                                CASE 
				                                WHEN T.TestResult IS NULL OR T.TestResult = 0 THEN NULL 
				                                ELSE 1 
			                                END
		                                ) as PassedTests,
		                                (
		                                CASE 
			                                WHEN L.LicenseID IS NULL THEN -1
			                                ELSE L.LicenseID
		                                END
		                                ) as LicenseID
                                FROM LocalDrivingLicenseApplications LDLA
                                INNER JOIN LicenseClasses LC
                                ON LDLA.LicenseClassID = LC.LicenseClassID
                                INNER JOIN Applications A
                                ON LDLA.ApplicationID = A.ApplicationID
                                INNER JOIN People P
                                ON A.ApplicantPersonID = P.PersonID
                                INNER JOIN ApplicationStatuses ASS
                                ON A.ApplicationStatusID = ASS.StatusID
                                INNER JOIN ApplicationTypes AT
                                ON A.ApplicationTypeID = AT.ApplicationTypeID
                                INNER JOIN Users U
                                ON A.CreatedByUserID = U.UserID
                                LEFT JOIN TestAppointments TA
                                ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                LEFT JOIN Tests T
                                ON TA.TestAppointmentID = T.TestAppointmentID
                                LEFT JOIN Licenses L
                                ON A.ApplicationID = L.ApplicationID
                                WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                GROUP BY	LDLA.LocalDrivingLicenseApplicationID,
			                                A.ApplicationID,
			                                A.ApplicantPersonID,
			                                LC.LicenseClassID,
			                                LC.ClassName,
			                                P.NationalNo,
			                                P.FirstName,
			                                P.SecondName,
			                                P.ThirdName,
			                                P.LastName,
			                                A.ApplicationDate,
			                                A.ApplicationTypeID,
			                                AT.ApplicationTypeTitle,
			                                A.ApplicationStatusID,
			                                ASS.StatusName,
			                                A.LastStatusDate,
			                                A.PaidFees,
			                                A.CreatedByUserID,
			                                U.UserName,
			                                L.LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", lDLApplicationId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    applicationId = (int)reader["ApplicationID"];
                    licenseClassId = (int)reader["LicenseClassID"];
                    licenseClassName = reader["ClassName"].ToString();
                    applicantPersonId = (int)reader["ApplicantPersonID"];
                    applicantFullName = reader["FullName"].ToString();
                    applicationDate = (DateTime)reader["ApplicationDate"];
                    applicationTypeId = (int)reader["ApplicationTypeID"];
                    applicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                    applicationStatusId = (int)reader["ApplicationStatusID"];
                    applicationStatusTitle = reader["StatusName"].ToString();
                    lastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    createdByUserId = (int)reader["CreatedByUserID"];
                    createdByUserName = reader["UserName"].ToString();
                    passedTests = (int)reader["PassedTests"];
                    licenseId = (int)reader["LicenseID"];
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
                int applicantPersonId,DateTime applicationDate,int applicationTypeId,
                int applicationStatusId,DateTime lastStatusDate,decimal paidFees,
                int createdByUserId,
                int licenseClassId
            )
        {
            int applicationId = clsApplicationDataAccess.Insert(
                applicantPersonId,
                applicationDate,
                applicationTypeId,
                applicationStatusId,
                lastStatusDate,
                paidFees,
                createdByUserId
            );

            if (applicationId <= 0)
                return -1;

            int localDrivingLicenseApplicationId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                     VALUES (@ApplicationID, @LicenseClassID);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    localDrivingLicenseApplicationId = id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return localDrivingLicenseApplicationId;
        }

        public static bool IsApplicantAlreadyHasActiveApplicationWithSameLicenseClass
            (
            int personId, int licenseClassId,int exceptLocalDrivingApplicationId=-1
            )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM LocalDrivingLicenseApplications LDLA
                            INNER JOIN Applications A
                            ON LDLA.ApplicationID = A.ApplicationID
                            INNER JOIN LicenseClasses LC
                            ON LDLA.LicenseClassID = LC.LicenseClassID
                            WHERE	A.ApplicantPersonID = @PersonID	AND
		                            LC.LicenseClassID = @LicenseClassID		AND
                                    A.ApplicationStatusID IN (1,3) AND
		                            LDLA.LocalDrivingLicenseApplicationID <> @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@LicenseClassID",licenseClassId);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", exceptLocalDrivingApplicationId);

            try
            {
                connection.Open();
                object result  = command.ExecuteScalar();
                if(result != null && result!= DBNull.Value)
                {
                    isFound = true;  
                }
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
                int localDrivingLicenseApplicationId,int licenseClassId
            )
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"UPDATE LocalDrivingLicenseApplications
                     SET LicenseClassID = @LicenseClassID
                     WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return affectedRows > 0;
        }


        public static bool UpdateStatus
            (
                int localDrivingLicenseApplicaionId , int statusId
            )
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"UPDATE Applications
                            SET	ApplicationStatusID = @ApplicationStatusID,
                            LastStatusDate = GETDATE()
                            WHERE ApplicationID = 
                            (
	                            SELECT ApplicationID
	                            FROM LocalDrivingLicenseApplications
	                            WHERE LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID
                            );";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicaionId);
            command.Parameters.AddWithValue("@ApplicationStatusID", statusId);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return affectedRows > 0;
        }


        public static bool GetApplicationLicense(int localDrivingLicenseApplicationId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"";
            return isFound;
        }
    }
}
