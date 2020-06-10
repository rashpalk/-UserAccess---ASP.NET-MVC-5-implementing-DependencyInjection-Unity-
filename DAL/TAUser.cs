using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TAUser
    {       
        public int? RowId { get; set; }
        public int? UserId { get; set; }
        public string Surname { get; set; }
        public string PrefferedName { get; set; }
        public string LoggedOnUserName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public TAUser()
        {

        }
        public TAUser(IDataReader reader)
        {
            RowId = Convert.ToInt32(reader["RowId"]);
            UserId = Convert.ToInt32(reader["UserId"]);
            Surname = reader["Surname"].ToString();
            PrefferedName = reader["Preferred"].ToString();
            ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"]);
            ModifiedBy = reader["ModifiedBy"].ToString();
        }

        public static List<TAUser> GetTAUser()
        {
            try
            {
                List<TAUser> TAUsers = new List<TAUser>();

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    string sql = "select * from TAUser order by RowID";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TAUsers.Add(
                                    new TAUser(reader)
                                );
                            }
                        }

                    }
                }
                return TAUsers;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
               // Log the exception here
            }
        }
        public int? UpdateTAUser()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    string sql = "Update TAUser set Surname = @Surname, Preferred=@Preferred, ModifiedOn=getdate(), ModifiedBy=@ModifiedBy where RowId=@RowId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@RowId", SqlDbType.Int).Value = RowId;
                        cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = Surname;
                        cmd.Parameters.Add("@Preferred", SqlDbType.VarChar).Value = PrefferedName;
                        cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar).Value = LoggedOnUserName;
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
                return RowId;
            }
            catch (Exception ex)
            {
               return RowId = -1;
                //Log the exception here
            }
        }

        public int? DeleteTAUser()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    string sql = "Delete from TAUser where RowId=@RowId";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@RowId", SqlDbType.Int).Value = RowId;
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
                return RowId;
            }
            catch (Exception)
            {
                return RowId = -1;
                //Log the exception here
            }
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }
    }
}
