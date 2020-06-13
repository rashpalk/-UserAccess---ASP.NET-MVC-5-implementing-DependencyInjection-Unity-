using System.Diagnostics;
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

        public Permissions GetTAUserPermission(string username)
        {
            return _iTAUserPermissionRepo.GetTAUserPermission(username);
        }
    }
}
