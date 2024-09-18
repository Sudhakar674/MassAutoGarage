using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.DepartmentMaster
{
    public class DepartmentMasterModel
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string DepartmentName { get; set; }
        public int RevenueAccountID { get; set; }
        public string RevenueAccountName { get; set; }
        public int ExpenseAccountID { get; set; }
        public string ExpenseAccountName { get; set; }
        public int InventoryAccountID { get; set; }
        public string InventoryAccountName { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string QueryType { get; set; }
        public Int64 DeptID { get; set; }
        public int msg { get; set; }
        public string CurrentCount { get; set; }
        
        public List<DepartmentMasterModel> DepartmentMasterModelList { get; set; }

    }
}