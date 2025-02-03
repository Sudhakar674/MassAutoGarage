using MassAutoGarage.Data.HR_FinalClearanceReport;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_FinalClearanceReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_LeaveClearance;
using MassAutoGarage.Data.HR_LeaveClearance;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HR_LeaveClearanceController : Controller
    {
        // GET: HR_LeaveClearance
        HR_LeaveClearanceModel model = new HR_LeaveClearanceModel();
        HR_LeaveClearanceDL DL = new HR_LeaveClearanceDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult LeaveClearance(HR_LeaveClearanceModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "37";
                var lst = DL.GetLeaveClearanceDetaildById(model).FirstOrDefault();

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
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
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
            List<HR_LeaveClearanceModel> GetMaxVoucher = new List<HR_LeaveClearanceModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_LeaveClearanceModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveLeaveClearance(HR_LeaveClearanceModel model)
        {
            try
            {
                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.LastWorkingDay = string.IsNullOrEmpty(model.LastWorkingDay) ? null : Common.ConvertToSystemDate(model.LastWorkingDay, "dd/MM/yyyy");
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
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
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
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

        public ActionResult LeaveClearanceList(string Key)
        {
            List<HR_LeaveClearanceModel> LeaveClearanceList = new List<HR_LeaveClearanceModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("36", Key);
                foreach (var i in GroupList)
                {
                    LeaveClearanceList.Add(new HR_LeaveClearanceModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
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
                var GroupList = DL.GetLeaveClearanceList();
                foreach (var i in GroupList)
                {
                    LeaveClearanceList.Add(new HR_LeaveClearanceModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
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
            return View(LeaveClearanceList);
        }


        [HttpPost]
        public ActionResult DeleteLeaveClearance(HR_LeaveClearanceModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteLeaveClearance(model);
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

        public ActionResult ViewLeaveClearance(string Id)
        {

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var lst = DL.GetLeaveClearanceDetailsById("38", Id).FirstOrDefault();
                if (lst != null)
                {
                    model.Result = "yes";
                    model.VoucherNo = lst.VoucherNo;
                    model.EmployeeName = lst.EmployeeName;
                    model.Date = lst.Date;
                    model.Designation = lst.Designation;
                    model.EmpNo = lst.EmpNo;
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
                    model.DepartmentName = lst.DepartmentName;
                    model.LastWorkingDay = lst.LastWorkingDay;
                    model.Vehichle = lst.Vehichle;
                    model.Laptop = lst.Laptop;
                    model.CompanySim = lst.CompanySim;
                    model.MedicalInsurance = lst.MedicalInsurance;
                    model.C3Card = lst.C3Card;
                    model.Replacement = lst.Replacement;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}