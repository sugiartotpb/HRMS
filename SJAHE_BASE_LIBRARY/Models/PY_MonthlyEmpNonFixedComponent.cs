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
    [Table("PY_MonthlyEmpNonFixedComponent")]
    public class PY_MonthlyEmpNonFixedComponent
    {
        [Key]
        public int MonthlyEmpNonFixedComponentID { get; set; }

        [DisplayName("Employee No")]
        public string EmployeeNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int NonFixedComponentID { get; set; }
        public decimal NonFixedComponentValue { get; set; }
        public decimal? NonFixedComponentPayrollProcess { get; set; }
        public string ENF01 { get; set; }
        public string ENF02 { get; set; }
        public string ENF03 { get; set; }
        public int EmpNonFixedComponentCreatedBy { get; set; }
        public DateTime EmpNonFixedComponentDateCreatedOn { get; set; }

        public virtual PY_NonFixedComponent PY_NonFixedComponent { get; set; }
    }
}
