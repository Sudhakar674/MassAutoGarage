using MassAutoGarage.Data.HRMS_Loan;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Data.HR_GeneralRequest;
using Microsoft.Azure.Pipelines.WebApi;
using Org.BouncyCastle.Asn1.X509;
using MassAutoGarage.Models.HRMS_EmployeeBankDetails;
using System.Data;
using MassAutoGarage.Models.HRMS_SalesTarget;
using MassAutoGarage.Models;
using System.IO;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using NPOI.SS.Formula.Functions;
using Microsoft.VisualStudio.Services.Common;
using Org.BouncyCastle.Ocsp;

namespace MassAutoGarage.Controllers
{
    public class HR_GeneralRequestController : Controller
    {
        // GET: HR_GeneralRequest
        HR_GeneralRequestModel model = new HR_GeneralRequestModel();
        HR_GeneralRequestDL DL = new HR_GeneralRequestDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult GeneralRequest(HR_GeneralRequestModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ddlDepartment = DL.ddlDepartment();

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "38";
                var lst = DL.GetGeneralRequestDetaildById(model).FirstOrDefault();

                if (lst.SalaryCertificate == true)
                {
                    model.SalaryCertificate = true;
                }
                else
                {
                    model.SalaryCertificate = false;
                }
                if (lst.SalaryTransferLetter == true)
                {
                    model.SalaryTransferLetter = true;
                }
                else
                {
                    model.SalaryTransferLetter = false;
                }

                if (lst.NOC == true)
                {
                    model.NOC = true;
                }
                else
                {
                    model.NOC = false;
                }

                if (lst.ExperienceCertificate == true)
                {
                    model.ExperienceCertificate = true;
                }
                else
                {
                    model.ExperienceCertificate = false;
                }

                if (lst.OpneNewBankAcct == true)
                {
                    model.OpneNewBankAcct = true;
                }
                else
                {
                    model.OpneNewBankAcct = false;
                }

                if (lst.TransferLoanToOtherBank == true)
                {
                    model.TransferLoanToOtherBank = true;
                }
                else
                {
                    model.TransferLoanToOtherBank = false;
                }

                if (lst.PersonalLoan == true)
                {
                    model.PersonalLoan = true;
                }
                else
                {
                    model.PersonalLoan = false;
                }

                if (lst.NOCToEmbassy == true)
                {
                    model.NOCToEmbassy = true;
                }
                else
                {
                    model.NOCToEmbassy = false;
                }

                if (lst.ConfirmationLettrToBank == true)
                {
                    model.ConfirmationLettrToBank = true;
                }
                else
                {
                    model.ConfirmationLettrToBank = false;
                }

                if (lst.LoanTopUp == true)
                {
                    model.LoanTopUp = true;
                }
                else
                {
                    model.LoanTopUp = false;
                }

                if (lst.Others == true)
                {
                    model.Others = true;
                }
                else
                {
                    model.Others = false;
                }

                if (lst.InitialNewEmp == true)
                {
                    model.InitialNewEmp = true;
                }
                else
                {
                    model.InitialNewEmp = false;
                }

                if (lst.Against == true)
                {
                    model.Against = true;
                }
                else
                {
                    model.Against = false;
                }

                if (lst.SalarySlips3Months == true)
                {
                    model.SalarySlips3Months = true;
                }
                else
                {
                    model.SalarySlips3Months = false;
                }

                if (lst.SalarySlips6Months == true)
                {
                    model.SalarySlips6Months = true;
                }
                else
                {
                    model.SalarySlips6Months = false;
                }

                if (lst.SalaryCard == true)
                {
                    model.SalaryCard = true;
                }
                else
                {
                    model.SalaryCard = false;
                }

                if (lst != null)
                {
                    model.VoucherNumber = lst.VoucherNumber;

                    model.hdfVoucherNumber = lst.VoucherNumber;
                    
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.BranchId = lst.BranchId;
                    model.DepartmentId = lst.DepartmentId;
                    model.EmpId = lst.EmpId;
                    //model.SalaryTransferLetter = lst.SalaryTransferLetter;
                    //model.NOC = lst.NOC;
                    //model.ExperienceCertificate = lst.ExperienceCertificate;
                    model.BankEstablishment = lst.BankEstablishment;
                    model.AcctNoIBANNo = lst.AcctNoIBANNo;
                    //model.OpneNewBankAcct = lst.OpneNewBankAcct;
                    //model.TransferLoanToOtherBank = lst.TransferLoanToOtherBank;
                    //model.PersonalLoan = lst.PersonalLoan;
                    //model.NOCToEmbassy = lst.NOCToEmbassy;
                    //model.ConfirmationLettrToBank = lst.ConfirmationLettrToBank;
                    //model.LoanTopUp = lst.LoanTopUp;
                    //model.Others = lst.Others;
                    model.CashAdvance = lst.CashAdvance;
                    //model.InitialNewEmp = lst.InitialNewEmp;
                    //model.Against = lst.Against;
                    model.BehalfAgainst = lst.BehalfAgainst;
                    model.Reason = lst.Reason;
                    model.MonthlyDeduction = lst.MonthlyDeduction;
                    //model.SalarySlips3Months = lst.SalarySlips3Months;
                    //model.SalarySlips6Months = lst.SalarySlips6Months;
                    model.TrafficFineDeductionAmt = lst.TrafficFineDeductionAmt;
                    //model.SalaryCard = lst.SalaryCard;
                    model.EmpSignature = lst.EmpSignature;
                    model.MobileNumber = lst.MobileNumber;
                }
            }
            return View(model);
        }


