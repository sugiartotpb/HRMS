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
    [Table("SC_Role")]
    public class SC_Role
    {
        [Key]
        public int RoleID { get; set; }

        [DisplayName("Role Name")]
        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }

        public int RoleCreatedBy { get; set; }
        public DateTime RoleDateCreatedOn { get; set; }
    }
}
