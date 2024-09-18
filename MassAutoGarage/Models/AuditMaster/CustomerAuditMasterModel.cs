using MassAutoGarage.Models.CustomerMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.AuditMaster
{
    public class CustomerAuditMasterModel
    {
        public string CustomerID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AccountName { get; set; }
        public string ContactPersonName { get; set; }
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

        public int VATCustomerID { get; set; }
        public string VATCustomer { get; set; }
        public string TradeLicenceExpiry { get; set; }
        public string LoyaltyPoints { get; set; }


        public int InternationalID { get; set; }
        public int UAEID { get; set; }
        public int GCCID { get; set; }
        public string CountryName { get; set; }
        public string UAE_Country { get; set; }
        public string GCCCountry { get; set; }


        public string Group { get; set; }
        public string AdvisorName { get; set; }
        public string DiscountAllowedAmt { get; set; }
        public string Source { get; set; }
        public string Gender { get; set; }
        public string DiscountAllowedPercentage { get; set; }
        public string Salesman { get; set; }
        public string Nationality { get; set; }
        public string Individualorcompany { get; set; }


        // Additional Contacts
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Desination { get; set; }
        public string ContactAction { get; set; }
        public string ContactActionDate { get; set; }


        //Attachment Details

        public string Description { get; set; }
        public string ExpiryDate { get; set; }
        public string AttachmentFile { get; set; }
        public string AttachmentAction { get; set; }
        public string AttachmentActionDate { get; set; }

        public string QueryType { get; set; }
        public string Flag { get; set; }
        public int CreatedBy { get; set; }
        public Int64 MaxID { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Status { get; set; }
        public int IsUpdated { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string ActionDate { get; set; }
        public string ResourceBy { get; set; }

        public List<CustomerAuditMasterModel> CustomerAuditMasterModelList { get; set; }
    }
}