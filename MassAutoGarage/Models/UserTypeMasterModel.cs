using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models
{
    public class UserTypeMasterModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string UserType { get; set; }
        public int IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public string UserId { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; } 
        public string CurrentCount { get; set; }

        public List<UserTypeMasterModel> UserTypeMasterModelList { get; set; }
    }
}