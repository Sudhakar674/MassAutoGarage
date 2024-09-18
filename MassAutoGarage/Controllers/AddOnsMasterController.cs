using DocumentFormat.OpenXml.EMMA;
using MassAutoGarage.Data;
using MassAutoGarage.Data.AddOnsMaster;
using MassAutoGarage.Data.CompanyMaster;
using MassAutoGarage.Models.AddOnsMaster;
using MassAutoGarage.Models.ColorMaster;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class AddOnsMasterController : Controller
    {
        // GET: AddOnsMaster
        ClsGeneral objcls = new ClsGeneral();
        AddOnsMaster_DL objDL = new AddOnsMaster_DL();
        public ActionResult OnsDetails(string Key)
        {
            List<AddOnsMasterModel> model = new List<AddOnsMasterModel>();
            if (Session["userId"] != null && Convert.ToInt64(Session["userId"]) > 0)
            {
                if (Key != "" && Key != null)
                {
                    var GroupList = objDL.SearchByKey("43", Key);
                    foreach (var i in GroupList)
                    {
                        model.Add(new AddOnsMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            ServiceName = i.ServiceName,
                            Comission = i.Comission,
                            ComissionAmount = i.ComissionAmount,
                            AddOnsID = Convert.ToInt64(i.ID),

                        });
                    }

                }
                else
                {
                    var GroupList = objDL.ToList();
                    foreach (var i in GroupList)
                    {
                        model.Add(new AddOnsMasterModel
                        {
                            ID = objcls.Encrypt(i.ID),
                            Code = i.Code,
                            ServiceName = i.ServiceName,
                            Comission = i.Comission,
                            ComissionAmount = i.ComissionAmount,
                            AddOnsID = Convert.ToInt64(i.ID),

                        });
                    }
                }

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
        public ActionResult AddOns(string ID = "")
        {
            AddOnsMasterModel model = new AddOnsMasterModel();
            Dropdown();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.AddOnsMasterModelList = objDL.GetlstIdWise("42", id);
                var lst = model.AddOnsMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.ID = lst.ID;
                    model.Code = lst.Code;
                    model.ServiceID = lst.ServiceID;
                    model.Comission = lst.Comission;
                    model.ComissionAmount = lst.ComissionAmount;
                   
                }
            }
            else
            {
                model.AddOnsMasterModelList = objDL.GetCode("41", "Add ons");
                var promotioncode = model.AddOnsMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;

                }
            }
            return View(model);
        }

        public JsonResult SaveAddONSMaster(AddOnsMasterModel model)
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

        public JsonResult DeleteAddONS(Int64 AddONSID)
        {
            AddOnsMasterModel model = new AddOnsMasterModel();
            var lst = objDL.Delete(AddONSID);
            return Json(lst.Flag, JsonRequestBehavior.AllowGet);
        }
        private void Dropdown()
        {

            ViewBag.ServiceList = DbMaster.DropdownList("41", 19);

        }
    }
}