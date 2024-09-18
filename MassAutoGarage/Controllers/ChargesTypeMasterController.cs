using MassAutoGarage.Data.JobCategoryMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.ChargerTypeMaster;
using MassAutoGarage.Models.JobCategoryMaster;
using MassAutoGarage.Models.ChargerTypeMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class ChargesTypeMasterController : Controller
    {
        // GET: ChargesTypeMaster
        ClsGeneral objcls = new ClsGeneral();
        ChargerTypeMaster_DL objDL = new ChargerTypeMaster_DL();
        public ActionResult ChargesTypeDetails(string Key)
        {
            List<ChargerTypeMasterModel> model = new List<ChargerTypeMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new ChargerTypeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        ChargerType = i.ChargerType,
                        ChargerID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new ChargerTypeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        ChargerType = i.ChargerType,
                        ChargerID = Convert.ToInt64(i.ID),
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
        public ActionResult ChargesType(string ID = "")
        {
            ChargerTypeMasterModel model = new ChargerTypeMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.ChargerTypeMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.ChargerTypeMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.ChargerType = lst.ChargerType;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.ChargerTypeMasterModelList = objDL.GetCode("41", "Charger-Type");
                var promotioncode = model.ChargerTypeMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveChargerMaster(ChargerTypeMasterModel model)
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

        public JsonResult Delete(Int64 ChargerID)
        {
            ChargerTypeMasterModel model = new ChargerTypeMasterModel();
            var lst = objDL.Delete(ChargerID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}