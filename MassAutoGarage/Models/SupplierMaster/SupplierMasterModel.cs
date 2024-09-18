using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.SupplierMaster
{
    public class SupplierMasterModel
    {
        public Int64 SupplierID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string SupplierName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AccountName  { get; set; }
        public string LandlineNumber { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TRN { get; set; }
        public int IsActive { get; set; }

        // Additional Information
        public string CreationDate { get; set; }
        public string CreditDays { get; set; }
        public string CreditLimit { get; set; }
        public string Block { get; set; }
        public string Reason { get; set; }

        public string VATSupplierID { get; set; }
        public string VATSupplier { get; set; }
        public string TradeLicenceExpiry { get; set; }
        public int InternationalID { get; set; }
        public int UAEID { get; set; }
        public int GCCID { get; set; }

        public string CountryName { get; set; }
        public string UAE_Country { get; set; }
        public string GCCCountry { get; set; }

        // Additional Contacts
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Desination { get; set; }
       
        // Attachment details

        public string Description { get; set; }
        public string ExpiryDate { get; set; }
        public string AttachmentFile { get; set;}

        public string QueryType { get; set; }
        public string Flag { get; set; }
        public int CreatedBy { get; set; }
        public Int64 MaxID { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Status { get; set; }
        public int IsUpdated { get; set; }
        public string CurrentCount { get; set; }

        public string Photourl { get; set; }
        public string Signatureurl { get; set; }
        public List<SupplierMasterModel> SupplierMasterModelList { get; set; }
    }
}