using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using MassAutoGarage.Data.HR_FinalClearanceReport;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace MassAutoGarage.Controllers
{
    public class HR_FinalClearanceReportController : Controller
    {
        // GET: HR_FinalClearanceReport
        HR_FinalClearanceReportModel model = new HR_FinalClearanceReportModel();
        HR_FinalClearanceReportDL DL = new HR_FinalClearanceReportDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult FinalClearanceReport(HR_FinalClearanceReportModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "37";
                var lst = DL.GetFinalClearanceReportDetaildById(model).FirstOrDefault();

                if (lst.Vehichle == true)
                {
                    model.Vehichle = true;
                }
                else
                {
                    model.Vehichle = false;
                }
                if (lst.Laptop == true)
                {
                    model.Laptop = true;
                }
                else
                {
                    model.Laptop = false;
                }

                if (lst.CompanySim == true)
                {
                    model.CompanySim = true;
                }
                else
                {
                    model.CompanySim = false;
                }

                if (lst.MedicalInsurance == true)
                {
                    model.MedicalInsurance = true;
                }
                else
                {
                    model.MedicalInsurance = false;
                }

                if (lst.C3Card == true)
                {
                    model.C3Card = true;
                }
                else
                {
                    model.C3Card = false;
                }

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.DepartmentId = lst.DepartmentId;
                    model.LastWorkingDay = lst.LastWorkingDay;
                    model.Replacement = lst.Replacement;
                    ViewBag.ButtonText = "Update";
                }
            }
            return View(model);
        }

        public ActionResult GetMaxVoucher()
        {
            List<HR_FinalClearanceReportModel> GetMaxVoucher = new List<HR_FinalClearanceReportModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_FinalClearanceReportModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveFinalClearanceReport(HR_FinalClearanceReportModel model)
        {
            try
            {
                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.LastWorkingDay = string.IsNullOrEmpty(model.LastWorkingDay) ? null : Common.ConvertToSystemDate(model.LastWorkingDay, "dd/MM/yyyy");
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
                    model.QueryType = "21";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.LastWorkingDay = string.IsNullOrEmpty(model.LastWorkingDay) ? null : Common.ConvertToSystemDate(model.LastWorkingDay, "dd/MM/yyyy");
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

        public ActionResult FinalClearanceReportList(string Key)
        {
            List<HR_FinalClearanceReportModel> FinalClearanceReportList = new List<HR_FinalClearanceReportModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    FinalClearanceReportList.Add(new HR_FinalClearanceReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        DepartmentName = i.DepartmentName,
                        LastWorkingDay = i.LastWorkingDay,
                        Vehichle = i.Vehichle,
                        Laptop = i.Laptop,
                        CompanySim = i.CompanySim,
                        MedicalInsurance = i.MedicalInsurance,
                        C3Card = i.C3Card,
                        Replacement = i.Replacement
                    });
                }
            }
            else
            {
                var GroupList = DL.GetFinalClearanceReportList();
                foreach (var i in GroupList)
                {
                    FinalClearanceReportList.Add(new HR_FinalClearanceReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        DepartmentName = i.DepartmentName,
                        LastWorkingDay = i.LastWorkingDay,
                        Vehichle = i.Vehichle,
                        Laptop = i.Laptop,
                        CompanySim = i.CompanySim,
                        MedicalInsurance = i.MedicalInsurance,
                        C3Card = i.C3Card,
                        Replacement = i.Replacement
                    });
                }
            }
            return View(FinalClearanceReportList);
        }


        [HttpPost]
        public ActionResult DeleteFinalClearanceReport(HR_FinalClearanceReportModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteFinalClearanceReport(model);
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