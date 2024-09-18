using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models
{
    public class CompanyMasterModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Code Id is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Group Name Id is Required")]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string TRN { get; set; }
        public string Email { get; set; }
        public string LocationMapUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public int IsActive { get; set; }
        public string QueryType { get; set; }
        public int Flag { get; set; }
        public string CompanyId { get; set; }
        public string CompanyLogo { get; set; }
        public string CurrentCount { get; set; }
        public List<CompanyMasterModel> CompanyMasterModelList { get; set; }

    }
}