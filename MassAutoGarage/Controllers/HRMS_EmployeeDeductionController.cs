using MassAutoGarage.Data.HRMS_Leave;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_EmployeeDeduction;
using MassAutoGarage.Data.HRMS_EmployeeDeduction;
using MassAutoGarage.Models.HRMS_Attendance;
using MassAutoGarage.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeDeductionController : Controller
    {
        // GET: HRMS_EmployeeDeduction
        HRMSEmployeeDeductionModel model = new HRMSEmployeeDeductionModel();
        HRMSEmployeeDeductionDL DL = new HRMSEmployeeDeductionDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeDeduction()
        {
            ViewBag.BranchList = DL.DropdownBranchList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();
            ViewBag.DeductionTypeList = DL.DropDeductionTypeTypeList();

            return View();
        }

        double TAmt = 0; 
        public JsonResult GetDeductionList(HRMSEmployeeDeductionModel model, string StDate, string EdDate, string Amount)
        {
            List<HRMSEmployeeDeductionModel> DeductionList = new List<HRMSEmployeeDeductionModel>();
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
                TAmt= TAmt+GetNewAmt;
                DeductionList.Add(new HRMSEmployeeDeductionModel
                {
                    CalculatedDate = d1a.ToString(),
                    Amount = GetNewAmt,
                    TotalAmount = TAmt,
                }); ;
                d1a = d1a.AddMonths(1);
                i++;
            }

            return Json(DeductionList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveDeduction(List<HRMSEmployeeDeductionModel> PatientArr)
        {
            HRMSEmployeeDeductionModel model = new HRMSEmployeeDeductionModel();

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
                var EmployeeDeductionId = model.EmployeeDeductionId;

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.EmployeeDeductionId = EmployeeDeductionId;
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




    }
}