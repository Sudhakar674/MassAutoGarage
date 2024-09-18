using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.UserMaster;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class UserMasterController : Controller
    {
        // GET: UserMaster
        ClsGeneral objcls = new ClsGeneral();
        UserMasterModel_DL objDL = new UserMasterModel_DL();
        public ActionResult UserDetails(string Key)
        {
            List<UserMasterModel> model = new List<UserMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {

                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchUserMaster("43", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new UserMasterModel
                        {
                            Id = objcls.Encrypt(i.Id),
                            UserName = i.UserName,
                            Code = i.Code,
                            UserTypeName = i.UserTypeName,
                            CompanyName = i.CompanyName,
                            UserId = i.Id,
                            IsActive = i.IsActive
                        });
                    }

                }
                else
                {
                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new UserMasterModel
                        {
                            Id = objcls.Encrypt(i.Id),
                            UserName = i.UserName,
                            Code = i.Code,
                            UserTypeName = i.UserTypeName,
                            CompanyName = i.CompanyName,
                            UserId = i.Id,
                            IsActive = i.IsActive
                        });
                    }
                }
                if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
                {
                    Int64 userID = Convert.ToInt64(Session["userId"]);
                    var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();

                    if (logo != null)
                    {
                        ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                        ViewBag.compnyAddress = logo.Address;
                    }
                }
                else
                {
                    ViewBag.compnylgo = null;
                }
            }
            else
            {
                return RedirectToAction("Logout", "LoginAuth");

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateUser(string ID = "")
        {
            Dropdown();
            UserMasterModel model = new UserMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.UserMasterModelList = objDL.GetUserMasterIdWise("42", id);
                var lst = model.UserMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.Id = lst.Id;
                    model.Code = lst.Code;
                    model.UserName = lst.UserName;
                    model.UserTypeId = lst.UserTypeId;
                    model.CompanyId = lst.CompanyId;
                    model.LoginId = lst.LoginId;
                    model.Password = objcls.Decrypt(lst.Password);
                    model.StartDate = lst.StartDate;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.UserMasterModelList = objDL.GetCode("41", "User");
                var promotioncode = model.UserMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
           
        }
        public JsonResult SaveUserMaster(UserMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.Id != "" && model.Id != null)
                {
                  
                    DateTime dateTime10 = DateTime.Parse(model.StartDate);
                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.Id = objcls.Decrypt(model.Id);
                    model.Password = objcls.Encrypt(model.Password);
                    model.SDate = dateTime10;
                    model = objDL.AddUpd(model);
                    if (model.Flag == 2)
                    {
                        result = "2";
                    }
                    else
                    {
                        result = "";
                    }
                }
                else
                {
                    DateTime stDate = DateTime.Parse(model.StartDate);
                    model.QueryType = "11";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.Password = objcls.Encrypt(model.Password);
                    model.SDate = stDate;
                    model = objDL.AddUpd(model);
                    if (model.Flag == 1)
                    {
                        result = "1";
                    }
                    else if (model.Flag == 4)
                    {
                        result = "4";
                    }
                    else
                    {
                        result = "";
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private void Dropdown()
        {
            ViewBag.UserType = DbMaster.DropdownList("41", 1);
            ViewBag.BranchMaster = DbMaster.DropdownList("41", 2);
            ViewBag.Company = DbMaster.DropdownList("41", 4);
        }
        public JsonResult LoadUserType(int userId)
        {
            DbMaster obj = new DbMaster();
            var UserTypelist = obj.getValue("41", 3, userId);
            return Json(UserTypelist.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(Int64 UserID)
        {

            var res = objDL.Delete(UserID);
            return Json(res.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}