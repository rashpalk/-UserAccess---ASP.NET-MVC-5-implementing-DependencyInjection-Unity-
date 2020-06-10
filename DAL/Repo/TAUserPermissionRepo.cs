using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class TAUserPermissionRepo: ITAUserPermissionRepo
    {
        public string GetTAUserPermission(string username)
        {
            return TAUserPermission.GetTAUserPermission(username);
        }       
    }
}
