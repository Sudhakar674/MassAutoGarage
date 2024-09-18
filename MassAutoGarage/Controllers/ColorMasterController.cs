using MassAutoGarage.Data;
using MassAutoGarage.Data.ColorMaster;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.ModelMaster;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.ModelMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class ColorMasterController : Controller
    {
        // GET: ColorMaster
        ClsGeneral objcls = new ClsGeneral();       
        ColorMaster_DL objDL= new ColorMaster_DL(); 
        public ActionResult ColorDetails(string Key)
        {
            List<ColorMasterModel> model = new List<ColorMasterModel>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new ColorMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        ColorName = i.ColorName,
                        ColorCode = i.ColorCode,
                        ColorMasterID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new ColorMasterModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        ColorName = i.ColorName,
                        ColorCode = i.ColorCode,
                        ColorMasterID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateColor(string ID = "")
        {
            ViewBag.Colorlist = objDL.LoadColorToList();

            ColorMasterModel model = new ColorMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.ColorMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.ColorMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.ColorId = lst.ColorId;
                    model.ColorName = lst.ColorName;
                    model.IsActive = lst.IsActive;
                    ViewBag.color = lst.ColorCode;
                }
            }
            else
            {
                model.ColorMasterModelList = objDL.GetCode("41", "Color");
                var promotioncode = model.ColorMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult LoadColorCode(int colorId)
        {            
            var UserTypelist = objDL.getValue("42", colorId);
            return Json(UserTypelist.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveColorMaster(ColorMasterModel model)
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

        public JsonResult DeleteColor(Int64 colorid)
        {
            ColorMasterModel model = new ColorMasterModel();
            var lst = objDL.Delete(colorid);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}