using MassAutoGarage.Data.HR_ResumingDuty;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_ResumingDuty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.HR_WorkHandOverReport;
using MassAutoGarage.Models.HR_WorkHandOverReport;
using MassAutoGarage.Models.HR_Reimbursement;
using MassAutoGarage.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;

namespace MassAutoGarage.Controllers
{
    public class HR_WorkHandOverReportController : Controller
    {
        // GET: HR_WorkHandOverReport
        HR_WorkHandOverReportModel model = new HR_WorkHandOverReportModel();
        HR_WorkHandOverReportDL DL = new HR_WorkHandOverReportDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult WorkHandOverReport(HR_WorkHandOverReportModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "40";
                var lst = DL.FindWorkHandOverReporByIdForEdit(model).FirstOrDefault();
                model.VoucherNo = lst.VoucherNo;
                model.hdfVoucherNo = lst.VoucherNo;
                model.EmployeeId = lst.EmployeeId;
                model.Date = lst.Date;
                model.DesignationId = lst.DesignationId;
                model.EmpNo = lst.EmpNo;
                model.BranchId = lst.BranchId;
                model.ReasonForWorkHandOver = lst.ReasonForWorkHandOver;
                model.TakenOverBy = lst.TakenOverBy;
            
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "36";
                var lstdet = DL.GetWorkHandOvermultiReportById(model).ToList();
                ViewBag.WorkHandOverDetails = lstdet.ToList();
                ViewBag.ButtonText = "Update";
            }
            return View(model);
        }



        public ActionResult GetMaxVoucher()
        {
            List<HR_WorkHandOverReportModel> GetMaxVoucher = new List<HR_WorkHandOverReportModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_WorkHandOverReportModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveWorkHandOverReport(List<HR_WorkHandOverReportModel> PatientArr)
        {
            HR_WorkHandOverReportModel model = new HR_WorkHandOverReportModel();
            try
            {
                if (PatientArr[0].Idincrept != null && PatientArr[0].Idincrept != "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
                    model.VoucherNo = PatientArr[0].VoucherNo;
                    model.EmployeeId = PatientArr[0].EmployeeId;
                    model.Date = PatientArr[0].Date;
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DesignationId = PatientArr[0].DesignationId;
                    model.EmpNo = PatientArr[0].EmpNo;
                    model.BranchId = PatientArr[0].BranchId;
                    model.ReasonForWorkHandOver = PatientArr[0].ReasonForWorkHandOver;
                    model.TakenOverBy = PatientArr[0].TakenOverBy;
                    model.Idincrept = PatientArr[0].Idincrept;
                    var Idincreptmain = model.Idincrept;

                    model = DL.AddUpdate(model);


                    model.Id = Idincreptmain;
                    model.QueryType = "42";
                    model = DL.DeleteWorkHandOverReport(model);

                    foreach (var Attch in PatientArr)
                    {
                        model.CreatedBy = Session["userId"].ToString();
                        model.QueryType = "22";
                        model.Idincrept = Idincreptmain;
                        model.Tasks = Attch.Tasks;
                        model.Status = Attch.Status;
                        model = DL.AddUpdateBulk(model);
                    }
                    if (model.Message == "1")
                    {
                        model.Result = "yes1";
                    }
                    else
                    {
                        model.Result = "";
                    }
                }
                else
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.VoucherNo = PatientArr[0].VoucherNo;
                    model.EmployeeId = PatientArr[0].EmployeeId;
                    model.Date = PatientArr[0].Date;
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DesignationId = PatientArr[0].DesignationId;
                    model.EmpNo = PatientArr[0].EmpNo;
                    model.BranchId = PatientArr[0].BranchId;
                    model.ReasonForWorkHandOver = PatientArr[0].ReasonForWorkHandOver;
                    model.TakenOverBy = PatientArr[0].TakenOverBy;
                 
                    model = DL.AddUpdate(model);
                    var WorkHandOverID = model.WorkHandOverID;
                    foreach (var Attch in PatientArr)
                    {
                        model.CreatedBy = Session["userId"].ToString();
                        model.QueryType = "12";
                        model.WorkHandOverID = WorkHandOverID;
                        model.Tasks = Attch.Tasks;
                        model.Status = Attch.Status;
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
            }
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult WorkHandOverReportList(string Key, string Id)
        {
            List<HR_WorkHandOverReportModel> WorkHandOverReportList = new List<HR_WorkHandOverReportModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("38", Key);
                foreach (var i in GroupList)
                {
                    WorkHandOverReportList.Add(new HR_WorkHandOverReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        BranchName = i.BranchName,
                        ReasonForWorkHandOver = i.ReasonForWorkHandOver,
                        TakenOverBy = i.TakenOverBy
                    });
                }
            }
            else
            {
                var GroupList = DL.GetWorkHandOverReportList();
                foreach (var i in GroupList)
                {
                    WorkHandOverReportList.Add(new HR_WorkHandOverReportModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        BranchName = i.BranchName,
                        ReasonForWorkHandOver = i.ReasonForWorkHandOver,
                        TakenOverBy = i.TakenOverBy
                    });
                }
            }
            return View(WorkHandOverReportList);
        }


        [HttpPost]
        public ActionResult DeleteWorkHandOverReport(HR_WorkHandOverReportModel model, string Id)
        {
            try
            {
                model.Id = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteWorkHandOverReport(model);
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


        public ActionResult ViewWorkHandOverReport(string Id)
        {

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var lst = DL.GetWorkHandOverReportById("39", Id).FirstOrDefault();
                if (lst != null)
                {
                    model.Result = "yes";
                    model.VoucherNo = lst.VoucherNo;
                    model.EmployeeName = lst.EmployeeName;
                    model.Date = lst.Date;
                    model.Designation = lst.Designation;
                    model.EmpNo = lst.EmpNo;
                    model.BranchName = lst.BranchName;
                    model.ReasonForWorkHandOver = lst.ReasonForWorkHandOver;
                    model.TakenOverBy = lst.TakenOverBy;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewWorkHandOverReportList(string Id)
        {
            List<HR_WorkHandOverReportModel> WorkHandOverReport = new List<HR_WorkHandOverReportModel>();

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var GroupList1 = DL.GetWorkHandOverReportById("36", Id);
                foreach (var i in GroupList1)
                {
                    WorkHandOverReport.Add(new HR_WorkHandOverReportModel
                    {
                        WorkHandOverID = i.WorkHandOverID,
                        Tasks = i.Tasks,
                        Status = i.Status
                    });
                }
            }
            return Json(WorkHandOverReport, JsonRequestBehavior.AllowGet);
        }








    }
}