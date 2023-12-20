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
    [Table("PY_PayrollPeriod")]
    public class PY_PayrollPeriod
    {
        [Key]
        public int PayrollPeriodID { get; set; }

        [Required(ErrorMessage = "Month required")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Year required")]
        public int Year { get; set; }

        [DisplayName("Salary Start Date")]
        [Required(ErrorMessage = "Salary start date required")]
        public DateTime SalaryStartDate { get; set; }

        [DisplayName("Salary End Date")]
        [Required(ErrorMessage = "Salary end date required")]
        public DateTime SalaryEndDate { get; set; }

        [DisplayName("Salary End Date")]
        [Required(ErrorMessage = "Salary end date required")]
        public DateTime OvertimeStartDate { get; set; }

        [DisplayName("Salary End Date")]
        [Required(ErrorMessage = "Salary end date required")]
        public DateTime OvertimeEndDate { get; set; }

        [DisplayName("Salary End Date")]
        [Required(ErrorMessage = "Salary end date required")]
        public DateTime AbsenteeismStartDate { get; set; }

        [DisplayName("Absenteeism End Date")]
        [Required(ErrorMessage = "Absenteeism end date required")]
        public DateTime AbsenteeismEndDate { get; set; }

        [DisplayName("Jamsostek Start Date")]
        [Required(ErrorMessage = "Jamsostek start date required")]
        public DateTime JamsostekStartDate { get; set; }

        [DisplayName("Jamsostek End Date")]
        [Required(ErrorMessage = "Jamsostek end date required")]
        public DateTime JamsostekEndDate { get; set; }

        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
