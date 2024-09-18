using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.UserTypeMaster;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class UserTypeMasterController : Controller
    {
        // GET: UserTypeMaster
        ClsGeneral objcls = new ClsGeneral();
        UserTypeMaster_DL objDL = new UserTypeMaster_DL();
        public ActionResult UserTypeDetails(string Key)
        {
            List<UserTypeMasterModel> model = new List<UserTypeMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchUserType("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new UserTypeMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        UserType = i.UserType,
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
                    model.Add(new UserTypeMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        UserType = i.UserType,
                        UserId = i.Id,
                        IsActive = i.IsActive
                    });


                }
            }

            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                Int64 userID = Convert.ToInt64(Session["userId"]);
                var logo = DbMaster.GetCompanyLogo(userID).FirstOrDefault();
                ViewBag.compnylgo = "/CompanyLogo/" + logo.CompanyLogo;
                ViewBag.compnyAddress = logo.Address;
            }
            else
            {
                ViewBag.compnylgo = null;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUserType(string ID = "")
        {
            UserTypeMasterModel model = new UserTypeMasterModel();
            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.UserTypeMasterModelList = objDL.GetUserTypeMasterIdWise("42", id);
                var lst = model.UserTypeMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.Id = lst.Id;
                    model.Code = lst.Code;
                    model.UserType = lst.UserType;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.UserTypeMasterModelList = objDL.GetCode("41", "User Type");
                var promotioncode = model.UserTypeMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }
        public JsonResult SaveUserType(UserTypeMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.Id != "" && model.Id != null)
                {

                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.Id = objcls.Decrypt(model.Id);
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
                    model.QueryType = "11";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
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

        public JsonResult DeleteUserType(Int64 UserID)
        {

            var res = objDL.Delete(UserID);
            return Json(res.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}