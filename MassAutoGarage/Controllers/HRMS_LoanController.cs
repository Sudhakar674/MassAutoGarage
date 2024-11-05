using MassAutoGarage.Data.HRMS_Bonus;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_Bonus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.HRMS_Loan;
using MassAutoGarage.Models.HRMS_Loan;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HRMS_LoanController : Controller
    {
        // GET: HRMS_Loan
        HRMSLoanModel model = new HRMSLoanModel();
        HRMSLoanDL DL = new HRMSLoanDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSLoanModel> LoanList = new List<HRMSLoanModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("35", Key);
                foreach (var i in GroupList)
                {
                    LoanList.Add(new HRMSLoanModel
                    {
                        Idencrept = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        LoanDate = i.LoanDate,
                        LoanAmount = i.LoanAmount,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        DeductionPerMonth = i.DeductionPerMonth,
                        TotalAmount = i.TotalAmount,
                        Remarks = i.Remarks
                    });
                }
            }
            else
            {
                var GroupList = DL.GetLoanList();
                foreach (var i in GroupList)
                {
                LoanList.Add(new HRMSLoanModel
                {
                    Idencrept = objcls.Encrypt(i.ID),
                    BranchName = i.BranchName,
                    EmployeeName = i.EmployeeName,
                    LoanDate = i.LoanDate,
                    LoanAmount = i.LoanAmount,
                    FromDate = i.FromDate,
                    ToDate = i.ToDate,
                    DeductionPerMonth = i.DeductionPerMonth,
                    TotalAmount = i.TotalAmount,
                    Remarks = i.Remarks
                });
                }
            }
            return View(LoanList);
        }
        public ActionResult Loan(HRMSLoanModel model,string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.EmployeeList = DL.DropDownEmployeeList();

            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "34";
                var lst = DL.GetLoanDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.EmployeeId = lst.EmployeeId;
                    model.LoanDate = lst.LoanDate;
                    model.LoanAmount = lst.LoanAmount;
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
                    model.DeductionPerMonth = lst.DeductionPerMonth;
                    model.TotalAmount = lst.TotalAmount;
                    model.Remarks = lst.Remarks;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveLoan(HRMSLoanModel model)
        {
            try
            {
                if (model.ID == null || model.ID == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.LoanDate = string.IsNullOrEmpty(model.LoanDate) ? null : Common.ConvertToSystemDate(model.LoanDate, "dd/MM/yyyy");
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
                    model.Idencrept = objcls.Decrypt(model.ID);
                    model.QueryType = "21";
                    model.LoanDate = string.IsNullOrEmpty(model.LoanDate) ? null : Common.ConvertToSystemDate(model.LoanDate, "dd/MM/yyyy");
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


        public ActionResult DeleteLoan(HRMSLoanModel model, string Id)
        {
            try
            {

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteLoanDetails(model);
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