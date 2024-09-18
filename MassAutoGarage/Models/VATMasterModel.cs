using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models
{
    public class VATMasterModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal VAT { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Printing { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public int Flag { get; set; }
        public string VatID { get; set; }
        public string QueryType { get; set; }

        public DateTime StrDate { get; set; }
        public DateTime EdingDate { get; set; }
        public string SearchKey { get; set; }
        public string CurrentCount { get; set; }
        
        public List<VATMasterModel> VATMasterModelList { get; set; }

    }
}