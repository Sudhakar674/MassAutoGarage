using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_NewStaffJoining;
using MassAutoGarage.Data.HR_NewStaffJoining;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace MassAutoGarage.Controllers
{
    public class HR_NewStaffJoiningController : Controller
    {
        // GET: HR_NewStaffJoining
        HR_NewStaffJoiningModel model = new HR_NewStaffJoiningModel();
        HR_NewStaffJoiningDL DL = new HR_NewStaffJoiningDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult NewStaffJoining(HR_NewStaffJoiningModel model, string Id)
        {
            ViewBag.ddlDesignation = DL.ddlDesignation();    
            ViewBag.ddlDepartment = DL.ddlDepartment();

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "36";
                var lst = DL.GetNewStaffJoiningDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.VoucherNumber = lst.VoucherNumber;
                    model.hdfVoucherNumber = lst.VoucherNumber;
                    model.EmployeeName = lst.EmployeeName;
                    model.Date = lst.Date;
                    model.DepartmentId = lst.DepartmentId;
                    model.DesignationId = lst.DesignationId;
                    model.EmpNo = lst.EmpNo;
                    model.JoiningDate = lst.JoiningDate;
                    model.JoiningTime = lst.JoiningTime;
                    model.FilledByEmployee = lst.FilledByEmployee;
                }
            }
            return View(model);
        }


        public ActionResult GetMaxVoucher()
        {
            List<HR_NewStaffJoiningModel> GetMaxVoucher = new List<HR_NewStaffJoiningModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_NewStaffJoiningModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveNewStaffJoining(HR_NewStaffJoiningModel model)
        {
            try
            {
                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.Date = string.IsNullOrEmpty(model.Date) ? null : Common.ConvertToSystemDate(model.Date, "dd/MM/yyyy");
                    model.JoiningDate = string.IsNullOrEmpty(model.JoiningDate) ? null : Common.ConvertToSystemDate(model.JoiningDate, "dd/MM/yyyy");
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
                    model.JoiningDate = string.IsNullOrEmpty(model.JoiningDate) ? null : Common.ConvertToSystemDate(model.JoiningDate, "dd/MM/yyyy");
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


        public ActionResult NewStaffJoiningList(string Key)
        {
            List<HR_NewStaffJoiningModel> NewStopJoiningList = new List<HR_NewStaffJoiningModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("35", Key);
                foreach (var i in GroupList)
                {
                    NewStopJoiningList.Add(new HR_NewStaffJoiningModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNumber = i.VoucherNumber,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        DepartmentName = i.DepartmentName,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        JoiningDate = i.JoiningDate,
                        JoiningTime = i.JoiningTime,
                        FilledByEmployee = i.FilledByEmployee
                    });
                }
            }
            else
            {
                var GroupList = DL.GetNewStopJoiningList();
                foreach (var i in GroupList)
                {
                    NewStopJoiningList.Add(new HR_NewStaffJoiningModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNumber = i.VoucherNumber,
                        EmployeeName = i.EmployeeName,
                        Date = i.Date,
                        DepartmentName = i.DepartmentName,
                        Designation = i.Designation,
                        EmpNo = i.EmpNo,
                        JoiningDate = i.JoiningDate,
                        JoiningTime = i.JoiningTime,
                        FilledByEmployee = i.FilledByEmployee
                    });
                }
            }
            return View(NewStopJoiningList);
        }



        [HttpPost]
        public ActionResult DeleteNewStaffJoining(HR_NewStaffJoiningModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteNewStaffJoining(model);
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