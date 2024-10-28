using MassAutoGarage.Data.HRMS_EmployeeDocuments;
using MassAutoGarage.Data;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassAutoGarage.Models.HRMS_EmployeeFamilyDetails;
using MassAutoGarage.Data.HRMS_EmployeeFamilyDetails;
using System.IO;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Org.BouncyCastle.Asn1.X509;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeFamilyDetailsController : Controller
    {
        // GET: HRMS_EmployeeFamilyDetails
        HRMSEmployeeFamilyDetailsModel model = new HRMSEmployeeFamilyDetailsModel();
        HRMSEmployeeFamilyDetailsDL DL = new HRMSEmployeeFamilyDetailsDL();
        ClsGeneral objcls = new ClsGeneral();
        public ActionResult Index(string Key)
        {
            List<HRMSEmployeeFamilyDetailsModel> EmployeeFamilyList = new List<HRMSEmployeeFamilyDetailsModel>();

            if (Key != "" && Key != null)
            {
                var GroupList = DL.SearchByKey("34", Key);
                foreach (var i in GroupList)
                {
                    EmployeeFamilyList.Add(new HRMSEmployeeFamilyDetailsModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        MotherName = i.MotherName,
                        EmployeeName = i.EmployeeName,
                        MaritalStatus = i.MaritalStatus,
                        FatherName = i.FatherName,
                        Photo = i.Photo
                    });
                }
            }
            else
            {
                var GroupList = DL.GetEmployeeFamilyList();
                foreach (var i in GroupList)
                {
                    EmployeeFamilyList.Add(new HRMSEmployeeFamilyDetailsModel
                    {
                        ID = objcls.Encrypt(i.ID),
                        BranchName = i.BranchName,
                        MotherName = i.MotherName,
                        EmployeeName = i.EmployeeName,
                        MaritalStatus = i.MaritalStatus,
                        FatherName = i.FatherName,
                        Photo = i.Photo
                    });
                }
            }
            return View(EmployeeFamilyList);
        }
        public ActionResult EmployeeFamilyDetails(HRMSEmployeeFamilyDetailsModel model, string Id)
        {
            ViewBag.BranchList = DL.DropdownList();
            ViewBag.MaritalList = DL.DropdownListMarital();

            if (Id != null)
            {
                model.ID = objcls.Decrypt(Id);
                model.QueryType = "35";
                var lst = DL.GetEmployeeFamilyDetailsById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.BranchId = lst.BranchId;
                    model.MotherName = lst.MotherName;
                    model.EmployeeName = lst.EmployeeName;
                    model.MaritalStatusId = lst.MaritalStatusId;
                    model.FatherName = lst.FatherName;
                    model.Photo = lst.Photo;
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult SaveEmployeeFamilyDetails(HRMSEmployeeFamilyDetailsModel model, HttpPostedFileBase Photo)
        {
            try
            {
                if (Photo != null)
                {
                    model.Photo = "/Images/EmployeeFamilyPhoto/" + Guid.NewGuid() + Path.GetExtension(Photo.FileName);
                    Photo.SaveAs(Path.Combine(Server.MapPath(model.Photo)));
                }
                if (model.ID == null || model.ID == "")
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
                    model.Photo = model.Photo == "undefined" ? null : model.Photo;
                    model.CreatedBy = Session["userId"].ToString();
                    model.ID = objcls.Decrypt(model.ID);
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


        [HttpPost]
        public ActionResult DeleteEmployeeFamilyDetails(HRMSEmployeeFamilyDetailsModel model, string ID)
        {
            try
            {

                model.ID = objcls.Decrypt(ID);
                model.QueryType = "41";
                model = DL.DeleteEmployeeFamilyDetails(model);
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