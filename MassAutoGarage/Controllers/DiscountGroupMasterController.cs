using MassAutoGarage.Data.VehicleMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.DiscountGroupMaster;
using MassAutoGarage.Models.VehicleEngine;
using MassAutoGarage.Models.DiscountGroupMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class DiscountGroupMasterController : Controller
    {
        // GET: DiscountGroupMaster
        ClsGeneral objcls = new ClsGeneral();
        DiscountGroupMaster_DL objDL = new DiscountGroupMaster_DL();
        public ActionResult DiscountGroupDetails(string Key)
        {
            List<DiscountGroupMasterModel> model = new List<DiscountGroupMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new DiscountGroupMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DiscountGroup = i.DiscountGroup,
                        DiscountID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new DiscountGroupMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DiscountGroup = i.DiscountGroup,
                        DiscountID = Convert.ToInt64(i.ID),
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
        public ActionResult DiscountGroup(string ID = "")
        {
            DiscountGroupMasterModel model = new DiscountGroupMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.DiscountGroupMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.DiscountGroupMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.DiscountGroup = lst.DiscountGroup;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.DiscountGroupMasterModelList = objDL.GetCode("41", "Discount-Group");
                var promotioncode = model.DiscountGroupMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveDiscountGroupMaster(DiscountGroupMasterModel model)
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

        public JsonResult Delete(Int64 DiscountID)
        {
            DiscountGroupMasterModel model = new DiscountGroupMasterModel();
            var lst = objDL.Delete(DiscountID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}