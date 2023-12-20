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
    [Table("PY_NonFixedComponent")]
    public class PY_NonFixedComponent
    {
        [Key]
        public int NonFixedComponentID { get; set; }

        [DisplayName("Non Fixed Component Name")]
        [Required(ErrorMessage = "Non Fixed Component Name is required")]
        public string NonFixedComponentName { get; set; }

        public string NF01 { get; set; }
        public string NF02 { get; set; }
        public string NF03 { get; set; }
        public int NonFixedComponentCreatedBy { get; set; }
        public DateTime NonFixedComponentDateCreatedOn { get; set; }
    }
}
