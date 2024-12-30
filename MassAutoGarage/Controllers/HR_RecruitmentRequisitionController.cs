using MassAutoGarage.Data.HR_GeneralRequest;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_OverTime;
using MassAutoGarage.Models;
using MassAutoGarage.Models.HR_RecruitmentRequisition;
using MassAutoGarage.Data.HR_RecruitmentRequisition;
using Org.BouncyCastle.Utilities;

namespace MassAutoGarage.Controllers
{
    public class HR_RecruitmentRequisitionController : Controller
    {
        // GET: HR_RecruitmentRequisition
        HR_RecruitmentRequisitionModel model = new HR_RecruitmentRequisitionModel();
        HR_RecruitmentRequisitionDL DL = new HR_RecruitmentRequisitionDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult RecruitmentRequisition(HR_RecruitmentRequisitionModel model, string Id)
        {
            ViewBag.ButtonText = "Save";

            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "33";
                var lst = DL.GetGeneralRequestDetaildById(model).FirstOrDefault();

                if (lst.AdditionNew == true)
                {
                    model.AdditionNew = true;
                }
                else
                {
                    model.AdditionNew = false;
                }
             
                if (lst.Budgeted == true)
                {
                    model.Budgeted = true;
                }
                else
                {
                    model.Budgeted = false;
                }

                if (lst.Replacement == true)
                {
                    model.Replacement = true;
                }
                else
                {
                    model.Replacement = false;
                }

                if (lst != null)
                {
                    model.VoucherNo = lst.VoucherNo;
                    model.hdfVoucherNo = lst.VoucherNo;
                    model.FullName = lst.FullName;
                    model.Date = lst.Date;
                    model.ExpectedSalary = lst.ExpectedSalary;
                    model.SalaryOffered = lst.SalaryOffered;
                    ViewBag.ButtonText = "Update";
                }
            }
            return View(model);
        }

        public ActionResult GetMaxVoucher()
        {
            List<HR_RecruitmentRequisitionModel> GetMaxVoucher = new List<HR_RecruitmentRequisitionModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_RecruitmentRequisitionModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveRecruitmentRequisition(HR_RecruitmentRequisitionModel model)
        {
            try
            {
             
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


        public ActionResult RecruitmentRequisitionList(string Key)
        {
            List<HR_RecruitmentRequisitionModel> RecruitmentRequisitionList = new List<HR_RecruitmentRequisitionModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("32", Key);
                foreach (var i in GroupList)
                {
                    RecruitmentRequisitionList.Add(new HR_RecruitmentRequisitionModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        FullName = i.FullName,
                        Date = i.Date,
                        ExpectedSalary = i.ExpectedSalary,
                        SalaryOffered = i.SalaryOffered,
                        AdditionNew = i.AdditionNew,
                        Budgeted = i.Budgeted,
                        Replacement = i.Replacement
                     
                    });
                }
            }
            else
            {
                var GroupList = DL.GetRecruitmentRequisitionList();
                foreach (var i in GroupList)
                {
                    RecruitmentRequisitionList.Add(new HR_RecruitmentRequisitionModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        FullName = i.FullName,
                        Date = i.Date,
                        ExpectedSalary = i.ExpectedSalary,
                        SalaryOffered = i.SalaryOffered,
                        AdditionNew = i.AdditionNew,
                        Budgeted = i.Budgeted,
                        Replacement = i.Replacement

                    });
                }
            }
            return View(RecruitmentRequisitionList);
        }



        [HttpPost]
        public ActionResult DeleteRecruitmentRequisition(HR_RecruitmentRequisitionModel model, string Id)
        {
            try
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteRecruitmentRequisition(model);
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
