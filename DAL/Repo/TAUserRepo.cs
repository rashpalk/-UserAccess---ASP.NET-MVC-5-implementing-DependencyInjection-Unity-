using System;
using System.Collections.Generic;


namespace DAL
{
   public class TAUserRepo: ITAUserRepo
    {
        public List<TAUser> GetTAUser()
        {
            return TAUser.GetTAUser();
        }
        public int? UpdateTAUser(int? rowId, string surname, string prefferedName, string loggedOnUserName)
        {
            TAUser tAUser = new TAUser();
            tAUser.RowId = rowId;
            tAUser.Surname = surname;
            tAUser.PrefferedName = prefferedName;
            tAUser.LoggedOnUserName = loggedOnUserName;
            return tAUser.UpdateTAUser();
        }

        public int? DeleteTAUser(int? rowId)
        {
            TAUser tAUser = new TAUser();
            tAUser.RowId = rowId;            
            return tAUser.DeleteTAUser();
        }
    }
}
