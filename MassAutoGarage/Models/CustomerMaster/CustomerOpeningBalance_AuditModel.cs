using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.CustomerMaster
{
    public class CustomerOpeningBalance_AuditModel
    {
        public string BalanceID { get; set; }
        public string ID { get; set; }
        public string JobCardDate { get; set; }
        public string JobCardNumber { get; set; }
        public int ToAccountID { get; set; }
        public string ToAccountName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }

        public string ToAccountNumber { get; set; }
        public string LPONO { get; set; }
        public string EstNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string QueryType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Flag { get; set; }       
        public string Action { get; set; }
        public string ActionDate { get; set; }
        public List<CustomerOpeningBalance_AuditModel> CustomerOpeningBalance_AuditModelList { get; set; }
    }
}