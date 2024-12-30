using MassAutoGarage.Models.HR_GeneralRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_RecruitmentRequisition
{
    public class HR_RecruitmentRequisitionModel
    {
        public string Idincrept { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string FullName { get; set; }
        public string Date { get; set; }
        public string ExpectedSalary { get; set; }
        public string SalaryOffered { get; set; }
        public bool AdditionNew { get; set; }
        public bool Budgeted { get; set; }
        public bool Replacement { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_RecruitmentRequisitionModel> lst { get; set; }
    }
}