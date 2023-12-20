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
    [Table("AP_ApplicationModule")]
    public class AP_ApplicationModule
    {
        [Key]
        public int ApplicationModuleID { get; set; }

        [DisplayName("Application Module Name")]
        [Required(ErrorMessage = "Application module name required")]
        public string ApplicationModuleName { get; set; }

        public int ApplicationModuleCreatedBy { get; set; }
        public DateTime ApplicationModuleCreatedOn { get; set; }
        public bool ApplicationModuleStatus { get; set; }

        public List<AP_Menu> AP_Menu { get; set; }
    }
}
