using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsDetainedLicenseDataAccess
    {
        public static bool GetByID
            (
                int detainId,out int licenseId,out DateTime detainDate,
                out decimal fineFees, out int createdByUserId,out bool isReleased,
                out Nullable<DateTime> releaseDate,out Nullable<int> releasedByUserId,out Nullable<int> releaseApplicationId
            )
        {
            
            bool isFound = false;
            licenseId = createdByUserId = -1;
            releasedByUserId = releaseApplicationId = null;

            detainDate = DateTime.Now;
            releaseDate = null;
            fineFees = 0;
            isReleased = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT *
                            FROM DetainedLicenses DL
                            WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    licenseId = Convert.ToInt32(reader["LicenseID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                    {
                        releasedByUserId = null;
                    }
                    else
                    {
                        releasedByUserId = Convert.ToInt32(reader["ReleasedByUserID"]);
                    }
                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                    {
                        releaseApplicationId = null;
                    }
                    else
                    {
                        releaseApplicationId = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    }

                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    if (reader["ReleaseDate"] == DBNull.Value)
                    {
                        releaseDate = null;
                    } else
                    {
                        releaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    }

                    fineFees = Convert.ToDecimal(reader["FineFees"]);
                    isReleased = Convert.ToBoolean(reader["IsReleased"]);
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


        public static bool GetLastDetainPerLicenseID
             (
                int licenseId, out int detainId, out DateTime detainDate,
                out decimal fineFees, out int createdByUserId, out bool isReleased,
                out Nullable<DateTime> releaseDate, out Nullable<int> releasedByUserId, out Nullable<int> releaseApplicationId
            )
        {

            bool isFound = false;
            detainId = createdByUserId = -1;
            releasedByUserId = releaseApplicationId = null;

            detainDate = DateTime.Now;
            releaseDate = null;
            fineFees = 0;
            isReleased = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT TOP 1 *
                            FROM DetainedLicenses DL
                            WHERE LicenseID = @LicenseID
                            ORDER BY DetainID DESC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    detainId = Convert.ToInt32(reader["DetainID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                    {
                        releasedByUserId = null;
                    }
                    else
                    {
                        releasedByUserId = Convert.ToInt32(reader["ReleasedByUserID"]);
                    }
                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                    {
                        releaseApplicationId = null;
                    }
                    else
                    {
                        releaseApplicationId = Convert.ToInt32(reader["ReleaseApplicationID"]);
                    }

                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    if (reader["ReleaseDate"] == DBNull.Value)
                    {
                        releaseDate = null;
                    }
                    else
                    {
                        releaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                    }

                    fineFees = Convert.ToDecimal(reader["FineFees"]);
                    isReleased = Convert.ToBoolean(reader["IsReleased"]);
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


        public static int Insert
            (
                int licenseId,DateTime detainDate,decimal fineFees,
                int createdByUserId,bool isReleased,DateTime? releaseDate,
                int? releasedByUserId,int? releaseApplicationId
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO DetainedLicenses
                                    (
		                            LicenseID
                                    ,DetainDate
                                    ,FineFees
                                    ,CreatedByUserID
                                    ,IsReleased
                                    ,ReleaseDate
                                    ,ReleasedByUserID
                                    ,ReleaseApplicationID
		                            )
                                VALUES
                                    (
		                            @LicenseID
                                    ,@DetainDate
                                    ,@FineFees
                                    ,@CreatedByUserID
                                    ,@IsReleased
                                    ,@ReleaseDate
                                    ,@ReleasedByUserID
                                    ,@ReleaseApplicationID
		                            )
                            SELECT SCOPE_IDENTITY()
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseId);
            command.Parameters.AddWithValue("@DetainDate", detainDate);
            command.Parameters.AddWithValue("@FineFees", fineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);
            command.Parameters.AddWithValue("@IsReleased", isReleased);
            if(releaseDate == null)
            {

                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            }

            if(releasedByUserId == null)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserId);
            }

            if(releaseApplicationId == null)
            {
            command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationId);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result !=null && result != DBNull.Value)
                {
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


        public static bool Update
    (
        int detainId,int licenseId, DateTime detainDate, decimal fineFees,
        int createdByUserId, bool isReleased, DateTime? releaseDate,
        int? releasedByUserId, int? releaseApplicationId
    )
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"UPDATE DetainedLicenses
                               SET LicenseID = @LicenseID
                                  ,DetainDate = @DetainDate
                                  ,FineFees = @FineFees
                                  ,CreatedByUserID = @CreatedByUserID
                                  ,IsReleased = @IsReleased
                                  ,ReleaseDate = @ReleaseDate
                                  ,ReleasedByUserID = @ReleasedByUserID
                                  ,ReleaseApplicationID = @ReleaseApplicationID
                             WHERE DetainID =@DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainId);
            command.Parameters.AddWithValue("@LicenseID", licenseId);
            command.Parameters.AddWithValue("@DetainDate", detainDate);
            command.Parameters.AddWithValue("@FineFees", fineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);
            command.Parameters.AddWithValue("@IsReleased", isReleased);
            if (releaseDate == null)
            {

                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            }

            if (releasedByUserId == null)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserId);
            }

            if (releaseApplicationId == null)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationId);
            }

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




    }
}
