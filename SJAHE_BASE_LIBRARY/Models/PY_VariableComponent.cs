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
    [Table("PY_VariableComponent")]
    public class PY_VariableComponent
    {
        [Key]
        public int VariableComponentID { get; set; }

        [DisplayName("Variable Component Name")]
        [Required(ErrorMessage = "Variable component name is required")]
        public string VariableComponentName { get; set; }

        public string V01 { get; set; }
        public string V02 { get; set; }
        public string V03 { get; set; }
        public int VariableComponentCreatedBy { get; set; }
        public DateTime VariableComponentDateCreatedOn { get; set; }
    }
}
