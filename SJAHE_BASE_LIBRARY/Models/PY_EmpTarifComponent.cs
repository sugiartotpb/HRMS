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
    [Table("PY_EmpTarifComponent")]
    public class PY_EmpTarifComponent
    {
        [Key]
        public int EmpTarifComponentID { get; set; }

        [DisplayName("Employee No")]
        [Required(ErrorMessage = "Emp id is required")]
        public string EmployeeNo { get; set; }

        //[DisplayName("Month")]
        //[Required(ErrorMessage = "Month is required")]
        //public int Month { get; set; }

        //[DisplayName("Year")]
        //[Required(ErrorMessage = "Year is required")]
        //public int Year { get; set; }

        [DisplayName("Tarif Component Name")]
        [Required(ErrorMessage = "Tarif component name is required")]
        public int TarifComponentID { get; set; }

        [DisplayName("Tarif Component Value")]
        [Required(ErrorMessage = "Tarif component value is required")]
        public decimal TarifComponentValue { get; set; }

        public string ETF01 { get; set; }
        public string ETF02 { get; set; }
        public string ETF03 { get; set; }
        public int EmpTarifComponentCreatedBy { get; set; }
        public DateTime EmpTarifComponentDateCreatedOn { get; set; }

        public virtual PY_TarifComponent PY_TarifComponent { get; set; }
    }
}
