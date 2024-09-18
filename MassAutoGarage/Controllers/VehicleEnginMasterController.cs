using MassAutoGarage.Data.DriverMaster;
using MassAutoGarage.Data;
using MassAutoGarage.Models.DriverMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.VehicleMaster;
using MassAutoGarage.Models.VehicleEngine;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class VehicleEnginMasterController : Controller
    {
        // GET: VehicleEnginMaster

        ClsGeneral objcls = new ClsGeneral();
        VehicleEngineMaster_DL objDL = new VehicleEngineMaster_DL();
        public ActionResult VehicleEnginDetails(string Key)
        {
            List<VehicleEngineMasterModel> model = new List<VehicleEngineMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new VehicleEngineMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        VehicleEngine = i.VehicleEngine,
                        VehicleID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new VehicleEngineMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        VehicleEngine = i.VehicleEngine,
                        VehicleID = Convert.ToInt64(i.ID),
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
        public ActionResult VehicleEngine(string ID = "")
        {
            VehicleEngineMasterModel model = new VehicleEngineMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.VehicleEngineMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.VehicleEngineMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.VehicleEngine = lst.VehicleEngine;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.VehicleEngineMasterModelList = objDL.GetCode("41", "Vehical-Engine");
                var promotioncode = model.VehicleEngineMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveVehicleEngineMaster(VehicleEngineMasterModel model)
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

        public JsonResult Delete(Int64 VehicleID)
        {
            VehicleEngineMasterModel model = new VehicleEngineMasterModel();
            var lst = objDL.Delete(VehicleID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}