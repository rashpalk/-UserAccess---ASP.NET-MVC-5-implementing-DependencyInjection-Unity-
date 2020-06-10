using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using DAL;
using BGS_UserAceesApp.Models;
using BGS_UserAceesApp.ViewModels;

namespace BGS_UserAceesApp.Controllers
{
    public class HomeController : Controller
    {

        private ITAUserPermissionService _tAUserPermissionService;
        private ITAUserService _tAUserService;

        public HomeController(ITAUserPermissionService tAUserPermissionService, ITAUserService tAUserService)
        {
            _tAUserPermissionService = tAUserPermissionService;
            _tAUserService = tAUserService;
        }
        public ActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            GetData(homeIndexViewModel);
            return View(homeIndexViewModel);
        }

        private void GetData(HomeIndexViewModel homeIndexViewModel)
        {
            homeIndexViewModel.Username = Environment.UserDomainName + "\\" + Environment.UserName;
            string permission = _tAUserPermissionService.GetTAUserPermission(Environment.UserName);
            if (!string.IsNullOrWhiteSpace(permission) && (permission == "r" || permission == "f"))
            {
                if (permission.ToLower() == "r")
                    homeIndexViewModel.Permission = "Read Only Access";
                else if (permission.ToLower() == "f")
                    homeIndexViewModel.Permission = "Full Access";
                else
                    homeIndexViewModel.Permission = "";

                List<TAUser> tAUsers = _tAUserService.GetTAUser();
                if (tAUsers.Count > 0)
                {

                    foreach (TAUser tAUser in tAUsers)
                    {
                        UserModel userModel = new UserModel();
                        userModel.RowId = tAUser.RowId;
                        userModel.UserId = tAUser.UserId;
                        userModel.Surname = tAUser.Surname;
                        userModel.PrefferedName = tAUser.PrefferedName;
                        userModel.ModifiedOn = tAUser.ModifiedOn;
                        userModel.ModifiedBy = tAUser.ModifiedBy;
                        homeIndexViewModel.UsersModel.Add(userModel);
                    }
                }

            }
            else
            {
                homeIndexViewModel.Permission = "No Access";                
            }
        }

        [HttpPost]
        public int? UpdateTAUser(UserModel userModel)
        {
            int? rowId = _tAUserService.UpdateTAUser(userModel.RowId, userModel.Surname, userModel.PrefferedName, Environment.UserName);
            return rowId;
        }       

        [HttpPost]
        public int? DeleteTAUser(int? recordId)
        {
            int? rowId = _tAUserService.DeleteTAUser(recordId);
            return rowId;
        }
       
    }
}