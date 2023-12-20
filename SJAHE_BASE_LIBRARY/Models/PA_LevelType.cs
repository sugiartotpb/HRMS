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
    [Table("PA_LevelType")]
    public class PA_LevelType
    {
        [Key]
        public int LevelTypeID { get; set; }

        [DisplayName("Level Type Name")]
        [Required(ErrorMessage = "Level type name required")]
        public string LevelTypeName { get; set; }

        [DisplayName("Level Sequence")]
        [Required(ErrorMessage = "Level sequence required")]
        public int LevelSequence { get; set; }

        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
