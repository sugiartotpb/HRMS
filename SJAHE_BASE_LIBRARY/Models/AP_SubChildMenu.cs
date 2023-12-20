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
    [Table("AP_SubChildMenu")]
    public class AP_SubChildMenu
    {
        [Key]
        public int SubChildMenuID { get; set; }

        [DisplayName("Sub Menu Name")]
        [Required(ErrorMessage = "Sub Menu name required")]
        public int SubMenuID { get; set; }

        [DisplayName("Sub Last Menu Name")]
        [Required(ErrorMessage = "Sub last Menu name required")]
        public string SubChildMenuName { get; set; }

        [DisplayName("Url")]
        [Required(ErrorMessage = "Url required")]
        public string SubChildUrl { get; set; }
        public int SubChildMenuCreatedBy { get; set; }
        public DateTime SubChildMenuCreatedOn { get; set; }
        public bool SubChildMenuStatus { get; set; }

        public virtual AP_SubMenu AP_SubMenu { get; set; }
    }
}
