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
    [Table("PY_EmpNonFixedComponent")]
    public class PY_EmpNonFixedComponent
    {
        [Key]
        public int EmpNonFixedComponentID { get; set; }

        [DisplayName("Employee No")]
        [Required(ErrorMessage = "Emp id required")]
        public string EmployeeNo { get; set; }

        //[DisplayName("Month")]
        //[Required(ErrorMessage = "Month is required")]
        //public int Month { get; set; }

        //[DisplayName("Year")]
        //[Required(ErrorMessage = "Year is required")]
        //public int Year { get; set; }

        [DisplayName("Non Fixed Comp Name")]
        [Required(ErrorMessage = "Non Fixed Component Name required")]
        public int NonFixedComponentID { get; set; }

        public string ENF01 { get; set; }
        public string ENF02 { get; set; }
        public string ENF03 { get; set; }
        public decimal NonFixedComponentValue { get; set; }

        [DisplayName("Created By")]
        public int EmpNonFixedComponentCreatedBy { get; set; }

        [DisplayName("Date Created On")]
        public DateTime EmpNonFixedComponentDateCreatedOn { get; set; }

        public virtual PY_NonFixedComponent PY_NonFixedComponent { get; set; }
    }
}
