using MassAutoGarage.Data;
using MassAutoGarage.Data.VATMaster;
using MassAutoGarage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.CompanyMaster;


namespace MassAutoGarage.Controllers
{
    public class VATMasterController : Controller
    {
        // GET: VATMaster
        ClsGeneral objcls = new ClsGeneral();
        VATMaster_DL objDL = new VATMaster_DL();
        public ActionResult VATDetails(string Key)
        {

           
            List<VATMasterModel> model = new List<VATMasterModel>();          
            if (Key != "" && Key != null)
            {
                var GroupList = objDL.SearchVATMaster("43", Key);
                foreach (var i in GroupList)
                {
                    model.Add(new VATMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        CompanyName = i.CompanyName,
                        VAT = i.VAT,
                        StartDate = i.StartDate,
                        EndDate = i.EndDate,
                        Printing = i.Printing,
                        VatID = i.Id
                       
                    });
                }
              
            }
            else
            {
                var GroupList = objDL.ToList();
                foreach (var i in GroupList)
                {
                    model.Add(new VATMasterModel
                    {
                        Id = objcls.Encrypt(i.Id),
                        Code = i.Code,
                        CompanyName = i.CompanyName,
                        VAT = i.VAT,
                        StartDate = i.StartDate,
                        EndDate = i.EndDate,
                        Printing = i.Printing,
                        VatID = i.Id,
                       
                    });
                }
             
            }

            ViewBag.VatList = model.ToList();
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
        public ActionResult CreatVAT(string ID = "")
        {
            Dropdown();
            VATMasterModel model = new VATMasterModel();

            if (ID != "")
            {
                Int64 id = Convert.ToInt64(objcls.Decrypt(ID));

                model.VATMasterModelList = objDL.GetVATMasterIdWise("42", id);
                var lst = model.VATMasterModelList.FirstOrDefault();
                if (lst != null)
                {
                    model.Id = lst.Id;
                    model.Code = lst.Code;
                    model.CompanyId = lst.CompanyId;
                    model.VAT = lst.VAT;
                    model.StartDate = lst.StartDate;
                    model.EndDate = lst.EndDate;
                    model.Printing = lst.Printing;

                }
            }
            else
            {
                model.VATMasterModelList = objDL.GetCode("41", "VAT");
                var promotioncode = model.VATMasterModelList.FirstOrDefault();
                if (promotioncode != null)
                {

                    model.Code = promotioncode.Code;
                    model.CurrentCount = promotioncode.CurrentCount;


                }
            }
            return View(model);
        }
        public JsonResult SaveVATMaster(VATMasterModel model)
        {
            string result = string.Empty;
            try
            {

                if (model.Id != "" && model.Id != null)
                {

                    DateTime sDate = DateTime.Parse(model.StartDate);
                    DateTime eDate = DateTime.Parse(model.EndDate);
                    model.QueryType = "21";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.StrDate = sDate;
                    model.EdingDate = eDate;
                    model.Id = objcls.Decrypt(model.Id);
                    model = objDL.AddUpd(model);
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
                    DateTime sDate = DateTime.Parse(model.StartDate);
                    DateTime eDate = DateTime.Parse(model.EndDate);
                    model.QueryType = "11";
                    if (Session["userId"] != null)
                    {
                        model.CreatedBy = Convert.ToInt64(Session["userId"]);
                    }
                    model.StrDate = sDate;
                    model.EdingDate = eDate;
                    model = objDL.AddUpd(model);
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
        private void Dropdown()
        {
            ViewBag.Company = DbMaster.DropdownList("41", 4);


        }
        public JsonResult LoadCode(int userId)
        {
            DbMaster obj = new DbMaster();
            var UserTypelist = obj.getValue("41", 5, userId);
            return Json(UserTypelist.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteVat(Int64 VatID)
        {
            var res = objDL.Delete(VatID);
            return Json(res.Flag, JsonRequestBehavior.AllowGet);
        }
    }
}