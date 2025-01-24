using MassAutoGarage.Data.HR_RenualAndNonRenwal;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HR_RenualAndNonRenwal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HR_MainPowerRequisition;
using MassAutoGarage.Data.HR_MainPowerRequisition;
using MassAutoGarage.Models;
using MassAutoGarage.Models.HR_WorkHandOverReport;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.TeamFoundation.Work.WebApi;
using NPOI.SS.Formula.Functions;

namespace MassAutoGarage.Controllers
{
    public class HR_MainPowerRequisitionController : Controller
    {
        // GET: HR_MainPowerRequisition
        HR_MainPowerRequisitionModel model = new HR_MainPowerRequisitionModel();
        HR_MainPowerRequisitionDL DL = new HR_MainPowerRequisitionDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult MainPowerRequisition(HR_MainPowerRequisitionModel model, string Id)
        {
            ViewBag.ddlDesignation = DL.ddlDesignation();
            ViewBag.ddlDepartment = DL.ddlDepartment();
            ViewBag.ButtonText = "Save";
          
            if (Id != null)
            {
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "38";
                var lst = DL.GetMainPowerDetailsByIdForEdit(model).FirstOrDefault();
                model.VoucherNo = lst.VoucherNo;
                model.hdfVoucherNo = lst.VoucherNo;
                model.DepartmentId = lst.DepartmentId;
                model.RequestedDate = lst.RequestedDate;
                model.RequiredDate = lst.RequiredDate;
                model.DesignationId = lst.DesignationId;
                model.FullTime = lst.FullTime;
                model.ProjectHire = lst.ProjectHire;
                model.Temporary = lst.Temporary;
                model.JobDescription = lst.JobDescription;
                model.AdditionNew = lst.AdditionNew;
                model.Budgeted = lst.Budgeted;
                model.Replacement = lst.Replacement;
                model.AgeRange = lst.AgeRange;
                model.SalaryRange = lst.SalaryRange;
                model.StatusID = lst.StatusID;
                model.GenderID = lst.GenderID;
                model.PreferredQualification = lst.PreferredQualification;
                model.PreferredExperience = lst.PreferredExperience;
        
                model.Idincrept = objcls.Decrypt(Id);
                model.QueryType = "37";
                var lstdet = DL.GetMainPowerDetailsByIdForEdit(model).ToList();
                ViewBag.MainPowerDetails = lstdet.ToList();
                ViewBag.ButtonText = "Update";
            }
            return View(model);
        }


