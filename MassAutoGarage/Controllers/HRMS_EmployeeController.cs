using MassAutoGarage.Data.HRMS_Employee;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
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
            //List<HRMSEmployeeModel> EmployeeList = new List<HRMSEmployeeModel>();

            //var GroupList = DL.EmployeeList();
            //foreach (var i in GroupList)
            //{
            //    EmployeeList.Add(new HRMSEmployeeModel
            //    {
            //        EmployeeId = i.EmployeeId,
            //        EmployeeCode = i.EmployeeCode,
            //        EmployeeName = i.EmployeeName,
            //        Photo = i.Photo
            //    });
            //}
            //return Json(EmployeeList, JsonRequestBehavior.AllowGet);
            return View();
        }

        public ActionResult Employee()
        {
            ViewBag.DepartmentDropdownList = DL.DepartmentDropdownList();
            ViewBag.BranchLocationDropdownList = DL.BranchLocationDropdownList();
            ViewBag.NationalityDropdownList = DL.NationalityDropdownList();
            ViewBag.MaritalStatusDropdownList = DL.MaritalStatusDropdownList();
            ViewBag.StatusDropdownList = DL.StatusDropdownList();

            return View();
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
                    DepartmentId=i.DepartmentId,
                    DepartmentName=i.DepartmentName,
                    BranchLocationId = i.BranchLocationId,
                    BranchName =i.BranchName,
                    NationalityId=i.NationalityId,
                    Nationality=i.Nationality,
                    MaritalStatusId=i.MaritalStatusId,
                    MaritalStatus=i.MaritalStatus,
                    StatusId=i.StatusId,
                    Status=i.Status,
                    EmployeeCode = i.EmployeeCode,
                    EmployeeName = i.EmployeeName,
                    Designation = i.Designation,
                    ReportingManager = i.ReportingManager,
                    JoiningDate= i.JoiningDate,
                    DateOfBirth= i.DateOfBirth,
                    GenderBloodGroup= i.GenderBloodGroup,
                    PassportNo= i.PassportNo,
                    PassportIssueDate= i.PassportIssueDate,
                    PassportExpiryDate= i.PassportExpiryDate,
                    HomeCountryAirport= i.HomeCountryAirport,
                    HomeCountryContactNumber1= i.HomeCountryContactNumber1,
                    HomeCountryContactNumber2 = i.HomeCountryContactNumber2,
                    EmergencyContactNo= i.EmergencyContactNo,
                    Email=i.Email,
                    AccountNo= i.AccountNo,
                    WPSDebitCardNumber=i.WPSDebitCardNumber,
                    WPSExpiry=i.WPSExpiry,
                    TotalLeavePerYear= i.TotalLeavePerYear,
                    NoOfWorkingHours= i.NoOfWorkingHours,
                    NoOfDays= i.NoOfDays,
                    LabourCardNo= i.LabourCardNo,
                    LabourCardExpiry= i.LabourCardExpiry,
                    PersonCode= i.PersonCode,


                    Photo = i.Photo
                });
            }
            return Json(EmployeeList, JsonRequestBehavior.AllowGet);
        }

  //   HE.Id as EmployeeId, DeptID,DepartmentName,BM.ID as BranchId,BranchName,NM.ID as NationalityId,Nationality,
  //   HMS.ID as MaritalStatusId,MaritalStatus,SM.ID as StatusId,Status ,EmployeeCode,EmployeeName,Designation,ReportingManager,
  //   JoiningDate,BranchLocationId,NationalityId,DateOfBirth,MaritalStatusId,GenderBloodGroup,PassportNo,PassportIssueDate,
  //   PassportExpiryDate,HomeCountryAirport,HomeCountryContactNumber1,HomeCountryContactNumber2,EmergencyContactNo,Email,AccountNo,
  //   WPSDebitCardNumber,WPSExpiry,TotalLeavePerYear,NoOfWorkingHours,NoOfDays,LabourCardNo,LabourCardExpiry,PersonCode,UAEContactNo1,
  //   UAEContactNo2,
	 //UAEAddress,BasicSalary,Transportation,Accommodation,AdditionalAllowance,Standard,Skill,AccommodationAllowance,Cola,Education,CarAllowance,
  //   Telephone,Others,TotalSalary,EmiratesID,EmiratesIDExpiry,VisaUIDNo,VisaFileNo,VisaPlaceOfIssue,VisaIssueDate,VisaExpiry,InsuranceProvider,
  //   InsuranceNumber,InsuranceExpiry,StatusId,ResignationTerminationDate,Remarks,Organization,TicketIssuedPerYear,Photo


    }
}