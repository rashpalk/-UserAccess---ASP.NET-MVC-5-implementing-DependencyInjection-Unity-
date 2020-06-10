using System;
using System.Collections.Generic;
using DAL;
namespace Services
{
    public class TAUserService:ITAUserService
    {
        private ITAUserRepo _iTAUserRepo;
        public TAUserService(ITAUserRepo iTAUserRepo)
        {
            _iTAUserRepo = iTAUserRepo;
        }

        public List<TAUser> GetTAUser()
        {
            return _iTAUserRepo.GetTAUser();
        }
        public int? UpdateTAUser(int? rowId, string surname, string prefferedName, string loggedOnUserName)
        {
            return _iTAUserRepo.UpdateTAUser(rowId,  surname,  prefferedName, loggedOnUserName);
        }

        public int? DeleteTAUser(int? rowId)
        {
            return _iTAUserRepo.DeleteTAUser(rowId);
        }

    }
}
