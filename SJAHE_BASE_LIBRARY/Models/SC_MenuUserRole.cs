using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJAHE_BASE_LIBRARY.Models
{
    [Table("SC_MenuUserRole")]
    public class SC_MenuUserRole
    {
        [Key]
        public int MenuUserRoleID { get; set; }
        public int UserRoleID { get; set; }
        public int ApplicationModuleID { get; set; }
        public int MenuID { get; set; }
        public int SubMenuID { get; set; }
        public int SubChildMenuID { get; set; }
        public int MenuUserRoleCreatedBy { get; set; }
        public DateTime MenuUserRoleCreatedOn { get; set; }
        public bool MenuUserRoleStatus { get; set; }

        public virtual SC_UserRole SC_UserRole { get; set; }
        public virtual AP_ApplicationModule AP_ApplicationModule { get; set; }
        public virtual AP_Menu AP_Menu { get; set; }
        public virtual AP_SubMenu AP_SubMenu { get; set; }
        public virtual AP_SubChildMenu AP_SubChildMenu { get; set; }
    }
}
