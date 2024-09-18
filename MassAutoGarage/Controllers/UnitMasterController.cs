using MassAutoGarage.Data.ModelMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.UnitMaster;
using MassAutoGarage.Models.ModelMaster;
using MassAutoGarage.Models.UnitMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class UnitMasterController : Controller
    {
        // GET: UnitMaster
        ClsGeneral objcls = new ClsGeneral();
        UnitMaster_DL objDL = new UnitMaster_DL();


        public ActionResult UnitDetails(string Key)
        {
            List<UnitMasterModel> model = new List<UnitMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new UnitMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        UnitName = i.UnitName,                       
                        UnitID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new UnitMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        UnitName = i.UnitName,
                        UnitID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateUnit(string ID = "")
        {
            UnitMasterModel model = new UnitMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.UnitMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.UnitMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.UnitName = lst.UnitName;                  
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.UnitMasterModelList = objDL.GetCode("41", "Unit");
                var promotioncode = model.UnitMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveUnitMaster(UnitMasterModel model)
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

        public JsonResult Delete(Int64 UnitID)
        {
            UnitMasterModel model = new UnitMasterModel();
            var lst = objDL.Delete(UnitID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}