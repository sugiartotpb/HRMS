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
    [Table("PA_Grade")]
    public class PA_Grade
    {
        [Key]
        public int GradeID { get; set; }

        [DisplayName("Grade Code")]
        [Required(ErrorMessage = "Grade code required")]
        public string GradeCode { get; set; }

        [DisplayName("Grade Name")]
        [Required(ErrorMessage = "Grade name required")]
        public string GradeName { get; set; }
        public int Hierarchy { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
