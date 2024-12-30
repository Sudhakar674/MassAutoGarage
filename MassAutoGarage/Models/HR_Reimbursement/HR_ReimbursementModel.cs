using MassAutoGarage.Models.HR_GeneralRequest;
using MassAutoGarage.Models.HRMS_SalesTarget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HR_Reimbursement
{
    public class HR_ReimbursementModel
    {   
        public string Idencrept { get; set; }
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public string hdfVoucherNo { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string ReimbursementId { get; set; }
        public string DateOfBill { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string MaxID { get; set; }
        public List<HR_ReimbursementModel> lst { get; set; }

    }
}