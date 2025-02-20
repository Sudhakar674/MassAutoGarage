﻿using MassAutoGarage.Data;
using MassAutoGarage.Data.HRMS_EmployeeDocuments;
using MassAutoGarage.Data.HRMS_Holiday;
using MassAutoGarage.Models.ColorMaster;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeDocumentsController : Controller
    {
        // GET: HRMS_EmployeeDocuments
        HRMSEmployeeDocumentsModel model=new HRMSEmployeeDocumentsModel();
        HRMSEmployeeDocumentsDL DL = new HRMSEmployeeDocumentsDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
              List<HRMSEmployeeDocumentsModel> EmployeeDocumentsList = new List<HRMSEmployeeDocumentsModel>();

            if (Key != "" && Key != null)
            {            
                var GroupList = DL.SearchByKey("33",Key);
                foreach (var i in GroupList)
                {
                    EmployeeDocumentsList.Add(new HRMSEmployeeDocumentsModel
                    {
                        EmpDocId = objcls.Encrypt(i.EmpDocId),
                        FK_BranchId = i.FK_BranchId,
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        files = i.files,
                        EmirateFile = i.EmirateFile,
                        PassportFile = i.PassportFile,
                        VisaFile = i.VisaFile,
                        InsuranceFile = i.InsuranceFile,
                        EmpCardFile = i.EmpCardFile
                    });
                }
            }
            else
            {
                var GroupList = DL.GetEmployeeDocumentsList();
                foreach (var i in GroupList)
                {
                    EmployeeDocumentsList.Add(new HRMSEmployeeDocumentsModel
                    {
                        EmpDocId = objcls.Encrypt(i.EmpDocId),
                        FK_BranchId = i.FK_BranchId,
                        BranchName = i.BranchName,
                        EmployeeName = i.EmployeeName,
                        files = i.files,
                        EmirateFile = i.EmirateFile,
                        PassportFile = i.PassportFile,
                        VisaFile = i.VisaFile,
                        InsuranceFile = i.InsuranceFile,
                        EmpCardFile = i.EmpCardFile
                    });
                }
            }
            return View(EmployeeDocumentsList);
        }
        
        public ActionResult EmployeeDocuments(HRMSEmployeeDocumentsModel model , string Id)
        {
            ViewBag.BranchList = DL.DropdownList();

            if (Id != null)
            {
                model.EmpDocId = objcls.Decrypt(Id);
                model.QueryType = "42";
                var lst = DL.GetEmployeeDocumentsDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.EmpDocId = lst.EmpDocId;
                    model.FK_BranchId = lst.FK_BranchId;
                    model.EmployeeName = lst.EmployeeName;
                    model.files = lst.files;
                    model.EmirateFile = lst.EmirateFile;
                    model.PassportFile = lst.PassportFile;
                    model.VisaFile = lst.VisaFile;
                    model.InsuranceFile = lst.InsuranceFile;
                    model.EmpCardFile = lst.EmpCardFile;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveEmployeeDocuments(HRMSEmployeeDocumentsModel model,HttpPostedFileBase files, HttpPostedFileBase EmirateFile,
           HttpPostedFileBase PassportFile, HttpPostedFileBase VisaFile, HttpPostedFileBase InsuranceFile, HttpPostedFileBase EmpCardFile, string EmpDocId)
        {
            try
            {
                if (files != null)
                {
                    model.files = "/Images/PhotoFile/" + Guid.NewGuid() + Path.GetExtension(files.FileName);
                    files.SaveAs(Path.Combine(Server.MapPath(model.files)));
                }
                if (EmirateFile != null)
                {
                    model.EmirateFile = "/Images/EmirateFile/" + Guid.NewGuid() + Path.GetExtension(EmirateFile.FileName);
                    EmirateFile.SaveAs(Path.Combine(Server.MapPath(model.EmirateFile)));
                }
                if (PassportFile != null)
                {
                    model.PassportFile = "/Images/PassportFile/" + Guid.NewGuid() + Path.GetExtension(PassportFile.FileName);
                    PassportFile.SaveAs(Path.Combine(Server.MapPath(model.PassportFile)));
                }
                if (VisaFile != null)
                {
                    model.VisaFile = "/Images/VisaFile/" + Guid.NewGuid() + Path.GetExtension(VisaFile.FileName);
                    VisaFile.SaveAs(Path.Combine(Server.MapPath(model.VisaFile)));
                }
                if (InsuranceFile != null)
                {
                    model.InsuranceFile = "/Images/InsuranceFile/" + Guid.NewGuid() + Path.GetExtension(InsuranceFile.FileName);
                    InsuranceFile.SaveAs(Path.Combine(Server.MapPath(model.InsuranceFile)));
                }
                if (EmpCardFile != null)
                {
                    model.EmpCardFile = "/Images/EmployeeContactCardFile/" + Guid.NewGuid() + Path.GetExtension(EmpCardFile.FileName);
                    EmpCardFile.SaveAs(Path.Combine(Server.MapPath(model.EmpCardFile)));
                }

                model.EmpDocId = EmpDocId;
                if (model.EmpDocId == null || model.EmpDocId == "")
                {
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "11";
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
                   
                    model.files = model.files == "undefined" ? null : model.files;
                    model.EmirateFile = model.EmirateFile == "undefined" ? null : model.EmirateFile;
                    model.PassportFile = model.PassportFile == "undefined" ? null : model.PassportFile;
                    model.VisaFile = model.VisaFile == "undefined" ? null : model.VisaFile; 
                    model.InsuranceFile = model.InsuranceFile == "undefined" ? null : model.InsuranceFile;
                    model.EmpCardFile = model.EmpCardFile == "undefined" ? null : model.EmpCardFile;
            
                    model.CreatedBy = Session["userId"].ToString();
                    model.QueryType = "21";
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


        public ActionResult EmployeeDocumentsList()
        {
            List<HRMSEmployeeDocumentsModel> EmployeeDocumentsList = new List<HRMSEmployeeDocumentsModel>();

            var GroupList = DL.GetEmployeeDocumentsList();
            foreach (var i in GroupList)
            {
                EmployeeDocumentsList.Add(new HRMSEmployeeDocumentsModel
                {
                    EmpDocId = i.EmpDocId,
                    FK_BranchId = i.FK_BranchId,
                    BranchName=i.BranchName,
                    EmployeeName = i.EmployeeName,
                    files = i.files,
                    EmirateFile = i.EmirateFile,
                    PassportFile = i.PassportFile,
                    VisaFile = i.VisaFile,
                    InsuranceFile = i.InsuranceFile,
                    EmpCardFile = i.EmpCardFile

                });
            }
            return Json(EmployeeDocumentsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteEmployeeDocuments(HRMSEmployeeDocumentsModel model, string EmpDocId)
        {
            try
            {

                model.EmpDocId = objcls.Decrypt(EmpDocId);
                model.QueryType = "41";
                model = DL.DeleteEmployeeDocuments(model);
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