using MassAutoGarage.Data.HRMS_Attendance;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_Bonus;
using MassAutoGarage.Data.HRMS_Bonus;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using DocumentFormat.OpenXml.Spreadsheet;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HRMS_BonusController : Controller
    {
        // GET: HRMS_Bonus
        HRMSBonusModel model = new HRMSBonusModel();
        HRMSBonusDL DL = new HRMSBonusDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSBonusModel> BonusList = new List<HRMSBonusModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("35", Key);
                foreach (var i in GroupList)
                {
                    BonusList.Add(new HRMSBonusModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        BonusAmount = i.BonusAmount,
                        BonusDate = i.BonusDate,
                        Remarks = i.Remarks
                    });
                }
            }
            else
            {
                var GroupList = DL.GetBonusList();
            foreach (var i in GroupList)
            {
                BonusList.Add(new HRMSBonusModel
                {
                    Idencrept = objcls.Encrypt(i.ID),
                    BranchName = i.BranchName,
                    EmployeeName = i.EmployeeName,
                    BonusAmount = i.BonusAmount,
                    BonusDate = i.BonusDate,
                    Remarks = i.Remarks
                });
            }
            }
            return View(BonusList);
        }

        public ActionResult Bonus(HRMSBonusModel model,string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();

            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "34";
                var lst = DL.GetBonusDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.EmployeeId = lst.EmployeeId;
                    model.BonusAmount = lst.BonusAmount;
                    model.BonusDate = lst.BonusDate;
                    model.Remarks = lst.Remarks;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveBonus(HRMSBonusModel model)
        {
            try
            {
                if (model.ID == null || model.ID == "")
                {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model.BonusDate = string.IsNullOrEmpty(model.BonusDate) ? null : Common.ConvertToSystemDate(model.BonusDate, "dd/MM/yyyy");              
                model = DL.AddUpdate(model);
                if (model.Message == "1")
                {
                    model.Result = "yes";
                }
                else
                {
                    model.Result = "";
                }
                }
                else
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.Idencrept = objcls.Decrypt(model.ID);
                    model.QueryType = "21";
                    model.BonusDate = string.IsNullOrEmpty(model.BonusDate) ? null : Common.ConvertToSystemDate(model.BonusDate, "dd/MM/yyyy");
                    model = DL.AddUpdate(model);
                    if (model.Message == "1")
                    {
                        model.Result = "yes1";
                    }
                    else
                    {
                        model.Result = "";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteBonus(HRMSBonusModel model, string Id)
        {
            try
            {

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteBonusDetails(model);
                if (model.Message == "1")
                {
                    model.Result = "yes";
                }
                else
                {
                    model.Result = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }



















    }
}