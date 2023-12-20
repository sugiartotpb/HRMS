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
    [Table("PY_MonthlyEmpVariableComponent")]
    public class PY_MonthlyEmpVariableComponent
    {
        [Key]
        public int MonthlyEmpVariableComponentID { get; set; }

        [DisplayName("Employee No")]
        public string EmployeeNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int VariableComponentID { get; set; }
        public decimal VariableComponentValue { get; set; }
        public decimal? VariableComponentPayrollProcess { get; set; }
        public string EV01 { get; set; }
        public string EV02 { get; set; }
        public string EV03 { get; set; }
        public int EmpVariableComponentCreatedBy { get; set; }
        public DateTime EmpVariableComponentDateCreatedOn { get; set; }

        public virtual PY_VariableComponent PY_VariableComponent { get; set; }
    }
}
