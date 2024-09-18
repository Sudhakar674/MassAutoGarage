using MassAutoGarage.Models.SourceMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.SalesmanMaster
{
    public class SalesmanMasterModel
    {
        public Int64 SalesID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string SalesMan { get; set; }
        public string Mobile { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string CurrentCount { get; set; }
        
        public List<SalesmanMasterModel> SalesmanMasterModelList { get; set; }
    }
}