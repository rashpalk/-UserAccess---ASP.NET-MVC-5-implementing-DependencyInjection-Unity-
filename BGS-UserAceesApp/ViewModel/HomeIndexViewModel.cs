using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BGS_UserAceesApp.Models;

namespace BGS_UserAceesApp.ViewModels
{
    public class HomeIndexViewModel
    {      
        public string Username { get; set; }
        public string Permission { get; set; }        

        public List<UserModel> UsersModel = new List<UserModel>();
    }
}