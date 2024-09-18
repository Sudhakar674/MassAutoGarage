using MassAutoGarage.Data.PlateCodeMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.PlateCodeMaster;
using MassAutoGarage.Models.VehicleStateMaster;
using MassAutoGarage.Data.VehicleStateMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class VehicleStateMasterController : Controller
    {
        // GET: VehicleStateMaster
        ClsGeneral objcls = new ClsGeneral();
        VehicleStateMaster_DL objDL = new VehicleStateMaster_DL();

        public ActionResult VehicleStateDetails(string Key)
        {
            List<VehicleStateMasterModel> model = new List<VehicleStateMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new VehicleStateMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        VehicleState = i.VehicleState,
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
                    model.Add(new VehicleStateMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        VehicleState = i.VehicleState,
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
        public ActionResult VehicleState(string ID = "")
        {
            VehicleStateMasterModel model = new VehicleStateMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.VehicleStateMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.VehicleStateMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.VehicleState = lst.VehicleState;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.VehicleStateMasterModelList = objDL.GetCode("41", "Vehicle-State");
                var promotioncode = model.VehicleStateMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveVehicleStateMaster(VehicleStateMasterModel model)
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
            VehicleStateMasterModel model = new VehicleStateMasterModel();
            var lst = objDL.Delete(VehicleID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}