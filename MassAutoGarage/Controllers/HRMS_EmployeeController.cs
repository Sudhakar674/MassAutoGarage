using MassAutoGarage.Data;
using MassAutoGarage.Data.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace MassAutoGarage.Controllers
{
    public class HRMS_EmployeeController : Controller
    {
        // GET: HRMS_Employee
        HRMSEmployeeDL DL = new HRMSEmployeeDL();
        HRMSEmployeeModel model = new HRMSEmployeeModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee(HRMSEmployeeModel model, string Id)
        {
            ViewBag.DepartmentDropdownList = DL.DepartmentDropdownList();
            ViewBag.BranchLocationDropdownList = DL.BranchLocationDropdownList();
            ViewBag.NationalityDropdownList = DL.NationalityDropdownList();
            ViewBag.MaritalStatusDropdownList = DL.MaritalStatusDropdownList();
            ViewBag.StatusDropdownList = DL.StatusDropdownList();

            if (Id != null)
            {
                model.EmployeeId = Id;
                model.QueryType = "42";
                var lst = DL.GetEmployeeDetaildById(model).FirstOrDefault();

                if (lst != null)
                {
                    model.EmployeeId = lst.EmployeeId;
                    model.EmployeeCode = lst.EmployeeCode;
                    model.EmployeeName = lst.EmployeeName;         
                }
            }

            return View(model);      
        }

        [HttpPost]
        public ActionResult SaveEmployee(HRMSEmployeeModel model, HttpPostedFileBase Photo)
        {
            try
            {
                if (Photo != null)
                {
                    model.Photo = "/Images/EmployeePhoto/" + Guid.NewGuid() + Path.GetExtension(Photo.FileName);
                    Photo.SaveAs(Path.Combine(Server.MapPath(model.Photo)));
                }
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
            catch (Exception)
            {
                throw;
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeList()
        {
            List<HRMSEmployeeModel> EmployeeList = new List<HRMSEmployeeModel>();

            var GroupList = DL.EmployeeList();
            foreach (var i in GroupList)
            {
                EmployeeList.Add(new HRMSEmployeeModel
                {
                    EmployeeId = i.EmployeeId,
                    DepartmentId = i.DepartmentId,
                    DepartmentName = i.DepartmentName,
                    BranchLocationId = i.BranchLocationId,
                    BranchName = i.BranchName,
                    NationalityId = i.NationalityId,
                    Nationality = i.Nationality,
                    MaritalStatusId = i.MaritalStatusId,
                    MaritalStatus = i.MaritalStatus,
                    StatusId = i.StatusId,
                    Status = i.Status,
                    EmployeeCode = i.EmployeeCode,
                    EmployeeName = i.EmployeeName,
                    Designation = i.Designation,
                    ReportingManager = i.ReportingManager,
                    JoiningDate = i.JoiningDate,
                    DateOfBirth = i.DateOfBirth,
                    GenderBloodGroup = i.GenderBloodGroup,
                    PassportNo = i.PassportNo,
                    PassportIssueDate = i.PassportIssueDate,
                    PassportExpiryDate = i.PassportExpiryDate,
                    HomeCountryAirport = i.HomeCountryAirport,
                    HomeCountryContactNumber1 = i.HomeCountryContactNumber1,
                    HomeCountryContactNumber2 = i.HomeCountryContactNumber2,
                    EmergencyContactNo = i.EmergencyContactNo,
                    Email = i.Email,
                    AccountNo = i.AccountNo,
                    WPSDebitCardNumber = i.WPSDebitCardNumber,
                    WPSExpiry = i.WPSExpiry,
                    TotalLeavePerYear = i.TotalLeavePerYear,
                    NoOfWorkingHours = i.NoOfWorkingHours,
                    NoOfDays = i.NoOfDays,
                    LabourCardNo = i.LabourCardNo,
                    LabourCardExpiry = i.LabourCardExpiry,
                    PersonCode = i.PersonCode,
                    UAEContactNo1 = i.UAEContactNo1,
                    UAEContactNo2 = i.UAEContactNo2,
                    UAEAddress = i.UAEAddress,
                    BasicSalary = i.BasicSalary,
                    Transportation = i.Transportation,
                    Accommodation = i.Accommodation,
                    AdditionalAllowance = i.AdditionalAllowance,
                    Standard = i.Standard,
                    Skill = i.Skill,
                    AccommodationAllowance = i.AccommodationAllowance,
                    Cola = i.Cola,
                    Education = i.Education,
                    CarAllowance = i.CarAllowance,
                    Telephone = i.Telephone,
                    Others = i.Others,
                    TotalSalary = i.TotalSalary,
                    EmiratesID = i.EmiratesID,
                    EmiratesIDExpiry = i.EmiratesIDExpiry,
                    VisaUIDNo = i.VisaUIDNo,
                    VisaFileNo = i.VisaFileNo,
                    VisaPlaceOfIssue = i.VisaPlaceOfIssue,
                    VisaIssueDate = i.VisaIssueDate,
                    VisaExpiry = i.VisaExpiry,
                    InsuranceProvider = i.InsuranceProvider,
                    InsuranceNumber = i.InsuranceNumber,
                    InsuranceExpiry = i.InsuranceExpiry,
                    ResignationTerminationDate = i.ResignationTerminationDate,
                    Remarks = i.Remarks,
                    Organization = i.Organization,
                    TicketIssuedPerYear = i.TicketIssuedPerYear,
                    Photo = i.Photo
                });
            }
            return Json(EmployeeList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(HRMSEmployeeModel model, string EmployeeId)
        {
            try
            {
                model.EmployeeId = (EmployeeId);
                model.QueryType = "41";
                model = DL.DeleteEmployee(model);
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