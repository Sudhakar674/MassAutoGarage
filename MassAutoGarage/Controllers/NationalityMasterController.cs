using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.NationalityMaster;
using MassAutoGarage.Models.CustomerGroupMaster;
using MassAutoGarage.Models.NationalityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class NationalityMasterController : Controller
    {
        // GET: NationalityMaster
        ClsGeneral objcls = new ClsGeneral();
        NationalityMaster_DL objDL = new NationalityMaster_DL();    
        public ActionResult NationalityDetails(string Key)
        {
            List<NationalityMasterModel> model = new List<NationalityMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchNationalityMaster("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new NationalityMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Nationality = i.Nationality,
                        NationID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new NationalityMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Nationality = i.Nationality,
                        NationID = Convert.ToInt64(i.ID),
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
        public ActionResult Nationality(string ID = "")
        {
            NationalityMasterModel model = new NationalityMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.NationalityMasterModelList = objDL.GetNationalitylstIdWise("42", id);
                var lst = model.NationalityMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.Nationality = lst.Nationality;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.NationalityMasterModelList = objDL.GetCode("41", "Nationality");
                var promotioncode = model.NationalityMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveCustomerGroupMaster(NationalityMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.ID != "" && model.ID != null)
                {


                    model.QueryType = "21";
                    if (Session["UserTypeId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["UserTypeId"]);
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
                    if (Session["UserTypeId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["UserTypeId"]);
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

        public JsonResult DeleteNationality(Int64 NationID)
        {
            NationalityMasterModel model = new NationalityMasterModel();
            var lst = objDL.Delete(NationID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}