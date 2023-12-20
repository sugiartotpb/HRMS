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
    [Table("SC_User")]
    public class SC_User
    {
        [Key]
        public int UserID { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string UserFullName { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserEmailAddress { get; set; }

        [DisplayName("Contact No")]
        [Required(ErrorMessage = "Contact no is required")]
        public string UserContactNo { get; set; }

        [DisplayName("UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }
        
        [DisplayName("Image")]
        public string UserImageUrl { get; set; }
        public bool UserStatus { get; set; }
    }
}