        public ActionResult GetMaxVoucher()
        {
            List<HR_MainPowerRequisitionModel> GetMaxVoucher = new List<HR_MainPowerRequisitionModel>();

            var GroupList = DL.GetMaxVoucher();
            foreach (var i in GroupList)
            {
                GetMaxVoucher.Add(new HR_MainPowerRequisitionModel
                {
                    MaxID = i.MaxID
                });
            }
            return Json(GetMaxVoucher, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveMainPowerRequisition(List<HR_MainPowerRequisitionModel> PatientArr)
        {
            HR_MainPowerRequisitionModel model = new HR_MainPowerRequisitionModel();
            try
            {
                if (PatientArr[0].Idincrept != null && PatientArr[0].Idincrept != "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
                    model.VoucherNo = PatientArr[0].VoucherNo;
                    model.DepartmentId = PatientArr[0].DepartmentId;
                    model.RequestedDate = PatientArr[0].RequestedDate;
                    model.RequiredDate = PatientArr[0].RequiredDate;
                    model.RequestedDate = string.IsNullOrEmpty(model.RequestedDate) ? null : Common.ConvertToSystemDate(model.RequestedDate, "dd/MM/yyyy");
                    model.RequiredDate = string.IsNullOrEmpty(model.RequiredDate) ? null : Common.ConvertToSystemDate(model.RequiredDate, "dd/MM/yyyy");
                    model.DesignationId = PatientArr[0].DesignationId;
                    model.FullTime = PatientArr[0].FullTime;
                    model.ProjectHire = PatientArr[0].ProjectHire;
                    model.Temporary = PatientArr[0].Temporary;
                    model.JobDescription = PatientArr[0].JobDescription;
                    model.AdditionNew = PatientArr[0].AdditionNew;
                    model.Budgeted = PatientArr[0].Budgeted;
                    model.Replacement = PatientArr[0].Replacement;
                    model.AgeRange = PatientArr[0].AgeRange;
                    model.SalaryRange = PatientArr[0].SalaryRange;
                    model.StatusID = PatientArr[0].StatusID;
                    model.GenderID = PatientArr[0].GenderID;
                    model.Idincrept = PatientArr[0].Idincrept;
                    model = DL.AddUpdate(model);
                    var MainPowerId = model.ManPowerID;
                    foreach (var Attch in PatientArr)
                    {
                        model.CreatedBy = Session["userId"].ToString();
                        model.QueryType = "22";
                        model.ManPowerID = MainPowerId;
                        model.Qualification = Attch.Qualification;
                        model.PassingYear = Attch.PassingYear;
                        model.Board = Attch.Board;
                        model.Percentage = Attch.Percentage;
                        model = DL.AddUpdateBulkEducationalRequirement(model);
                    }
                    //foreach (var Attch in PatientArr)
                    //{
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "23";
                    model.ManPowerID = MainPowerId;
                    model.PreferredQualification = PatientArr[0].PreferredQualification;
                    model.PreferredExperience = PatientArr[0].PreferredExperience;
                    model = DL.AddUpdateBulkPreferredQualification(model);
                    //}

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
                model.DepartmentId = PatientArr[0].DepartmentId;
                model.RequestedDate = PatientArr[0].RequestedDate;
                model.RequiredDate = PatientArr[0].RequiredDate;
                model.RequestedDate = string.IsNullOrEmpty(model.RequestedDate) ? null : Common.ConvertToSystemDate(model.RequestedDate, "dd/MM/yyyy");
                model.RequiredDate = string.IsNullOrEmpty(model.RequiredDate) ? null : Common.ConvertToSystemDate(model.RequiredDate, "dd/MM/yyyy");
                model.DesignationId = PatientArr[0].DesignationId;
                model.FullTime = PatientArr[0].FullTime;
                model.ProjectHire = PatientArr[0].ProjectHire;
                model.Temporary = PatientArr[0].Temporary;
                model.JobDescription = PatientArr[0].JobDescription;
                model.AdditionNew = PatientArr[0].AdditionNew;
                model.Budgeted = PatientArr[0].Budgeted;
                model.Replacement = PatientArr[0].Replacement;
                model.AgeRange = PatientArr[0].AgeRange;
                model.SalaryRange = PatientArr[0].SalaryRange;
                model.StatusID = PatientArr[0].StatusID;
                model.GenderID = PatientArr[0].GenderID;
                model = DL.AddUpdate(model);
                var ManPowerID = model.ManPowerID;

                foreach (var Attch in PatientArr)
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "12";
                    model.ManPowerID = ManPowerID;
                    model.Qualification = Attch.Qualification;
                    model.PassingYear = Attch.PassingYear;
                    model.Board = Attch.Board;
                    model.Percentage = Attch.Percentage;
                    model = DL.AddUpdateBulkEducationalRequirement(model);
                }
                //foreach (var Attch in PatientArr)
                //{
                model.CreatedBy = Session["userId"].ToString();
                model.QueryType = "13";
                model.ManPowerID = ManPowerID;
                model.PreferredQualification = PatientArr[0].PreferredQualification;
                model.PreferredExperience = PatientArr[0].PreferredExperience;
                model = DL.AddUpdateBulkPreferredQualification(model);
                //}
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

        public ActionResult MainPowerRequisitionList(string Key, string Id)
        {
            List<HR_MainPowerRequisitionModel> MainPowerList = new List<HR_MainPowerRequisitionModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("35", Key);
                foreach (var i in GroupList)
                {
                    MainPowerList.Add(new HR_MainPowerRequisitionModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        DepartmentName = i.DepartmentName,
                        RequestedDate = i.RequestedDate,
                        RequiredDate = i.RequiredDate,
                        Designation = i.Designation,
                        FullTime = i.FullTime,
                        ProjectHire = i.ProjectHire,
                        Temporary = i.Temporary,
                        JobDescription = i.JobDescription,
                        AdditionNew = i.AdditionNew,
                        Budgeted = i.Budgeted,
                        Replacement = i.Replacement,
                        AgeRange = i.AgeRange,
                        SalaryRange = i.SalaryRange,
                        StatusID = i.StatusID,
                        GenderID = i.GenderID
                    });
                }
            }
            else
            {
                var GroupList = DL.GetMainPowerList();
                foreach (var i in GroupList)
                {
                    MainPowerList.Add(new HR_MainPowerRequisitionModel
                    {
                        Idincrept = objcls.Encrypt(i.Id),
                        VoucherNo = i.VoucherNo,
                        DepartmentName = i.DepartmentName,
                        RequestedDate = i.RequestedDate,
                        RequiredDate = i.RequiredDate,
                        Designation = i.Designation,
                        FullTime = i.FullTime,
                        ProjectHire = i.ProjectHire,
                        Temporary = i.Temporary,
                        JobDescription = i.JobDescription,
                        AdditionNew = i.AdditionNew,
                        Budgeted = i.Budgeted,
                        Replacement = i.Replacement,
                        AgeRange = i.AgeRange,
                        SalaryRange = i.SalaryRange,
                        StatusID = i.StatusID,
                        GenderID = i.GenderID
                    });
                }
            }
            return View(MainPowerList);
        }


        public ActionResult ViewMainPowerDetails(string Id)
        {

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var lst = DL.GetMainPowerDetailsById("36", Id).FirstOrDefault();
                if (lst != null)
                {
                    model.Result = "yes";
                    model.VoucherNo = lst.VoucherNo;
                    model.DepartmentName = lst.DepartmentName;
                    model.RequestedDate = lst.RequestedDate;
                    model.RequiredDate = lst.RequiredDate;
                    model.Designation = lst.Designation;
                    model.FullTime = lst.FullTime;


                    //if (lst.FullTime == true)
                    //{
                    //    model.FullTime = true;
                    //}
                    //else
                    //{
                    //    model.FullTime = false;
                    //}

                    model.ProjectHire = lst.ProjectHire;
                    model.Temporary = lst.Temporary;
                    model.JobDescription = lst.JobDescription;
                    model.AdditionNew = lst.AdditionNew;
                    model.Budgeted = lst.Budgeted;
                    model.Replacement = lst.Replacement;
                    model.AgeRange = lst.AgeRange;
                    model.SalaryRange = lst.SalaryRange;
                    model.StatusID = lst.StatusID;
                    model.GenderID = lst.GenderID;
                    model.PreferredQualification = lst.PreferredQualification;
                    model.PreferredExperience = lst.PreferredExperience;
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewMainPowerEducationalRequirement(string Id)
        {
            List<HR_MainPowerRequisitionModel> PreferredQualificationList = new List<HR_MainPowerRequisitionModel>();

            if (Id != null)
            {
                Id = objcls.Decrypt(Id);
                var GroupList1 = DL.GetMainPowerDetailsById("37", Id);
                foreach (var i in GroupList1)
                {
                    PreferredQualificationList.Add(new HR_MainPowerRequisitionModel
                    {
                        Qualification = i.Qualification,
                        PassingYear = i.PassingYear,
                        Board = i.Board,
                        Percentage = i.Percentage
                    });
                }
            }
            return Json(PreferredQualificationList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteMainPowerRequisition(HR_MainPowerRequisitionModel model, string Id)
        {
            try
            {
                model.ManPowerID = objcls.Decrypt(Id);
                model.QueryType = "41";
                model = DL.DeleteMainPowerRequisition(model);
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