        public ActionResult GetMaxVoucher()
        {
            List<HRMSOverTimeModel> GetMaxVoucher = new List<HRMSOverTimeModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HRMSOverTimeModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveGeneralRequest(HR_GeneralRequestModel model, HttpPostedFileBase EmpSignature)
        {
            try
            {
                //if (EmpSignature != null)
                //{
                //    model.EmpSignature = "/Images/EmployeeSignature/" + Guid.NewGuid() + Path.GetExtension(EmpSignature.FileName);
                //    EmpSignature.SaveAs(Path.Combine(Server.MapPath(model.EmpSignature)));
                //}

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
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


        public ActionResult GeneralRequestList(string Key)
        {
            List<HR_GeneralRequestModel> GeneralRequestList = new List<HR_GeneralRequestModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("37", Key);
                foreach (var i in GroupList)
                {
                    GeneralRequestList.Add(new HR_GeneralRequestModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNumber = i.VoucherNumber,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        EmpId = i.EmpId,
                        SalaryCertificate = i.SalaryCertificate,
                        SalaryTransferLetter = i.SalaryTransferLetter,
                        NOC = i.NOC,
                        ExperienceCertificate = i.ExperienceCertificate,
                        BankEstablishment = i.BankEstablishment,
                        AcctNoIBANNo = i.AcctNoIBANNo,
                        OpneNewBankAcct = i.OpneNewBankAcct,
                        TransferLoanToOtherBank = i.TransferLoanToOtherBank,
                        PersonalLoan = i.PersonalLoan,
                        NOCToEmbassy = i.NOCToEmbassy,
                        ConfirmationLettrToBank = i.ConfirmationLettrToBank,
                        LoanTopUp = i.LoanTopUp,
                        Others = i.Others,
                        CashAdvance = i.CashAdvance,
                        InitialNewEmp = i.InitialNewEmp,
                        Against = i.Against,
                        BehalfAgainst = i.BehalfAgainst,
                        Reason = i.Reason,
                        MonthlyDeduction = i.MonthlyDeduction,
                        SalarySlips3Months = i.SalarySlips3Months,
                        SalarySlips6Months = i.SalarySlips6Months,
                        TrafficFineDeductionAmt = i.TrafficFineDeductionAmt,
                        SalaryCard = i.SalaryCard,
                        EmpSignature = i.EmpSignature,
                        MobileNumber = i.MobileNumber,
                    });
                }
            }
            else
            {
                var GroupList = DL.GetGeneralRequestList();
                foreach (var i in GroupList)
                {
                    GeneralRequestList.Add(new HR_GeneralRequestModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNumber = i.VoucherNumber,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        EmpId = i.EmpId,
                        SalaryCertificate = i.SalaryCertificate,
                        SalaryTransferLetter = i.SalaryTransferLetter,
                        NOC = i.NOC,
                        ExperienceCertificate = i.ExperienceCertificate,
                        BankEstablishment = i.BankEstablishment,
                        AcctNoIBANNo = i.AcctNoIBANNo,
                        OpneNewBankAcct = i.OpneNewBankAcct,
                        TransferLoanToOtherBank = i.TransferLoanToOtherBank,
                        PersonalLoan = i.PersonalLoan,
                        NOCToEmbassy = i.NOCToEmbassy,
                        ConfirmationLettrToBank = i.ConfirmationLettrToBank,
                        LoanTopUp = i.LoanTopUp,
                        Others = i.Others,
                        CashAdvance = i.CashAdvance,
                        InitialNewEmp = i.InitialNewEmp,
                        Against = i.Against,
                        BehalfAgainst = i.BehalfAgainst,
                        Reason = i.Reason,
                        MonthlyDeduction = i.MonthlyDeduction,
                        SalarySlips3Months = i.SalarySlips3Months,
                        SalarySlips6Months = i.SalarySlips6Months,
                        TrafficFineDeductionAmt = i.TrafficFineDeductionAmt,
                        SalaryCard = i.SalaryCard,
                        EmpSignature = i.EmpSignature,
                        MobileNumber = i.MobileNumber,
                    });
                }
            }
            return View(GeneralRequestList);
        }

