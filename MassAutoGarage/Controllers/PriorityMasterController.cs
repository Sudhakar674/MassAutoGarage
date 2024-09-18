using MassAutoGarage.Data.SalemanMaster;
using MassAutoGarage.Data;
using MassAutoGarage.Models.SalesmanMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.PriorityMaster;
using MassAutoGarage.Models.PriorityMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class PriorityMasterController : Controller
    {
        // GET: PriorityMaster

        ClsGeneral objcls = new ClsGeneral();
        PriorityMaster_DL objDL = new PriorityMaster_DL();

        public ActionResult PriorityDetails(string Key)
        {
            List<PriorityMasterModel> model = new List<PriorityMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new PriorityMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Priority = i.Priority,                        
                        PriorityID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new PriorityMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Priority = i.Priority,
                        PriorityID = Convert.ToInt64(i.ID),
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
        public ActionResult CreatePriority(string ID = "")
        {
            PriorityMasterModel model = new PriorityMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.PriorityMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.PriorityMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.Priority = lst.Priority;                
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.PriorityMasterModelList = objDL.GetCode("41", "Priority");
                var promotioncode = model.PriorityMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SavePriorityMaster(PriorityMasterModel model)
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

        public JsonResult DeletePrioity(Int64 PriorityID)
        {
            PriorityMasterModel model = new PriorityMasterModel();
            var lst = objDL.Delete(PriorityID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}