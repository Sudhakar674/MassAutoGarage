using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_NewStaffJoining
{
    public class HR_NewStaffJoiningModel
    {
            public string Idincrept { get; set; }
            public string Id { get; set; }
            public string VoucherNumber { get; set; }
            public string hdfVoucherNumber { get; set; }          
            public string EmployeeName { get; set; }
            public string Date { get; set; }
            public string DesignationId { get; set; }
            public string Designation { get; set; }         
            public string DepartmentId { get; set; }
            public string DepartmentName { get; set; }
            public string EmpNo { get; set; }        
            public string JoiningDate { get; set; }
            public string JoiningTime { get; set; }
            public string FilledByEmployee { get; set; }           
            public string CreatedBy { get; set; }
            public string QueryType { get; set; }
            public string Message { get; set; }
            public string Result { get; set; }
            public string MaxID { get; set; }
            public List<HR_NewStaffJoiningModel> lst { get; set; }    
    }
}