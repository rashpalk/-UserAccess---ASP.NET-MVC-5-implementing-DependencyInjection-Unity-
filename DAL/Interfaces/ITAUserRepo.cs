using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface ITAUserRepo
    {
        List<TAUser> GetTAUsers();
        List<TAUser> GetTAUserById(int? rowId);
        int? UpdateTAUser(int? rowId, string surname, string prefferedName, string loggedOnUserName);
        int? DeleteTAUser(int? rowId);
    }
}
