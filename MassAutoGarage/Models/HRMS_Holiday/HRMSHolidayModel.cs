using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Models.HRMS_Holiday
{
    public class HRMSHolidayModel
    {
        public string HolidayId { get; set; }
        public string FK_DepartmentId { get; set; }
        public string HolidayDate { get; set; }
        public string HolidayName { get; set; }
        public string CreatedBy { get; set; }
        public string QueryType { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string DeptID { get; set; }
        public string DepartmentName { get; set; }

    }
}