using MassAutoGarage.Data.ChargerTypeMaster;
using MassAutoGarage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.PlateCodeMaster;
using MassAutoGarage.Models.ChargerTypeMaster;
using MassAutoGarage.Models.PlateCodeMaster;
using MassAutoGarage.Data.CompanyMaster;

namespace MassAutoGarage.Controllers
{
    public class PlateCodeMasterController : Controller
    {
        // GET: PlateCodeMaster
        ClsGeneral objcls = new ClsGeneral();
        PlateCodeMaster_DL objDL = new PlateCodeMaster_DL();
        public ActionResult PlateCodeDetails(string Key)
        {
            List<PlateCodeMasterModel> model = new List<PlateCodeMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new PlateCodeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        PlateCode = i.PlateCode,
                        PlatecodeID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new PlateCodeMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        PlateCode = i.PlateCode,
                        PlatecodeID = Convert.ToInt64(i.ID),
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
        public ActionResult PlateCode(string ID = "")
        {
            PlateCodeMasterModel model = new PlateCodeMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.PlateCodeMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.PlateCodeMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.PlateCode = lst.PlateCode;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.PlateCodeMasterModelList = objDL.GetCode("41", "Plate-Code");
                var promotioncode = model.PlateCodeMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SavePlateCodeMaster(PlateCodeMasterModel model)
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

        public JsonResult Delete(Int64 PlatecodeID)
        {
            PlateCodeMasterModel model = new PlateCodeMasterModel();
            var lst = objDL.Delete(PlatecodeID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }

    }
}