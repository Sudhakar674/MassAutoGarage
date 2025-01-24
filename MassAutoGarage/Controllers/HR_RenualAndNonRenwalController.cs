using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Data.HR_RenualAndNonRenwal;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;

namespace MassAutoGarage.Controllers
{
    public class HR_RenualAndNonRenwalController : Controller
    {
        // GET: HR_RenualAndNonRenwal
        HR_RenualAndNonRenwalModel model = new HR_RenualAndNonRenwalModel();
        HR_RenualAndNonRenwalDL DL = new HR_RenualAndNonRenwalDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult RenualAndNonRenwal(HR_RenualAndNonRenwalModel model, string Id)
        {

            ViewBag.ddlEmployee = DL.ddlEmployee();
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "38";
                var lst = DL.GetRenualAndNonRenwalDetaildById(model).FirstOrDefault();

                if (lst.Renew == true)
                {
                    model.Renew = true;
                }
                else
                {
                    model.Renew = false;
                }
                if (lst.NotRenewing == true)
                {
                    model.NotRenewing = true;
                }
                else
                {
                    model.NotRenewing = false;
                }

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.EmployeeId = lst.EmployeeId;
                    model.DateOfJoined = lst.DateOfJoined;
                    model.DesignationId = lst.DesignationId;
                    model.BranchId = lst.BranchId;
                    model.DepartmentId = lst.DepartmentId;
                    ViewBag.ButtonText = "Update";
                }
            }
            return View(model);
        }
       


        public ActionResult GetMaxVoucher()
        {
            List<HR_RenualAndNonRenwalModel> GetMaxVoucher = new List<HR_RenualAndNonRenwalModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_RenualAndNonRenwalModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveRenualAndNonRenwal(HR_RenualAndNonRenwalModel model)
        {
            try
            {
              
                if (model.Idincrept == null || model.Idincrept == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
                    model.DateOfJoined = string.IsNullOrEmpty(model.DateOfJoined) ? null : Common.ConvertToSystemDate(model.DateOfJoined, "dd/MM/yyyy");
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
                    model.DateOfJoined = string.IsNullOrEmpty(model.DateOfJoined) ? null : Common.ConvertToSystemDate(model.DateOfJoined, "dd/MM/yyyy");
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


        public ActionResult RenualAndNonRenwalList(string Key)
        {
            List<HR_RenualAndNonRenwalModel> RenualAndNonRenwalList = new List<HR_RenualAndNonRenwalModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("37", Key);
                foreach (var i in GroupList)
                {
                    RenualAndNonRenwalList.Add(new HR_RenualAndNonRenwalModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        DateOfJoined = i.DateOfJoined,
                        Designation = i.Designation,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        Renew = i.Renew,
                        NotRenewing = i.NotRenewing,
                    });
                }
            }
            else
            {
                var GroupList = DL.GetRenualAndNonRenwalList();
                foreach (var i in GroupList)
                {
                    RenualAndNonRenwalList.Add(new HR_RenualAndNonRenwalModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        EmployeeName = i.EmployeeName,
                        DateOfJoined = i.DateOfJoined,
                        Designation = i.Designation,
                        BranchName = i.BranchName,
                        DepartmentName = i.DepartmentName,
                        Renew = i.Renew,
                        NotRenewing = i.NotRenewing,
                    });
                }
            }
            return View(RenualAndNonRenwalList);
        }

        [HttpPost]
        public ActionResult DeleteRenualAndNonRenwal(HR_RenualAndNonRenwalModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteRenualAndNonRenwal(model);
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