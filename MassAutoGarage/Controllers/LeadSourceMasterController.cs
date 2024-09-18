using MassAutoGarage.Data.PriorityMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.LeadSourceMaster;
using MassAutoGarage.Models.PriorityMaster;
using MassAutoGarage.Models.LeadSourceMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class LeadSourceMasterController : Controller
    {
        // GET: LeadSourceMaster
        ClsGeneral objcls = new ClsGeneral();
        LeadSourceMaster_DL objDL = new LeadSourceMaster_DL();


        public ActionResult LeadSourceDetails(string Key)
        {
            List<LeadSourceMasterModel> model = new List<LeadSourceMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new LeadSourceMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        LeadSource = i.LeadSource,
                        LeadID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new LeadSourceMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        LeadSource = i.LeadSource,
                        LeadID = Convert.ToInt64(i.ID),
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
        public ActionResult LeadSource(string ID = "")
        {
            LeadSourceMasterModel model = new LeadSourceMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.LeadSourceMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.LeadSourceMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.LeadSource = lst.LeadSource;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.LeadSourceMasterModelList = objDL.GetCode("41", "Lead Source");
                var promotioncode = model.LeadSourceMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveLeadSourceMaster(LeadSourceMasterModel model)
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

        public JsonResult DeleteLeadSource(Int64 LeadID)
        {
            LeadSourceMasterModel model = new LeadSourceMasterModel();
            var lst = objDL.Delete(LeadID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}