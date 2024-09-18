using MassAutoGarage.Data;
using MassAutoGarage.Models.GenderMaster;
using MassAutoGarage.Models.SourceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.SourceMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class SourceMasterController : Controller
    {
        // GET: SourceMaster

        ClsGeneral objcls = new ClsGeneral();
        SourceMaster_DL objDL = new SourceMaster_DL();
        public ActionResult SourceDetails(string Key)
        {
            List<SourceMasterModel> model = new List<SourceMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new SourceMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SourceName = i.SourceName,
                        SourceID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new SourceMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SourceName = i.SourceName,
                        SourceID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateSource(string ID = "")
        {
            SourceMasterModel model = new SourceMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.SourceMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.SourceMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.SourceName = lst.SourceName;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.SourceMasterModelList = objDL.GetCode("41", "Source");
                var promotioncode = model.SourceMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveSourceMaster(SourceMasterModel model)
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

        public JsonResult DeleteSource(Int64 SourceID)
        {
            SourceMasterModel model = new SourceMasterModel();
            var lst = objDL.Delete(SourceID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}