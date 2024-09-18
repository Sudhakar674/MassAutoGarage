using MassAutoGarage.Data.VehicleMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.CylinderMaster;
using MassAutoGarage.Models.VehicleEngine;
using MassAutoGarage.Models.CylinderMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class CylinderMasterController : Controller
    {
        // GET: CylinderMaster
        ClsGeneral objcls = new ClsGeneral();
        CylinderMaster_DL objDL = new CylinderMaster_DL();
        public ActionResult CylinderDetails(string Key)
        {
            List<CylinderMasterModel> model = new List<CylinderMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new CylinderMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Cylinder = i.Cylinder,
                        CylinderID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new CylinderMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        Cylinder = i.Cylinder,
                        CylinderID = Convert.ToInt64(i.ID),
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

        public ActionResult CreateCylinder(string ID = "")
        {
            CylinderMasterModel model = new CylinderMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.CylinderMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.CylinderMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.Cylinder = lst.Cylinder;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.CylinderMasterModelList = objDL.GetCode("41", "Cylinder");
                var promotioncode = model.CylinderMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveCylinderMaster(CylinderMasterModel model)
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

        public JsonResult Delete(Int64 CylinderID)
        {
            CylinderMasterModel model = new CylinderMasterModel();
            var lst = objDL.Delete(CylinderID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}