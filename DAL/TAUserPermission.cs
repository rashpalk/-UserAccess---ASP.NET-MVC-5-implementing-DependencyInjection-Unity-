using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public enum Permissions
    {
        ReadOnly,
        FullAccess,
        NoAccess
    }

    public class TAUserPermission
    {        
        public int? RowId { get; set; }
        public string Username { get; set; }
        public string Permission { get; set; }

        

        public TAUserPermission()
        {

        }       

        public static Permissions  GetTAUserPermission(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BGSConnectionString"].ConnectionString))
                {
                    string sql = "select Permission from TAUserPermission Where Username= '" + username +"'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;                        
                        con.Open();
                        object permission = cmd.ExecuteScalar();
                        if (permission == null)
                        {
                            return Permissions.NoAccess;
                        }
                        else if (permission.ToString().ToLower() == "r")
                        {
                            return Permissions.ReadOnly;
                        }
                        else if (permission.ToString().ToLower() == "f")
                        {
                            return Permissions.FullAccess;
                        }
                        else
                        {
                            return Permissions.NoAccess;
                        }                       
                    }
                }
            }
            catch (Exception ex)
            {
                //log the excption here
                return Permissions.NoAccess;
            }
        }

       
    }
}
