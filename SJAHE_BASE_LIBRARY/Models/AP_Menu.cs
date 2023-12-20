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
    [Table("AP_Menu")]
    public class AP_Menu
    {
        [Key]
        public int MenuID { get; set; }

        [DisplayName("Application Module Name")]
        [Required(ErrorMessage = "Application module name required")]
        public int ApplicationModuleID { get; set; }

        [DisplayName("Menu Name")]
        [Required(ErrorMessage = "Menu name required")]
        public string MenuName { get; set; }

        [DisplayName("Sequence")]
        [Required(ErrorMessage = "Sequence required")]
        public int Sequence { get; set; }
        public int MenuCreatedBy { get; set; }
        public DateTime MenuCreatedOn { get; set; }
        public bool MenuStatus { get; set; }

        public virtual AP_ApplicationModule AP_ApplicationModule { get; set; }
        public virtual List<AP_SubMenu> AP_SubMenu { get; set; }
    }
}
