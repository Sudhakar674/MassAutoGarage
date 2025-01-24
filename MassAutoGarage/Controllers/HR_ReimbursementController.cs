using MassAutoGarage.Data.HRMS_SalesTarget;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_SalesTarget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_Reimbursement;
using MassAutoGarage.Data.HR_Reimbursement;
using MassAutoGarage.Models.HRMS_OverTime;
using DocumentFormat.OpenXml.VariantTypes;
using MassAutoGarage.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using MassAutoGarage.Models.HRMS_Employee;

namespace MassAutoGarage.Controllers
{
    public class HR_ReimbursementController : Controller
    {
        // GET: HR_Reimbursement
        HR_ReimbursementModel model = new HR_ReimbursementModel();
        HR_ReimbursementDL DL = new HR_ReimbursementDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Reimbursement(HR_ReimbursementModel model, string Id)
        {
            ViewBag.ddlBranch = DL.ddlBranch();
            ViewBag.ButtonText = "Save";
            if (Id != null)
            {
                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "35";
                var lst = DL.GetReimbursementById(model).FirstOrDefault();
                model.VoucherNo = lst.VoucherNo;
                model.hdfVoucherNo = lst.VoucherNo;
                model.Name = lst.Name;
                model.FromDate = lst.FromDate;
                model.ToDate = lst.ToDate;
                model.BranchId = lst.BranchId;

                model.Idencrept = objcls.Decrypt(Id);
                model.QueryType = "36";
                var lstdet = DL.GetReimbursementById(model).ToList();
                ViewBag.ReibDetails = lstdet.ToList();
                ViewBag.ButtonText = "Update";
            }
            return View(model);

        }


        public ActionResult GetMaxVoucher()
        {
            List<HR_ReimbursementModel> GetMaxVoucher = new List<HR_ReimbursementModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_ReimbursementModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveReimbursement(List<HR_ReimbursementModel> PatientArr)
        {
            HR_ReimbursementModel model = new HR_ReimbursementModel();

            try
            {
                if (PatientArr[0].Idencrept != null && PatientArr[0].Idencrept != "")
                {

                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
                    model.VoucherNo = PatientArr[0].VoucherNo;
                    model.Name = PatientArr[0].Name;
                    model.FromDate = PatientArr[0].FromDate;
                    model.ToDate = PatientArr[0].ToDate;
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                    model.BranchId = PatientArr[0].BranchId;
                    model.Idencrept = PatientArr[0].Idencrept;
                    var Idencreptmain = model.Idencrept;
                    model = DL.AddUpdate(model);

                    model.Id = Idencreptmain;
                    model.QueryType = "42";
                    model = DL.DeleteReimbursement(model);

                    var ReimbursementId = model.ReimbursementId;
                    foreach (var Attch in PatientArr)
                    {
                        model.CreatedBy = Session["userId"].ToString();
                        model.QueryType = "22";
                        model.Idencrept = Idencreptmain;
                        model.ReimbursementId = ReimbursementId;
                        model.DateOfBill = Attch.DateOfBill;
                        model.DateOfBill = string.IsNullOrEmpty(model.DateOfBill) ? null : Common.ConvertToSystemDate(model.DateOfBill, "dd/MM/yyyy");
                        model.Description = Attch.Description;
                        model.Amount = Attch.Amount;
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
                    model.Name = PatientArr[0].Name;
                    model.FromDate = PatientArr[0].FromDate;
                    model.ToDate = PatientArr[0].ToDate;
                    model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                    model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                    model.BranchId = PatientArr[0].BranchId;
                    model.Idencrept = PatientArr[0].Idencrept;

                    model = DL.AddUpdate(model);
                    var ReimbursementId = model.ReimbursementId;
                    foreach (var Attch in PatientArr)
                    {
                        model.CreatedBy = Session["userId"].ToString();
                        model.QueryType = "12";
                        model.ReimbursementId = ReimbursementId;
                        model.DateOfBill = Attch.DateOfBill;
                        model.DateOfBill = string.IsNullOrEmpty(model.DateOfBill) ? null : Common.ConvertToSystemDate(model.DateOfBill, "dd/MM/yyyy");
                        model.Description = Attch.Description;
                        model.Amount = Attch.Amount;
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


        public ActionResult ReimbursementList(string Key, string Id)
        {
            List<HR_ReimbursementModel> ReimbursementList = new List<HR_ReimbursementModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("34", Key);
                foreach (var i in GroupList)
                {
                    ReimbursementList.Add(new HR_ReimbursementModel
                    {
                        Idencrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        Name = i.Name,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        BranchName = i.BranchName,
                        DateOfBill = i.DateOfBill,
                        Description = i.Description,
                        Amount = i.Amount
                    });
                }
            }
            else
            {
                var GroupList = DL.GetReimbursementList();
                foreach (var i in GroupList)
                {
                    ReimbursementList.Add(new HR_ReimbursementModel
                    {
                        Idencrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        Name = i.Name,
                        FromDate = i.FromDate,
                        ToDate = i.ToDate,
                        BranchName = i.BranchName,
                        DateOfBill = i.DateOfBill,
                        Description = i.Description,
                        Amount = i.Amount
                    });
                }
            }
            return View(ReimbursementList);
        }



        [HttpPost]
        public ActionResult DeleteReimbursement(HR_ReimbursementModel model, string Id)
        {
            try
            {
                model.Id = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteReimbursement(model);
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


        public ActionResult ViewReimbursementDetails(string Id)
        {        

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var lst = DL.GetReimbursementDetailsById("30", Id).FirstOrDefault();
                if (lst != null)
                {
                    model.Result = "yes";
                    model.VoucherNo = lst.VoucherNo;
                    model.Name = lst.Name;
                    model.FromDate = lst.FromDate;
                    model.ToDate = lst.ToDate;
                    model.BranchName = lst.BranchName;            
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewReimbursementDetailsList(string Id)
        {
            List<HR_ReimbursementModel> ReimbursementDetails = new List<HR_ReimbursementModel>();

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var GroupList1 = DL.GetReimbursementDetailsById("301", Id);
                foreach (var i in GroupList1)
                {
                    ReimbursementDetails.Add(new HR_ReimbursementModel
                    {
                        ReimbursementId = i.ReimbursementId,
                        DateOfBill = i.DateOfBill,
                        Description = i.Description,
                        Amount = i.Amount
                    });
                }
            }
            return Json(ReimbursementDetails, JsonRequestBehavior.AllowGet);
        }




    }
}