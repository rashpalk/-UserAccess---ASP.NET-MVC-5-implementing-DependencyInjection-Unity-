using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGS_UserAceesApp.Models
{
    public class UserModel
    {
        public int? RowId { get; set; }
        public int? UserId { get; set; }
        public string Surname { get; set; }
        public string PrefferedName { get; set; }        
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}