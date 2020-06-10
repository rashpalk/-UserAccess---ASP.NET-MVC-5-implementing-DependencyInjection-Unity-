using System;
using System.Collections.Generic;
using DAL;
namespace Services
{
    public class TAUserPermissionService:ITAUserPermissionService
    {
        private ITAUserPermissionRepo _iTAUserPermissionRepo;
        public TAUserPermissionService(ITAUserPermissionRepo iTAUserPermissionRepo)
        {
            _iTAUserPermissionRepo = iTAUserPermissionRepo;
        }

        public string GetTAUserPermission(string username)
        {
            return _iTAUserPermissionRepo.GetTAUserPermission(username);
        }
    }
}
