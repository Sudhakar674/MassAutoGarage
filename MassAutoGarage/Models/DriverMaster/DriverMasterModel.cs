using MassAutoGarage.Models.UnitMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.DriverMaster
{
    public class DriverMasterModel
    {
        public Int64 DriverID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string DriverName { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string CurrentCount { get; set; }
        public List<DriverMasterModel> DriverMasterModelList { get; set; }
    }
}