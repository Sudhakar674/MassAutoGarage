using MassAutoGarage.Data.StatusMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.SubStatusMaster;
using MassAutoGarage.Models.StatusMaster;
using MassAutoGarage.Models.SubStatusMaster;
using MassAutoGarage.Models.DepartmentMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class SubStatusController : Controller
    {
        // GET: SubStatus
        ClsGeneral objcls = new ClsGeneral();
        SubStatusMaster_DL objDL = new SubStatusMaster_DL();

        public ActionResult SubStatusDetails(string Key)
        {
            List<SubStatusMasterModel> model = new List<SubStatusMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new SubStatusMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SubStatus = i.SubStatus,
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
                    model.Add(new SubStatusMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        SubStatus = i.SubStatus,
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
        public ActionResult CreateSubStatus(string ID = "")
        {
            SubStatusMasterModel model = new SubStatusMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.SubStatusMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.SubStatusMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.SubStatus = lst.SubStatus;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.SubStatusMasterModelList = objDL.GetCode("41", "Sub-Status");
                var promotioncode = model.SubStatusMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveSubStatusMaster(SubStatusMasterModel model)
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

        public JsonResult DeleteSubStatus(Int64 StatusID)
        {
            SubStatusMasterModel model = new SubStatusMasterModel();
            var lst = objDL.Delete(StatusID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}