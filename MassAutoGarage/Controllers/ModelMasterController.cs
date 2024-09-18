using MassAutoGarage.Data;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Data.MakeMaster;
using MassAutoGarage.Data.ModelMaster;
using MassAutoGarage.Models.MakeMaster;
using MassAutoGarage.Models.ModelMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class ModelMasterController : Controller
    {
        // GET: ModelMaster
        ClsGeneral objcls = new ClsGeneral();
        ModelMaster_DL objDL = new ModelMaster_DL();

        public ActionResult ModelDetails(string Key)
        {
            List<ModelMasterModels> model = new List<ModelMasterModels>();
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchByKey("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new ModelMasterModels
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        MakeName = i.MakeName,
                        ModelName = i.ModelName,
                        ModelID = Convert.ToInt64(i.ID),
                        IsActive = i.IsActive
                    });
                }

            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new ModelMasterModels
                    {
                        ID = objcls.Encrypt(i.ID),
                        Code = i.Code,
                        MakeName = i.MakeName,
                        ModelName = i.ModelName,
                        ModelID = Convert.ToInt64(i.ID),
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
        public ActionResult CreateModel(string ID = "")
        {
            Dropdown();
            ModelMasterModels model = new ModelMasterModels();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.ModelMasterModelsList = objDL.GetlstIdWise("42", id);
                var lst = model.ModelMasterModelsList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.MakeId = lst.MakeId;
                    model.ModelName = lst.ModelName;
                    model.IsActive = lst.IsActive;
                }
            }
            else
            {
                model.ModelMasterModelsList = objDL.GetCode("41", "Modal");
                var promotioncode = model.ModelMasterModelsList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }

        public JsonResult SaveModelMaster(ModelMasterModels model)
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

        public JsonResult DeleteModel(Int64 ModelID)
        {
            ModelMasterModels model = new ModelMasterModels();
            var lst = objDL.Delete(ModelID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
        private void Dropdown()
        {
            ViewBag.Makelist = DbMaster.DropdownList("41", 9);

        }
    }
}