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
using MassAutoGarage.Models.HRMS_EmployeeDeduction;

namespace MassAutoGarage.Controllers
{
    public class HRMS_BonusController : Controller
    {
        // GET: HRMS_Bonus
        HRMSBonusModel model = new HRMSBonusModel();
        HRMSBonusDL DL = new HRMSBonusDL();
        ClsGeneral objcls = new ClsGeneral();

        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult Bonus(HRMSBonusModel model)
        {
            ViewBag.BranchList = DL.DropdownBranchList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();
            ViewBag.DeductionTypeList = DL.DropDeductionTypeTypeList();
            return View();
        }

        double TAmt = 0;
        public JsonResult GetBonusList(HRMSBonusModel model, string StDate, string EdDate, string Amount)
        {
            List<HRMSBonusModel> BonusList = new List<HRMSBonusModel>();
            string result = string.Empty;
            string startDate = StDate;
            string endDate = EdDate;

            DateTime d1a = DateTime.Parse(startDate, new System.Globalization.CultureInfo("pt-BR"));
            DateTime d2a = DateTime.Parse(endDate, new System.Globalization.CultureInfo("pt-BR"));
            int months = Math.Abs(d2a.Subtract(d1a).Days / (365 / 12));


            double GetAmount = Convert.ToDouble(Amount);
            int i = 1;
            while (i <= months)
            {
                double GetNewAmt = (GetAmount / months);
                TAmt = TAmt + GetNewAmt;
                BonusList.Add(new HRMSBonusModel
                {
                    CalculatedDate = d1a.ToString(),
                    Amount = GetNewAmt,
                    TotalAmount = TAmt,
                }); ;
                d1a = d1a.AddMonths(1);
                i++;
            }

            return Json(BonusList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveBonus(List<HRMSBonusModel> PatientArr)
        {
            HRMSBonusModel model = new HRMSBonusModel();

            try
            {
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "11";
                model.BranchId = PatientArr[0].BranchId;
                model.EmployeeId = PatientArr[0].EmployeeId;
                model.Amount = PatientArr[0].Amount;
                model.FromDate = PatientArr[0].FromDate;
                model.ToDate = PatientArr[0].ToDate;
                model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                model.DeductionTypeId = PatientArr[0].DeductionTypeId;
                model.Remarks = PatientArr[0].Remarks;
                model.TotalAmount = PatientArr[0].TotalAmount;
                model = DL.AddUpdate(model);
                var BonusId = model.BonusId;

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.BonusId = BonusId;
                    model.MonthYear = Attch.MonthYear;
                    model.MonthYear = string.IsNullOrEmpty(model.MonthYear) ? null : Common.ConvertToSystemDate(model.MonthYear, "dd/MM/yyyy");
                    model.Amount1 = Attch.Amount1;
                    model = DL.AddUpdateBulk(model);
                }
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
























        //public ActionResult Index(string Key)
        //{
        //    List<HRMSBonusModel> BonusList = new List<HRMSBonusModel>();

        //    if (Key != "" && Key != null)
        //    {
        //        var GroupList = DL.SearchByKey("35", Key);
        //        foreach (var i in GroupList)
        //        {
        //            BonusList.Add(new HRMSBonusModel
        //            {
        //                Idencrept = objcls.Encrypt(i.ID),
        //                BranchName = i.BranchName,
        //                EmployeeName = i.EmployeeName,
        //                BonusAmount = i.BonusAmount,
        //                BonusDate = i.BonusDate,
        //                Remarks = i.Remarks
        //            });
        //        }
        //    }
        //    else
        //    {
        //        var GroupList = DL.GetBonusList();
        //    foreach (var i in GroupList)
        //    {
        //        BonusList.Add(new HRMSBonusModel
        //        {
        //            Idencrept = objcls.Encrypt(i.ID),
        //            BranchName = i.BranchName,
        //            EmployeeName = i.EmployeeName,
        //            BonusAmount = i.BonusAmount,
        //            BonusDate = i.BonusDate,
        //            Remarks = i.Remarks
        //        });
        //    }
        //    }
        //    return View(BonusList);
        //}

        //public ActionResult Bonus(HRMSBonusModel model,string Id)
        //{
        //    ViewBag.BranchList = DL.DropdownList();
        //    ViewBag.EmployeeList = DL.DropDownEmployeeList();

        //    if (Id != null)
        //    {
        //        model.Idencrept = objcls.Decrypt(Id);
        //        model.QueryType = "34";
        //        var lst = DL.GetBonusDetailsById(model).FirstOrDefault();

        //        if (lst != null)
        //        {
        //            model.BranchId = lst.BranchId;
        //            model.EmployeeId = lst.EmployeeId;
        //            model.BonusAmount = lst.BonusAmount;
        //            model.BonusDate = lst.BonusDate;
        //            model.Remarks = lst.Remarks;
        //        }
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult SaveBonus(HRMSBonusModel model)
        //{
        //    try
        //    {
        //        if (model.ID == null || model.ID == "")
        //        {
        //        model.CreatedBy = Session["userId"].ToString();
        //        model.QueryType = "11";
        //        model.BonusDate = string.IsNullOrEmpty(model.BonusDate) ? null : Common.ConvertToSystemDate(model.BonusDate, "dd/MM/yyyy");              
        //        model = DL.AddUpdate(model);
        //        if (model.Message == "1")
        //        {
        //            model.Result = "yes";
        //        }
        //        else
        //        {
        //            model.Result = "";
        //        }
        //        }
        //        else
        //        {
        //            model.CreatedBy = Session["userId"].ToString();
        //            model.Idencrept = objcls.Decrypt(model.ID);
        //            model.QueryType = "21";
        //            model.BonusDate = string.IsNullOrEmpty(model.BonusDate) ? null : Common.ConvertToSystemDate(model.BonusDate, "dd/MM/yyyy");
        //            model = DL.AddUpdate(model);
        //            if (model.Message == "1")
        //            {
        //                model.Result = "yes1";
        //            }
        //            else
        //            {
        //                model.Result = "";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult DeleteBonus(HRMSBonusModel model, string Id)
        //{
        //    try
        //    {

        //        model.Idencrept = objcls.Decrypt(Id);
        //        model.QueryType = "41";
        //        model = DL.DeleteBonusDetails(model);
        //        if (model.Message == "1")
        //        {
        //            model.Result = "yes";
        //        }
        //        else
        //        {
        //            model.Result = "";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Json(model, JsonRequestBehavior.AllowGet);

        //}



    }
}