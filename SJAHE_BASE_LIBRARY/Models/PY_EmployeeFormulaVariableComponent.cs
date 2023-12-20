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
    [Table("PY_EmployeeFormulaVariableComponent")]
    public class PY_EmployeeFormulaVariableComponent
    {
        [Key]
        public int FormulaVariableComponentID { get; set; }

        [DisplayName("Variable Component")]
        [Required(ErrorMessage = "Variable component required")]
        public int VariableComponentID { get; set; }

        [DisplayName("Formula Sequence")]
        [Required(ErrorMessage = "Formula sequence required")]
        public int FormulaSequence { get; set; }

        [DisplayName("Condition")]
        [Required(ErrorMessage = "Condition required")]
        public string Condition { get; set; }

        [DisplayName("Formula")]
        [Required(ErrorMessage = "Formula required")]
        public string Formula { get; set; }

        [DisplayName("Flag Process")]
        [Required(ErrorMessage = "Flag Process required")]
        public bool FlagProcess { get; set; }

        public virtual PY_VariableComponent PY_VariableComponent { get; set; }
    }
}
