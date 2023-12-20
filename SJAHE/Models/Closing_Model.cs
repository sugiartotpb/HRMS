using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJAHE.Models
{
    public class Closing_Model
    {
        [Required(ErrorMessage = "Month required")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Year required")]
        public int Year { get; set; }
    }
}