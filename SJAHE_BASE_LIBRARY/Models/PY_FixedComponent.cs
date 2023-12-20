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
    [Table("PY_FixedComponent")]
    public class PY_FixedComponent
    {
        [Key]
        public int FixedComponentID { get; set; }

        [DisplayName("Fixed Component Name")]
        [Required(ErrorMessage = "Fixed Component Name is required")]
        public string FixedComponentName { get; set; }

        public string F01 { get; set; }
        public string F02 { get; set; }
        public string F03 { get; set; }
        public int FixedComponentCreatedBy { get; set; }
        public DateTime FixedComponentDateCreatedOn { get; set; }
    }
}