        [HttpPost]
        public ActionResult DeleteGeneralRequest(HR_GeneralRequestModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteGeneralRequest(model);
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




        public ActionResult ViewGeneralRequestDetails(string Id)
        {

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "39";
                var lst = DL.GetGeneralRequestDetaildById(model).FirstOrDefault();
                if (lst != null)
                {
                    model.Result = "yes";
                    model.VoucherNumber = lst.VoucherNumber;
                    model.EmployeeName = lst.EmployeeName;
                    model.Date = lst.Date;
                    model.Designation = lst.Designation;
                    model.BranchName = lst.BranchName;
                    model.DepartmentName = lst.DepartmentName;
                    model.EmpId = lst.EmpId;
                    model.SalaryCertificate = lst.SalaryCertificate;
                    model.SalaryTransferLetter = lst.SalaryTransferLetter;
                    model.NOC = lst.NOC;
                    model.ExperienceCertificate = lst.ExperienceCertificate;
                    model.BankEstablishment = lst.BankEstablishment;
                    model.AcctNoIBANNo = lst.AcctNoIBANNo;
                    model.OpneNewBankAcct = lst.OpneNewBankAcct;
                    model.TransferLoanToOtherBank = lst.TransferLoanToOtherBank;
                    model.PersonalLoan = lst.PersonalLoan;
                    model.NOCToEmbassy = lst.NOCToEmbassy;
                    model.ConfirmationLettrToBank = lst.ConfirmationLettrToBank;
                    model.LoanTopUp = lst.LoanTopUp;
                    model.Others = lst.Others;
                    model.CashAdvance = lst.CashAdvance;
                    model.InitialNewEmp = lst.InitialNewEmp;
                    model.Against = lst.Against;
                    model.BehalfAgainst = lst.BehalfAgainst;
                    model.Reason = lst.Reason;
                    model.MonthlyDeduction = lst.MonthlyDeduction;
                    model.SalarySlips3Months = lst.SalarySlips3Months;
                    model.SalarySlips6Months = lst.SalarySlips6Months;
                    model.TrafficFineDeductionAmt = lst.TrafficFineDeductionAmt;
                    model.SalaryCard = lst.SalaryCard;
                    model.MobileNumber = lst.MobileNumber;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



    }
}