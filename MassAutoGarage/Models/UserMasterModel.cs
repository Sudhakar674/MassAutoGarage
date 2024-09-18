using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models
{
    public class UserMasterModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public Int64 UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        [Required(ErrorMessage = "Please Enter Login ID !")]
        public string LoginId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int64 UpdateddBy { get; set; }
        public string UserId { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public DateTime SDate { get; set; }

        public string CurrentCount { get; set; }
        public List<UserMasterModel> UserMasterModelList { get; set; }

    }
}