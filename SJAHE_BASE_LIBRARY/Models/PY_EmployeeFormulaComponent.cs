using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SJAHE_BASE_LIBRARY.Models
{
    [Table("PY_EmployeeFormulaComponent")]
    public class PY_EmployeeFormulaComponent
    {
        [Key]
        public int FormulaComponentID { get; set; }

        [Required(ErrorMessage = "Component name required")]
        [DisplayName("Component Name")]
        public string ComponentName { get; set; }
        public int FormulaSequence { get; set; }
        public string Condition { get; set; }
        public string Formula { get; set; }
        public bool FlagProcess { get; set; }
    }
}