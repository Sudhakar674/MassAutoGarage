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
        ClsGeneral objcls = new ClsGeneral();
        HRMSEmployeeDL DL = new HRMSEmployeeDL();
        HRMSEmployeeModel model = new HRMSEmployeeModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employee(string key)
        {

            ViewBag.DepartmentDropdownList = DL.DepartmentDropdownList();
            ViewBag.BranchLocationDropdownList = DL.BranchLocationDropdownList();
            ViewBag.NationalityDropdownList = DL.NationalityDropdownList();
            ViewBag.MaritalStatusDropdownList = DL.MaritalStatusDropdownList();
            ViewBag.StatusDropdownList = DL.StatusDropdownList();

            if (key != null)
            {


                //model.EmployeeIdKey = objcls.Decrypt(Id);

                model.EmployeeId = key;
                model.QueryType = "42";
                var lst = DL.GetEmployeeDetaildById(model).FirstOrDefault();
                model.Result = "yes";
                if (lst != null)
                {
                    model.EmployeeId = lst.EmployeeId;
                    model.EmployeeCode = lst.EmployeeCode;
                    model.EmployeeName = lst.EmployeeName;
                    model.Designation = lst.Designation;
                    model.ReportingManager = lst.ReportingManager;
                    model.DeptID = lst.DepartmentId;
                    model.JoiningDate = lst.JoiningDate;
                    model.BranchId = lst.BranchLocationId;
                    model.NationalityId = lst.NationalityId;
                    model.DateOfBirth = lst.DateOfBirth;
                    model.MaritalStatusId = lst.MaritalStatusId;
                    model.GenderBloodGroup = lst.GenderBloodGroup;
                    model.PassportNo = lst.PassportNo;
                    model.PassportIssueDate = lst.PassportIssueDate;
                    model.PassportExpiryDate = lst.PassportExpiryDate;
                    model.HomeCountryAirport = lst.HomeCountryAirport;
                    model.HomeCountryContactNumber1 = lst.HomeCountryContactNumber1;
                    model.HomeCountryContactNumber2 = lst.HomeCountryContactNumber2;
                    model.EmergencyContactNo = lst.EmergencyContactNo;
                    model.Email = lst.Email;
                    model.AccountNo = lst.AccountNo;
                    model.WPSDebitCardNumber = lst.WPSDebitCardNumber;
                    model.WPSExpiry = lst.WPSExpiry;
                    model.TotalLeavePerYear = lst.TotalLeavePerYear;
                    model.NoOfWorkingHours = lst.NoOfWorkingHours;
                    model.NoOfDays = lst.NoOfDays;
                    model.LabourCardNo = lst.LabourCardNo;
                    model.LabourCardExpiry = lst.LabourCardExpiry;
                    model.PersonCode = lst.PersonCode;
                    model.UAEContactNo1 = lst.UAEContactNo1;
                    model.UAEContactNo2 = lst.UAEContactNo2;
                    model.UAEAddress = lst.UAEAddress;
                    model.Transportation = lst.Transportation;
                    model.Accommodation = lst.Accommodation;
                    model.AdditionalAllowance = lst.AdditionalAllowance;
                    model.Standard = lst.Standard;
                    model.Skill = lst.Skill;
                    model.AccommodationAllowance = lst.AccommodationAllowance;
                    model.Cola = lst.Cola;
                    model.Education = lst.Education;
                    model.CarAllowance = lst.CarAllowance;
                    model.Telephone = lst.Telephone;
                    model.Others = lst.Others;
                    model.TotalSalary = lst.TotalSalary;
                    model.EmiratesID = lst.EmiratesID;
                    model.EmiratesIDExpiry = lst.EmiratesIDExpiry;
                    model.VisaUIDNo = lst.VisaUIDNo;
                    model.VisaFileNo = lst.VisaFileNo;
                    model.VisaPlaceOfIssue = lst.VisaPlaceOfIssue;
                    model.VisaPlaceOfIssue = lst.VisaPlaceOfIssue;
                    model.InsuranceProvider = lst.InsuranceProvider;
                    model.InsuranceNumber = lst.InsuranceNumber;
                    model.InsuranceExpiry = lst.InsuranceExpiry;
                    model.StatusId = lst.StatusId;
                    model.ResignationTerminationDate = lst.ResignationTerminationDate;
                    model.Remarks = lst.Remarks;
                    model.Organization = lst.Organization;
                    model.TicketIssuedPerYear = lst.TicketIssuedPerYear;
                    model.Photo = lst.Photo;
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
                    model.Photo = "/Images/InsurancePhoto/" + Guid.NewGuid() + Path.GetExtension(Photo.FileName);
                    Photo.SaveAs(Path.Combine(Server.MapPath(model.Photo)));
                }
                if (model.EmployeeId == null || model.EmployeeId == "")
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

        public ActionResult EmployeeList()
        {
            List<HRMSEmployeeModel> EmployeeList = new List<HRMSEmployeeModel>();

            var GroupList = DL.EmployeeList();
            foreach (var i in GroupList)
            {
                EmployeeList.Add(new HRMSEmployeeModel
                {

                  
                    EmployeeIdKey = objcls.Encrypt(i.EmployeeId),
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