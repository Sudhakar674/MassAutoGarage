using MassAutoGarage.Models.NationalityMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.GenderMaster
{
    public class GenderMasterModel
    {
        public Int64 GenderID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string Gender { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string CurrentCount { get; set; }
        
        public List<GenderMasterModel> GenderMasterModelList { get; set; }
    }
}