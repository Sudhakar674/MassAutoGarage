using MassAutoGarage.Data.NationalityMaster;
using MassAutoGarage.Data;
using MassAutoGarage.Models.NationalityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.GenderMaster;
using MassAutoGarage.Models.GenderMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class GenderMasterController : Controller
    {
        // GET: GenderMaster

        ClsGeneral objcls = new ClsGeneral();
        GenderMaster_DL objDL = new GenderMaster_DL();
        public ActionResult GenderDetail(string Key)
        {
            List<GenderMasterModel> model = new List<GenderMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new GenderMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Gender = i.Gender,
                        GenderID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new GenderMasterModel
                    {

                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Gender = i.Gender,
                        GenderID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateGender(string ID = "")
        {
            GenderMasterModel model = new GenderMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.GenderMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.GenderMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.Gender = lst.Gender;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.GenderMasterModelList = objDL.GetCode("41", "Gender");
                var promotioncode = model.GenderMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveGenderMaster(GenderMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.ID != "" && model.ID != null)
                {


                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.ID = objcls.Decrypt(model.ID);
                    model = objDL.AddUpdate(model);
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

                    model = objDL.AddUpdate(model);
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

        public JsonResult DeleteGender(Int64 GenderID)
        {
            GenderMasterModel model = new GenderMasterModel();
            var lst = objDL.Delete(GenderID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}