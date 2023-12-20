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
    [Table("PY_EmpSalaryCalculated")]
    public class PY_EmpSalaryCalculated
    {
        [Key]
        public int SalaryCalculatedID { get; set; }

        [DisplayName("Salary Component")]
        public int SalaryComponentID { get; set; }
        [DisplayName("Employee No")]
        public string EmployeeNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal ComponentValue { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PY_SalaryComponent PY_SalaryComponent { get; set; }
    }
}
