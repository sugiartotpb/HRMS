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
    [Table("PA_Position")]
    public class PA_Position
    {
        [Key]
        public int PositionID { get; set; }

        [DisplayName("Position Code")]
        [Required(ErrorMessage = "Position code required")]
        public string PositionCode { get; set; }

        [DisplayName("Position Name")]
        [Required(ErrorMessage = "Position name required")]
        public string PositionName { get; set; }

        public int Hierarchy { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
