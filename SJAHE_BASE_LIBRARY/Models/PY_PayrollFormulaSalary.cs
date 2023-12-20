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
    [Table("PY_PayrollFormulaSalary")]
    public class PY_PayrollFormulaSalary
    {
        [Key]
        public int PayrollFormulaSalaryID { get; set; }

        [DisplayName("Salary Component")]
        public int SalaryComponentID { get; set; }
        public int SequenceNo { get; set; }
        public string Condition { get; set; }
        public string Formula { get; set; }
        public bool FlagProcess { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PY_SalaryComponent PY_SalaryComponent { get; set; }
    }
}
