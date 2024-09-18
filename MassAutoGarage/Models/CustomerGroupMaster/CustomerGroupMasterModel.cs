using MassAutoGarage.Models.StatusMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.CustomerGroupMaster
{
    public class CustomerGroupMasterModel
    {
        public Int64 GroupID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string CustomerGroupName { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string CurrentCount { get; set; }

        public List<CustomerGroupMasterModel> CustomerGroupMasterModelList { get; set; }
    }
}