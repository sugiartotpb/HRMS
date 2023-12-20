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
    [Table("PY_MonthlyEmpTarifComponent")]
    public class PY_MonthlyEmpTarifComponent
    {
        [Key]
        public int MonthlyEmpTarifComponentID { get; set; }

        [DisplayName("Employee No")]
        public string EmployeeNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TarifComponentID { get; set; }
        public decimal TarifComponentValue { get; set; }
        public decimal? TarifComponentPayrollProcess { get; set; }
        public string ET01 { get; set; }
        public string ET02 { get; set; }
        public string ET03 { get; set; }
        public int EmpTarifComponentCreatedBy { get; set; }
        public DateTime EmpTarifComponentDateCreatedOn { get; set; }

        public virtual PY_TarifComponent PY_TarifComponent { get; set; }
    }
}
