using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface ITAUserRepo
    {
        List<TAUser> GetTAUser();
        int? UpdateTAUser(int? rowId, string surname, string prefferedName, string loggedOnUserName);
        int? DeleteTAUser(int? rowId);
    }
}
