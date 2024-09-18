using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.SupplierMaster
{
    public class OpeningBalanceModel
    {
        public Int64 BalanceID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public Int64 SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public int ToAccountID { get; set; }
        public string ToAccountName { get; set; }
        public int MaxID { get; set; }
        public string ToAccountNumber { get; set; }
        public string LPONO { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string CurrentCount { get; set; }
        public string QueryType { get; set; }
        public string Flag { get; set; }
        public Int64 CreatedBy { get; set; }
        public Int64 BalanceDetID { get; set; }
        public Int64 IsAction { get; set; }
        public List<OpeningBalanceModel> OpeningBalanceModelList { get; set; }
    }
}