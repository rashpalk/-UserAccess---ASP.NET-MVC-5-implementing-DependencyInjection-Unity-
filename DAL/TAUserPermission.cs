using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TAUserPermission
    {        
        public int? RowId { get; set; }
        public string Username { get; set; }
        public string Permission { get; set; }


        public TAUserPermission()
        {

        }       

        public static string GetTAUserPermission(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
                {
                    string sql = "select Permission from TAUserPermission Where Username= '" + username +"'";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;                        
                        con.Open();
                        return cmd.ExecuteScalar() ==null ? "" : cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
