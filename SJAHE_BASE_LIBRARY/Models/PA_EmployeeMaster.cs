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
    [Table("PA_EmployeeMaster")]
    public class PA_EmployeeMaster
    {
        [Key]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [DisplayName("Family Name")]
        public string FamilyName { get; set; }
        public string NickName { get; set; }

        [Required(ErrorMessage = "Birth Place Required")]
        [DisplayName("Birth Place")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "Birth Date Required")]
        [DisplayName("Birth Date")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Marital Status Actual Required")]
        [DisplayName("Marital Status Actual")]
        public string MaritalStatusActual { get; set; }

        public string BloodType { get; set; }

        [Required(ErrorMessage = "Religion Required")]
        [DisplayName("Religion")]
        public string ReligionCode { get; set; }

        [Required(ErrorMessage = "Nationality Required")]
        [DisplayName("Nationality")]
        public string NationalityCode { get; set; }
        public string PersonalMobilePhone { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string CompanyEmailAddress { get; set; }
        public string FlagExpatriate { get; set; }
        public string ExpatriateRegisterNo { get; set; }
        public string ExpatriateRegisterStartDate { get; set; }
        public string ExpatriateRegisterEndDate { get; set; }
        public string ActiveStatus { get; set; }
        public string Note { get; set; }
        public bool FlagHasPrepared { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
