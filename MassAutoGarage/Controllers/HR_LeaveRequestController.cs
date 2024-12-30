using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_LeaveRequest;
using MassAutoGarage.Data.HR_LeaveRequest;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;
using System.IO;

namespace MassAutoGarage.Controllers
{
    public class HR_LeaveRequestController : Controller
    {
        // GET: HR_LeaveRequest
        HR_LeaveRequestModel model = new HR_LeaveRequestModel();
        HR_LeaveRequestDL DL = new HR_LeaveRequestDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult LeaveRequest(HR_LeaveRequestModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlCompany = DL.ddlCompany();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ddlBranch = DL.ddlBranch();

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "39";
                var lst = DL.GetLeaveRequestDetaildById(model).FirstOrDefault();

                if (lst.MarriageLeave == true)
                {
                    model.MarriageLeave = true;
                }
                else
                {
                    model.MarriageLeave = false;
                }

                if (lst.AnnualLeave == true)
                {
                    model.AnnualLeave = true;
                }
                else
                {
                    model.AnnualLeave = false;
                }

                if (lst.AuthorizedUnpaidLeave == true)
                {
                    model.AuthorizedUnpaidLeave = true;
                }
                else
                {
                    model.AuthorizedUnpaidLeave = false;
                }

                if (lst.EmergencyLeave == true)
                {
                    model.EmergencyLeave = true;
                }
                else
                {
                    model.EmergencyLeave = false;
                }

                if (lst.SickLeave == true)
                {
                    model.SickLeave = true;
                }
                else
                {
                    model.SickLeave = false;
                }

                if (lst.MaternityLeave == true)
                {
                    model.MaternityLeave = true;
                }
                else
                {
                    model.MaternityLeave = false;
                }

                if (lst.Others == true)
                {
                    model.Others = true;
                }
                else
                {
                    model.Others = false;
                }

                if (lst.LocalLeave == true)
                {
                    model.LocalLeave = true;
                }
                else
                {
                    model.LocalLeave = false;
                }

                if (lst.MedicalCertificate == 1 && lst.MedicalCertificateFile != null)
                {
                    model.MedicalCertificate = 1;
                }
                else
                {
                    model.MedicalCertificate = 0;
                }

                //if (lst.MedicalCertificate == 1 && lst.MedicalCertificateFile == null)
                //{
                //    model.MedicalCertificate = 1;
                //}



                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.CompanyID = lst.CompanyID;
                    model.DepartmentId = lst.DepartmentId;
                    model.BranchId = lst.BranchId;
                    model.DateOfJoining = lst.DateOfJoining;
                    model.PleaseSpecifyOtherLeave = lst.PleaseSpecifyOtherLeave;
                    model.LeaveFromDate = lst.LeaveFromDate;
                    model.LeaveToDate = lst.LeaveToDate;
                    model.AirportName = lst.AirportName;
                    model.FromAirportName = lst.FromAirportName;
                    model.ToAirportName = lst.ToAirportName;
                    model.ReasonforSickLeave = lst.ReasonforSickLeave;
                    model.MedicalCertificateFile = lst.MedicalCertificateFile;
                    model.HDF_MedicalCertificateFile = lst.MedicalCertificateFile;



                    //model.MedicalCertificateFile = model.MedicalCertificateFile == "undefined" ? null : model.MedicalCertificateFile;
                    model.Email = lst.Email;
                    model.MobileNo = lst.MobileNo;
                }
            }
            return View(model);
        }


        public ActionResult GetMaxVoucher()
        {
            List<HR_LeaveRequestModel> GetMaxVoucher = new List<HR_LeaveRequestModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_LeaveRequestModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveLeaveRequest(HR_LeaveRequestModel model, HttpPostedFileBase MedicalCertificateFile)
        {
            try
            {
                if (MedicalCertificateFile != null)
                {
                    model.MedicalCertificateFile = "/Images/MedicalCertificateFile/" + Guid.NewGuid() + Path.GetExtension(MedicalCertificateFile.FileName);
                    MedicalCertificateFile.SaveAs(Path.Combine(Server.MapPath(model.MedicalCertificateFile)));
                }

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";

                    model.MedicalCertificateFile = model.MedicalCertificateFile == "undefined" ? null : model.MedicalCertificateFile;

                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DateOfJoining = string.IsNullOrEmpty(model.DateOfJoining) ? null : Common.ConvertToSystemDate(model.DateOfJoining, "dd/MM/yyyy");
                    model.LeaveFromDate = string.IsNullOrEmpty(model.LeaveFromDate) ? null : Common.ConvertToSystemDate(model.LeaveFromDate, "dd/MM/yyyy");
                    model.LeaveToDate = string.IsNullOrEmpty(model.LeaveToDate) ? null : Common.ConvertToSystemDate(model.LeaveToDate, "dd/MM/yyyy");
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

                    if (model.MedicalCertificateFile== "undefined")
                    {
                        model.MedicalCertificateFile = model.HDF_MedicalCertificateFile;
                       
                    }
                    else
                    {
                        model.MedicalCertificateFile = model.MedicalCertificateFile == "undefined" ? null : model.MedicalCertificateFile;

                    }

                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.DateOfJoining = string.IsNullOrEmpty(model.DateOfJoining) ? null : Common.ConvertToSystemDate(model.DateOfJoining, "dd/MM/yyyy");
                    model.LeaveFromDate = string.IsNullOrEmpty(model.LeaveFromDate) ? null : Common.ConvertToSystemDate(model.LeaveFromDate, "dd/MM/yyyy");
                    model.LeaveToDate = string.IsNullOrEmpty(model.LeaveToDate) ? null : Common.ConvertToSystemDate(model.LeaveToDate, "dd/MM/yyyy");
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


        public ActionResult LeaveRequestList(string Key)
        {
            List<HR_LeaveRequestModel> LeaveRequestList = new List<HR_LeaveRequestModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("38", Key);
                foreach (var i in GroupList)
                {
                    LeaveRequestList.Add(new HR_LeaveRequestModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        CompanyName = i.CompanyName,
                        DepartmentName = i.DepartmentName,
                        BranchName = i.BranchName,
                        DateOfJoining = i.DateOfJoining,
                        MarriageLeave = i.MarriageLeave,
                        AnnualLeave = i.AnnualLeave,
                        AuthorizedUnpaidLeave = i.AuthorizedUnpaidLeave,
                        EmergencyLeave = i.EmergencyLeave,
                        SickLeave = i.SickLeave,
                        MaternityLeave = i.MaternityLeave,
                        Others = i.Others,
                        PleaseSpecifyOtherLeave = i.PleaseSpecifyOtherLeave,
                        LocalLeave = i.LocalLeave,
                        LeaveFromDate = i.LeaveFromDate,
                        LeaveToDate = i.LeaveToDate,
                        AirportName = i.AirportName,
                        FromAirportName = i.FromAirportName,
                        ToAirportName = i.ToAirportName,
                        ReasonforSickLeave = i.ReasonforSickLeave,
                        MedicalCertificate = i.MedicalCertificate,
                        MedicalCertificateFile = i.MedicalCertificateFile,
                        Email = i.Email,
                        MobileNo = i.MobileNo
                    });
                }
            }
            else
            {

                var GroupList = DL.GetLeaveRequestList();
                foreach (var i in GroupList)
                {
                    LeaveRequestList.Add(new HR_LeaveRequestModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        CompanyName = i.CompanyName,
                        DepartmentName = i.DepartmentName,
                        BranchName = i.BranchName,
                        DateOfJoining = i.DateOfJoining,
                        MarriageLeave = i.MarriageLeave,
                        AnnualLeave = i.AnnualLeave,
                        AuthorizedUnpaidLeave = i.AuthorizedUnpaidLeave,
                        EmergencyLeave = i.EmergencyLeave,
                        SickLeave = i.SickLeave,
                        MaternityLeave = i.MaternityLeave,
                        Others = i.Others,
                        PleaseSpecifyOtherLeave = i.PleaseSpecifyOtherLeave,
                        LocalLeave = i.LocalLeave,
                        LeaveFromDate = i.LeaveFromDate,
                        LeaveToDate = i.LeaveToDate,
                        AirportName = i.AirportName,
                        FromAirportName = i.FromAirportName,
                        ToAirportName = i.ToAirportName,
                        ReasonforSickLeave = i.ReasonforSickLeave,
                        MedicalCertificate = i.MedicalCertificate,
                        MedicalCertificateFile = i.MedicalCertificateFile,
                        Email = i.Email,
                        MobileNo = i.MobileNo
                    });
                }
            }
            return View(LeaveRequestList);
        }

        [HttpPost]
        public ActionResult DeleteLeaveRequest(HR_LeaveRequestModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteLeaveRequest(model);
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