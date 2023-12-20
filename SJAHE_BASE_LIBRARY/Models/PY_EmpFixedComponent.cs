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
    [Table("PY_EmpFixedComponent")]
    public class PY_EmpFixedComponent
    {
        [Key]
        public int EmpFixedComponentID { get; set; }

        [DisplayName("Emp ID")]
        [Required(ErrorMessage = "Emp id is required")]
        public string EmployeeNo { get; set; }

        //[DisplayName("Month")]
        //[Required(ErrorMessage = "Month is required")]
        //public int Month { get; set; }

        //[DisplayName("Year")]
        //[Required(ErrorMessage = "Year is required")]
        //public int Year { get; set; }

        [DisplayName("Fixed Comp Name")]
        [Required(ErrorMessage = "Fixed component name is required")]
        public int FixedComponentID { get; set; }

        [DisplayName("Fixed Comp Value")]
        [Required(ErrorMessage = "Fixed component value is required")]
        public decimal FixedComponentValue { get; set; }

        public string EF01 { get; set; }
        public string EF02 { get; set; }
        public string EF03 { get; set; }

        [DisplayName("Created By")]
        public int EmpFixedComponentCreatedBy { get; set; }

        [DisplayName("Date Created On")]
        public DateTime EmpFixedComponentDateCreatedOn { get; set; }

        public virtual PY_FixedComponent PY_FixedComponent { get; set; }
        //public virtual PA_RegEmpOccupation PA_RegEmpOccupation { get; set; }
    }
}
