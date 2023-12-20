using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJAHE_BASE_LIBRARY.Models
{
    [Table("PY_MonthlyEmpFixedComponent")]
    public class PY_MonthlyEmpFixedComponent
    {
        [Key]
        public int MonthlyEmpFixedComponentID { get; set; }

        [DisplayName("Employee No")]
        public string EmployeeNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int FixedComponentID { get; set; }
        public decimal FixedComponentValue { get; set; }
        public decimal? FixedComponentPayrollProcess { get; set; }
        public string EF01 { get; set; }
        public string EF02 { get; set; }
        public string EF03 { get; set; }
        public int EmpFixedComponentCreatedBy { get; set; }
        public DateTime EmpFixedComponentDateCreatedOn { get; set; }

        public virtual PY_FixedComponent PY_FixedComponent { get; set; }
    }
}
