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
    [Table("PY_EmpVariableComponent")]
    public class PY_EmpVariableComponent
    {
        [Key]
        public int EmpVariableComponentID { get; set; }

        [DisplayName("Emp ID")]
        [Required(ErrorMessage = "Emp id is required")]
        public string EmployeeNo { get; set; }

        //[DisplayName("Month")]
        //[Required(ErrorMessage = "Month is required")]
        //public int Month { get; set; }

        //[DisplayName("Year")]
        //[Required(ErrorMessage = "Year is required")]
        //public int Year { get; set; }

        [DisplayName("Variable Component Name")]
        [Required(ErrorMessage = "Variable component name is required")]
        public int VariableComponentID { get; set; }

        [DisplayName("Variable Component Value")]
        [Required(ErrorMessage = "Variable component value is required")]
        public decimal VariableComponentValue { get; set; }

        public string EV01 { get; set; }
        public string EV02 { get; set; }
        public string EV03 { get; set; }
        public int EmpVariableComponentCreatedBy { get; set; }
        public DateTime EmpVariableComponentDateCreatedOn { get; set; }

        public virtual PY_VariableComponent PY_VariableComponent { get; set; }
    }
}
