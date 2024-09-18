using MassAutoGarage.Data.SourceMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.SalemanMaster;
using MassAutoGarage.Models.SourceMaster;
using MassAutoGarage.Models.SalesmanMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class SalesmanMasterController : Controller
    {
        // GET: SalesmanMaster

        ClsGeneral objcls = new ClsGeneral();
        SalesmanMaster_DL objDL = new SalesmanMaster_DL();
        public ActionResult SalesmanDetails(string Key)
        {
            List<SalesmanMasterModel> model = new List<SalesmanMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new SalesmanMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SalesMan = i.SalesMan,
                        Mobile = i.Mobile,
                        SalesID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new SalesmanMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SalesMan = i.SalesMan,
                        Mobile = i.Mobile,
                        SalesID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateSalesman(string ID = "")
        {
            SalesmanMasterModel model = new SalesmanMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.SalesmanMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.SalesmanMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.SalesMan = lst.SalesMan;
                    model.Mobile = lst.Mobile;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.SalesmanMasterModelList = objDL.GetCode("41", "SalesMan");
                var promotioncode = model.SalesmanMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveSalesmanMaster(SalesmanMasterModel model)
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

        public JsonResult DeleteSalesman(Int64 SaleID)
        {
            SalesmanMasterModel model = new SalesmanMasterModel();
            var lst = objDL.Delete(SaleID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}