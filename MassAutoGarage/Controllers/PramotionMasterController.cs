using MassAutoGarage.Data.ColorMaster;
using MassAutoGarage.Data;
using MassAutoGarage.Models.PramotionMaster;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.PromotionMaster;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Models.ColorMaster;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.SS.Formula.Functions;

namespace MassAutoGarage.Controllers
{
    public class PramotionMasterController : Controller
    {
        // GET: PramotionMaster

        ClsGeneral objcls = new ClsGeneral();
        PromotionMaster_DL objDL = new PromotionMaster_DL();
        public ActionResult PramotionDetails(string Key)
        {
            List<PramotionMasterModel> model = new List<PramotionMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new PramotionMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        PromotionName = i.PromotionName,
                        PeriodFromDate = i.PeriodFromDate,
                        ToDate = i.ToDate,
                        ServiceID = i.ServiceID,
                        ServiceName = i.ServiceName,
                        Discount = i.Discount,
                        DiscountAmount = i.DiscountAmount,
                        PramotionID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new PramotionMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        PromotionName = i.PromotionName,
                        PeriodFromDate = i.PeriodFromDate,
                        ToDate = i.ToDate,
                        ServiceID = i.ServiceID,
                        ServiceName = i.ServiceName,
                        Discount = i.Discount,
                        DiscountAmount = i.DiscountAmount,
                        PramotionID = Convert.ToInt64(i.ID),
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
        public ActionResult AddPramotion(string ID = "")
        {
            Dropdown();

            PramotionMasterModel model = new PramotionMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.PramotionMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.PramotionMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.PromotionName = lst.PromotionName;
                    model.PeriodFromDate = lst.PeriodFromDate;

                    model.ToDate = lst.ToDate;
                    model.ServiceID = lst.ServiceID;
                    model.Discount = lst.Discount;
                    model.DiscountAmount = lst.DiscountAmount;
                    model.IsActive = lst.IsActive;

                }

            }
            else
            {
                model.PramotionMasterModelList = objDL.GetCode("41", "Promotion");
                var promotioncode = model.PramotionMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {
                   
                    model.Code = promotioncode.Code;
                    model.CurrentCount=promotioncode.CurrentCount;


                }


            }
            return View(model);
        }

        public JsonResult SavePromotionMaster(PramotionMasterModel model)
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
        private void Dropdown()
        {
            ViewBag.ServiceList = DbMaster.DropdownList("41", 19);

        }
        public JsonResult Delete(Int64 promid)
        {
            ColorMasterModel model = new ColorMasterModel();
            var lst = objDL.Delete(promid);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}