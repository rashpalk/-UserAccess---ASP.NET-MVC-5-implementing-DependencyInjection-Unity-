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
            GetTAUserData(homeIndexViewModel);
            return View(homeIndexViewModel);
        }

        private void GetTAUserData(HomeIndexViewModel homeIndexViewModel)
        {
            homeIndexViewModel.Username = Environment.UserDomainName + "\\" + Environment.UserName;
            Permissions permissions = _tAUserPermissionService.GetTAUserPermission(Environment.UserName);
            if (permissions == Permissions.ReadOnly || permissions == Permissions.FullAccess)
            {
                if (permissions == Permissions.ReadOnly)
                    homeIndexViewModel.Permission = "Read Only Access";
                else if (permissions == Permissions.FullAccess)
                    homeIndexViewModel.Permission = "Full Access";
                else
                    homeIndexViewModel.Permission = "";

                List<TAUser> tAUsers = _tAUserService.GetTAUsers();
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
        public JsonResult UpdateTAUser(UserModel userModel)
        {
            int? rowId = _tAUserService.UpdateTAUser(userModel.RowId, userModel.Surname, userModel.PrefferedName, Environment.UserName);

            if (rowId != -1)
            {
                TAUser tAUser = new TAUser();

                UserModel updatedUserModel = new UserModel();

                tAUser = GetDataById(userModel.RowId);
                updatedUserModel.RowId = tAUser.RowId;
                updatedUserModel.UserId = tAUser.UserId;
                updatedUserModel.Surname = tAUser.Surname;
                updatedUserModel.PrefferedName = tAUser.PrefferedName;
                updatedUserModel.ModifiedOn = tAUser.ModifiedOn;
                updatedUserModel.ModifiedBy = tAUser.ModifiedBy;
                return Json(updatedUserModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = new
                {
                    RowId = rowId
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        private TAUser GetDataById(int? rowId)
        {
            return _tAUserService.GetTAUserById(rowId);
        }

        [HttpPost]
        public int? DeleteTAUser(int? recordId)
        {
            int? rowId = _tAUserService.DeleteTAUser(recordId);
            return rowId;
        }
       
    }
}