using MassAutoGarage.Data.ColorMaster;
using MassAutoGarage.Data;
using MassAutoGarage.Models.ColorMaster;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.LoyaltyPointMaster;
using MassAutoGarage.Models.LoyaltyPointMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class LoyaltyPointMasterController : Controller
    {
        // GET: LoyaltyPointMaster

        ClsGeneral objcls = new ClsGeneral();
        LoyaltyPointsMaster_DL objDL = new LoyaltyPointsMaster_DL();
        public ActionResult LoyaltyDetails(string Key)
        {
            List<LoyaltyPointMasterModel> model = new List<LoyaltyPointMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new LoyaltyPointMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SalesValue = i.SalesValue,
                        ToSalesValue = i.ToSalesValue,
                        LoyaltyPoints = i.LoyaltyPoints,
                        LoyaltyID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new LoyaltyPointMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SalesValue = i.SalesValue,
                        ToSalesValue = i.ToSalesValue,
                        LoyaltyPoints = i.LoyaltyPoints,
                        LoyaltyID = Convert.ToInt64(i.ID),
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
        public ActionResult LoyaltyPoint(string ID = "")
        {
            LoyaltyPointMasterModel model = new LoyaltyPointMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.LoyaltyPointMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.LoyaltyPointMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.SalesValue = lst.SalesValue;
                    model.ToSalesValue = lst.ToSalesValue;
                    model.LoyaltyPoints = lst.LoyaltyPoints;
                    model.IsActive = lst.IsActive;
                   
                }
            }
            else
            {
                model.LoyaltyPointMasterModelList = objDL.GetCode("41", "Loyalty Points");
                var promotioncode = model.LoyaltyPointMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveLoyaltyPoint(LoyaltyPointMasterModel model)
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
        public JsonResult Delete(Int64 id)
        {           
            var lst = objDL.Delete(id);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}