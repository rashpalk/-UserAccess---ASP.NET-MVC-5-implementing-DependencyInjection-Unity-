using DAL;
using System;
using System.Collections.Generic;


namespace Services
{
   public interface ITAUserPermissionService
    {
        string GetTAUserPermission(string username);
    }
}
