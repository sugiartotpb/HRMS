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
    [Table("PY_EmployeeFormulaTarifComponent")]
    public class PY_EmployeeFormulaTarifComponent
    {
        [Key]
        public int FormulaTarifComponentID { get; set; }

        [DisplayName("Tarif Component")]
        [Required(ErrorMessage = "Tarif component required")]
        public int TarifComponentID { get; set; }

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

        public virtual PY_TarifComponent PY_TarifComponent { get; set; }
    }
}
