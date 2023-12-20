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
    [Table("PY_SalaryComponent")]
    public class PY_SalaryComponent
    {
        [Key]
        public int SalaryComponentID { get; set; }

        [Required(ErrorMessage = "Component Name Required")]
        [DisplayName("Component Name")]
        public string SalaryComponentName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
