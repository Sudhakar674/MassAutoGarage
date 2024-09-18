using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.SupplierAuditDetails
{
    public class SupplierAuditDetailsModel
    {
        public string Code { get; set; }
        public string CompanyName { get; set; }
        public string SupplierName { get; set; }
        public string AccountName { get; set; }
        public string Mobile { get; set; }

        public string Email { get; set; }
        public string TRN { get; set; }
        public string Address { get; set; }
        public string CreationDate { get; set; }
        public string CreditDays { get; set; }
        public string CreditLimit { get; set; }
        public string Block { get; set; }
        public string TradeLicenceExpiry { get; set; }
        public string VATSupplier { get; set; }
        public string CountryName { get; set; }
        public string UAE_Country { get; set; }
        public string GCCCountry { get; set; }
        public string Reason { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UserName { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Action { get; set; }
        public string ActionDate { get; set; }
        public string ResourceBy { get; set; }
       
        
        public string ContactPerson { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string Designation { get; set; }
        public string ContactAction { get; set; }
        public string ContactActionDate { get; set; }
     
        
        public string ExpiryDate { get; set; }
        public string AttachmentFile { get; set; }
        public string Description { get; set; }       
        public string AttachmentAction { get; set; }
        public string AttachmentActionDate { get; set; }
        public string QueryType { get; set; }
        public string SupplierId { get; set; }
       
    }
}