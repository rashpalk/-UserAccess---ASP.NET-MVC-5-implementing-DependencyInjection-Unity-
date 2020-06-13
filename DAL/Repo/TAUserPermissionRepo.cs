using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class TAUserPermissionRepo: ITAUserPermissionRepo
    {
        public Permissions GetTAUserPermission(string username)
        {
            return TAUserPermission.GetTAUserPermission(username);
        }       
    }
}
