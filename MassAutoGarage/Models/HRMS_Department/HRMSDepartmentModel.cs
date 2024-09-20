using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_Department
{
    public class HRMSDepartmentModel
    {

        public int DeptID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public int IsActive { get; set; }
        public string QueryType { get; set; }
        public int Flag { get; set; }
        public string DepartmentId { get; set; }

        public string result { get; set; }
        public List<HRMSDepartmentModel> HRMSDepartmentModelList { get; set; }
    }
}