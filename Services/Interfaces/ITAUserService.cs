using DAL;
using System;
using System.Collections.Generic;


namespace Services
{
   public interface ITAUserService
    {
        List<TAUser> GetTAUser();
        int? UpdateTAUser(int? rowId, string surname, string prefferedName, string loggedOnUserName);
        int? DeleteTAUser(int? rowId);
    }
}
