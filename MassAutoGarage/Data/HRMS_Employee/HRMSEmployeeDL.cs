using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using MassAutoGarage.DBContext;
using MassAutoGarage.Models.HRMS_Employee;
using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using MassAutoGarage.Models.HRMS_Holiday;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace MassAutoGarage.Data.HRMS_Employee
{
    public class HRMSEmployeeDL
    {
        public List<HRMSEmployeeModel> DepartmentDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "32");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HRMSEmployeeModel> BranchLocationDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "33");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HRMSEmployeeModel> NationalityDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "34");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeModel> MaritalStatusDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "35");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HRMSEmployeeModel> StatusDropdownList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", "37");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public HRMSEmployeeModel AddUpdate(HRMSEmployeeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@EmployeeCode", obj.EmployeeCode);
                Parameters.Add("@EmployeeName", obj.EmployeeName);
                Parameters.Add("@Designation", obj.Designation);
                Parameters.Add("@ReportingManager", obj.ReportingManager);
                Parameters.Add("@DepartmentId", obj.DepartmentId); 
                Parameters.Add("@JoiningDate", obj.JoiningDate);
                Parameters.Add("@BranchLocationId", obj.BranchLocationId);
                Parameters.Add("@NationalityId", obj.NationalityId);
                Parameters.Add("@DateOfBirth", obj.DateOfBirth);
                Parameters.Add("@MaritalStatusId", obj.MaritalStatusId);
                Parameters.Add("@GenderBloodGroup", obj.GenderBloodGroup);
                Parameters.Add("@PassportNo", obj.PassportNo); 
                Parameters.Add("@PassportIssueDate", obj.PassportIssueDate);
                Parameters.Add("@PassportExpiryDate", obj.PassportExpiryDate);
                Parameters.Add("@HomeCountryAirport", obj.HomeCountryAirport);
                Parameters.Add("@HomeCountryContactNumber1", obj.HomeCountryContactNumber1);
                Parameters.Add("@HomeCountryContactNumber2", obj.HomeCountryContactNumber2);
                Parameters.Add("@EmergencyContactNo", obj.EmergencyContactNo);
                Parameters.Add("@Email", obj.Email);
                Parameters.Add("@AccountNo", obj.AccountNo);
                Parameters.Add("@WPSDebitCardNumber", obj.WPSDebitCardNumber);
                Parameters.Add("@WPSExpiry", obj.WPSExpiry);
                Parameters.Add("@TotalLeavePerYear", obj.TotalLeavePerYear);
                Parameters.Add("@NoOfWorkingHours", obj.NoOfWorkingHours);
                Parameters.Add("@NoOfDays",obj.NoOfDays);
                Parameters.Add("@LabourCardNo", obj.LabourCardNo);
                Parameters.Add("@LabourCardExpiry", obj.LabourCardExpiry);
                Parameters.Add("@PersonCode", obj.PersonCode);
                Parameters.Add("@UAEContactNo1", obj.UAEContactNo1);
                Parameters.Add("@UAEContactNo2", obj.UAEContactNo2);
                Parameters.Add("@UAEAddress", obj.UAEAddress);
                Parameters.Add("@BasicSalary", obj.BasicSalary);
                Parameters.Add("@Transportation", obj.Transportation);
                Parameters.Add("@Accommodation", obj.Accommodation);
                Parameters.Add("@AdditionalAllowance", obj.AdditionalAllowance);
                Parameters.Add("@Standard", obj.Standard);
                Parameters.Add("@Skill", obj.Skill);
                Parameters.Add("@AccommodationAllowance", obj.AccommodationAllowance);
                Parameters.Add("@Cola", obj.Cola);
                Parameters.Add("@Education", obj.Education);
                Parameters.Add("@CarAllowance", obj.CarAllowance);
                Parameters.Add("@Telephone", obj.Telephone);
                Parameters.Add("@Others", obj.Others);
                Parameters.Add("@TotalSalary", obj.TotalSalary);
                Parameters.Add("@EmiratesID", obj.EmiratesID);
                Parameters.Add("@EmiratesIDExpiry", obj.EmiratesIDExpiry);
                Parameters.Add("@VisaUIDNo", obj.VisaUIDNo);
                Parameters.Add("@VisaFileNo", obj.VisaFileNo);
                Parameters.Add("@VisaPlaceOfIssue", obj.VisaPlaceOfIssue);
                Parameters.Add("@VisaIssueDate", obj.VisaIssueDate);
                Parameters.Add("@VisaExpiry", obj.VisaExpiry);
                Parameters.Add("@InsuranceProvider", obj.InsuranceProvider);
                Parameters.Add("@InsuranceNumber", obj.InsuranceNumber);
                Parameters.Add("@InsuranceExpiry", obj.InsuranceExpiry);
                Parameters.Add("@StatusId", obj.StatusId);
                Parameters.Add("@ResignationTerminationDate", obj.ResignationTerminationDate);
                Parameters.Add("@Remarks", obj.Remarks);
                Parameters.Add("@Organization", obj.Organization);
                Parameters.Add("@TicketIssuedPerYear", obj.TicketIssuedPerYear);
                Parameters.Add("@Photo", obj.Photo);
                Parameters.Add("@CreatedBy", obj.CreatedBy);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeModel>("USP_HRMS_Employee", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public List<HRMSEmployeeModel> EmployeeList()
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", "31");
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HRMSEmployeeModel DeleteEmployee(HRMSEmployeeModel obj)
        {
            try
            {
                var Parameters = new DynamicParameters();

                Parameters.Add("@QueryType", obj.QueryType);
                Parameters.Add("@EmployeeId", obj.EmployeeId);
                var _iresult = DBHelperDapper.DAAddAndReturnModel<HRMSEmployeeModel>("USP_HRMS_Employee", Parameters);
                return _iresult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<HRMSEmployeeModel> GetEmployeeDetaildById(HRMSEmployeeModel objmodel)
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@QueryType", objmodel.QueryType);
                Parameters.Add("@EmployeeId", objmodel.EmployeeId);
                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", Parameters);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<HRMSEmployeeModel> SearchByKey(string Querytype, string SearchKey)
        {
            List<HRMSEmployeeModel> obj = new List<HRMSEmployeeModel>();
            try
            {
                var perm = new DynamicParameters();
                perm.Add("@QueryType", Querytype);
                perm.Add("@SearchKey", SearchKey);

                obj = DBHelperDapper.DAAddAndReturnModelList<HRMSEmployeeModel>("USP_HRMS_Employee", perm);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }














    }
}