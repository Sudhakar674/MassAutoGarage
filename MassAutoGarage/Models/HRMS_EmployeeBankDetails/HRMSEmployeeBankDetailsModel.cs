using MassAutoGarage.Models.HRMS_EmployeeDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_EmployeeBankDetails
{
    public class HRMSEmployeeBankDetailsModel
    {
        public string Id { get; set; }
        public string IdEncrypte { get; set; }
        public string BranchId { get; set; }
        public string AccountNumber { get; set; }
        public string EmployeeName { get; set; }
        public string IBANCODE { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string StatusId { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string ID { get; set; }
        public string BranchName { get; set; }
        public string Status { get; set; }

        public List<HRMSEmployeeBankDetailsModel> EmployeeBankDetailslst { get; set; }

    }
}