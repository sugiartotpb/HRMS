using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJAHE.Models
{
    public class Menu_User_Role_Model
    {
        public int MenuUserRoleID { get; set; }
        public int UserRoleID { get; set; }
        public int ApplicationModuleID { get; set; }
        public string ApplicationModuleName { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public int SubChildMenuID { get; set; }
        public string SubChildMenuName { get; set; }
        public string SubChildUrl { get; set; }
    }
}