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
    [Table("PA_Level")]
    public class PA_Level
    {
        [Key]
        public int LevelID { get; set; }

        [DisplayName("Level Code")]
        [Required(ErrorMessage = "Level code required")]
        public string LevelCode { get; set; }

        [DisplayName("Level Name")]
        [Required(ErrorMessage = "Level name required")]
        public string LevelName { get; set; }

        [DisplayName("Level Type")]
        [Required(ErrorMessage = "Level type required")]
        public int LevelTypeID { get; set; }

        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual PA_LevelType PA_LevelType { get; set; }
    }
}
