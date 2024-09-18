using MassAutoGarage.Data.UnitMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.DriverMaster;
using MassAutoGarage.Models.UnitMaster;
using MassAutoGarage.Models.DriverMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class DriverMasterController : Controller
    {
        // GET: DriverMaster
        ClsGeneral objcls = new ClsGeneral();
        DriverMaster_DL objDL = new DriverMaster_DL();


        public ActionResult DriverDetails(string Key)
        {
            List<DriverMasterModel> model = new List<DriverMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new DriverMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DriverName = i.DriverName,
                        DriverID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new DriverMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        DriverName = i.DriverName,
                        DriverID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateDriver(string ID = "")
        {
            DriverMasterModel model = new DriverMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.DriverMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.DriverMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.DriverName = lst.DriverName;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.DriverMasterModelList = objDL.GetCode("41", "Driver");
                var promotioncode = model.DriverMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveDriverMaster(DriverMasterModel model)
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

        public JsonResult Delete(Int64 DriveID)
        {
            DriverMasterModel model = new DriverMasterModel();
            var lst = objDL.Delete(DriveID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}