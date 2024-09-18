using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.StatusMaster;
using MassAutoGarage.Models.DepartmentMaster;
using MassAutoGarage.Models.StatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        ClsGeneral objcls = new ClsGeneral();
        StatusMaster_DL objDL = new StatusMaster_DL();

        public ActionResult StatusDetails(string Key)
        {
            List<StatusMasterModel> model = new List<StatusMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchDepartmentMaster("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new StatusMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Status = i.Status,
                        StatusID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new StatusMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Status = i.Status,
                        StatusID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateStatus(string ID = "")
        {
            StatusMasterModel model = new StatusMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.StatusMasterModelList = objDL.GetStatusstIdWise("42", id);
                var lst = model.StatusMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.Status = lst.Status;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.StatusMasterModelList = objDL.GetCode("41", "Status");
                var promotioncode = model.StatusMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveStatusMaster(StatusMasterModel model)
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

        public JsonResult DeleteStatus(Int64 StatusID)
        {
            DepartmentMasterModel model = new DepartmentMasterModel();
            var lst = objDL.Delete(StatusID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}