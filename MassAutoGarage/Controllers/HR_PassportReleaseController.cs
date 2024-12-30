using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_PassportRelease;
using MassAutoGarage.Data.HR_PassportRelease;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using DocumentFormat.OpenXml.Bibliography;

namespace MassAutoGarage.Controllers
{
    public class HR_PassportReleaseController : Controller
    {
        // GET: HR_PassportRelease
        HR_PassportReleaseModel model = new HR_PassportReleaseModel();
        HR_PassportReleaseDL DL = new HR_PassportReleaseDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult PassportRelease(HR_PassportReleaseModel model, string Id)
        {
            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ddlDepartment = DL.ddlDepartment();

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "38";
                var lst = DL.GetPassportReleaseDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.Date = lst.Date;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.BranchId = lst.BranchId;
                    model.DepartmentId = lst.DepartmentId;
                    model.ReasonForReleasePassReq = lst.ReasonForReleasePassReq;
                    model.ExpectedReturnDate = lst.ExpectedReturnDate;
                    model.EmployeeUndertaking = lst.EmployeeUndertaking;
                    model.SignDate = lst.SignDate;
                }
            }
            return View(model);

        }





        public ActionResult GetMaxVoucher()
        {
            List<HR_PassportReleaseModel> GetMaxVoucher = new List<HR_PassportReleaseModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_PassportReleaseModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SavePassportRelease(HR_PassportReleaseModel model)
        {
            try
            {

                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.ExpectedReturnDate = string.IsNullOrEmpty(model.ExpectedReturnDate) ? null : Common.ConvertToSystemDate(model.ExpectedReturnDate, "dd/MM/yyyy");
                    model.SignDate = string.IsNullOrEmpty(model.SignDate) ? null : Common.ConvertToSystemDate(model.SignDate, "dd/MM/yyyy");
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
                    model.ExpectedReturnDate = string.IsNullOrEmpty(model.ExpectedReturnDate) ? null : Common.ConvertToSystemDate(model.ExpectedReturnDate, "dd/MM/yyyy");
                    model.SignDate = string.IsNullOrEmpty(model.SignDate) ? null : Common.ConvertToSystemDate(model.SignDate, "dd/MM/yyyy");
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


        public ActionResult PassportReleaseList(string Key)
        {
            List<HR_PassportReleaseModel> PassportReleaseList = new List<HR_PassportReleaseModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("37", Key);
                foreach (var i in GroupList)
                {
                    PassportReleaseList.Add(new HR_PassportReleaseModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        ReasonForReleasePassReq = i.ReasonForReleasePassReq,
                        ExpectedReturnDate = i.ExpectedReturnDate,
                        EmployeeUndertaking = i.EmployeeUndertaking,
                        SignDate = i.SignDate,
                    });
                }
            }
            else
            {
                var GroupList = DL.GetPassportReleaseList();
                foreach (var i in GroupList)
                {
                    PassportReleaseList.Add(new HR_PassportReleaseModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        ReasonForReleasePassReq = i.ReasonForReleasePassReq,
                        ExpectedReturnDate = i.ExpectedReturnDate,
                        EmployeeUndertaking = i.EmployeeUndertaking,
                        SignDate = i.SignDate,
                    });
                }
            }
            return View(PassportReleaseList);
        }

        [HttpPost]
        public ActionResult DeletePassportRelease(HR_PassportReleaseModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeletePassportRelease(model);
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