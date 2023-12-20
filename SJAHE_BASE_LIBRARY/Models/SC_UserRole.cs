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
    [Table("SC_UserRole")]
    public class SC_UserRole
    {
        [Key]
        public int UserRoleID { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [DisplayName("FullName Name")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [DisplayName("Role Name")]
        public int RoleID { get; set; }
        public int UserRoleCreatedBy { get; set; }
        public DateTime UserRoleDateCreatedOn { get; set; }

        [DisplayName("User Role Status")]
        public bool UserRoleStatus { get; set; }

        public virtual SC_Role SC_Role { get; set; }
        public virtual SC_User SC_User { get; set; }
    }
}
