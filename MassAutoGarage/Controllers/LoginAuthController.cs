using MassAutoGarage.Data;
using MassAutoGarage.Data.LoginAuth;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class LoginAuthController : Controller
    {
        // GET: LoginAuth
        ClsGeneral objcls = new ClsGeneral();
        SessionManager sm = new SessionManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {

            sm.RemoveSession();
            return RedirectToAction("Login", "LoginAuth");

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserMasterModel model)
        {
            var pass = string.Empty;
            AccountMasterService objService = new AccountMasterService();
            UserMasterModel objlst = new UserMasterModel();
            if (model.LoginId != null && model.Password != null)
            {
                pass = objcls.Encrypt(model.Password);
                var log = model.LoginId;

                objlst = objService.GetLogin<UserMasterModel>(log, pass);
                if (objlst != null)
                {
                    var decrypPass = objcls.Decrypt(objlst.Password);
                    var enterPass = objcls.Decrypt(pass);

                    if (enterPass == decrypPass)
                    {
                        sm.userName = objlst.LoginId;
                        sm.UserTypeId = objlst.UserTypeId;
                        sm.userName=objlst.UserName;
                        sm.userId=Convert.ToInt64(objlst.UserId);

                        //if (objlst.UserTypeId == 1)// Admin Panel
                        //{
                        //    return RedirectToAction("Index", "Home");
                        //}
                        //else if (objlst.UserTypeId == 2)// supper Admin Panel
                        //{
                        //    return RedirectToAction("Index", "Home");
                        //}
                        //else if (objlst.UserTypeId == 4)// supper Admin Panel
                        //{

                        //}

                        if (objlst.UserTypeId == 10)  // Super Admin Panel
                        {
                           
                            return RedirectToAction("Index", "Super_AdminDashboard");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }


                }
                else
                {
                    ViewBag.message = "Please Check Your LoginID OR Password !";
                }

            }
            else
            {


            }
            return View(model);
        }
    }
}