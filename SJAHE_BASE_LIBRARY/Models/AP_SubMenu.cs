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
    [Table("AP_SubMenu")]
    public class AP_SubMenu
    {
        [Key]
        public int SubMenuID { get; set; }

        [DisplayName("Menu Name")]
        [Required(ErrorMessage = "Menu name required")]
        public int MenuID { get; set; }

        [DisplayName("Sub Menu Name")]
        [Required(ErrorMessage = "Sub Menu name required")]
        public string SubMenuName { get; set; }

        [DisplayName("Sequence")]
        [Required(ErrorMessage = "Sequence required")]
        public int Sequence { get; set; }
        public int SubMenuCreatedBy { get; set; }
        public DateTime SubMenuCreatedOn { get; set; }
        public bool SubMenuStatus { get; set; }

        public virtual AP_Menu AP_Menu { get; set; }
        public List<AP_SubChildMenu> AP_SubChildMenu { get; set; }
    }
}
