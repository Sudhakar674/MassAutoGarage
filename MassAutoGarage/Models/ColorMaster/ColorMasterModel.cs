using MassAutoGarage.Models.ModelMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.ColorMaster
{
    public class ColorMasterModel
    {
        public Int64 ColorMasterID { get; set; }
        public string ID { get; set; }
        public string Code { get; set; }
        public string ColorCode { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int Flag { get; set; }
        public string QueryType { get; set; }
        public string Color { get; set; }
        public string CurrentCount { get; set; }


        public List<ColorMasterModel> ColorMasterModelList { get; set; }
    }
}