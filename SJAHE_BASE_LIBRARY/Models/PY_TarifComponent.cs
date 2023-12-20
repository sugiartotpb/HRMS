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
    [Table("PY_TarifComponent")]
    public class PY_TarifComponent
    {
        [Key]
        public int TarifComponentID { get; set; }

        [DisplayName("Tarif Component Name")]
        [Required(ErrorMessage = "Tarif component name is required")]
        public string TarifComponentName { get; set; }

        public string TF01 { get; set; }
        public string TF02 { get; set; }
        public string TF03 { get; set; }
        public int TarifComponentCreatedBy { get; set; }
        public DateTime TarifComponentDateCreatedOn { get; set; }
    }
}
