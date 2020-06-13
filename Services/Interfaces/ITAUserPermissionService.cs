using DAL;
using System;
using System.Collections.Generic;


namespace Services
{
   public interface ITAUserPermissionService
    {
        Permissions GetTAUserPermission(string username);
    }
}
