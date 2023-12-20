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
    [Table("PA_EmployeeOccupation")]
    public class PA_EmployeeOccupation
    {
        [Key]
        public string EmployeeNo { get; set; }

        [DisplayName("AbsenteeismNo")]
        [Required(ErrorMessage = "Absenteeism no required")]
        public string AbsenteeismNo { get; set; }

        [DisplayName("Join Date")]
        [Required(ErrorMessage = "Join date required")]
        public DateTime JoinDate { get; set; }

        [DisplayName("Employment Status")]
        public string EmploymentStatus { get; set; }

        [DisplayName("Probation EndDate")]
        public DateTime? ProbationEndDate { get; set; }

        [DisplayName("Start Contract Date")]
        public DateTime? StartContractDate { get; set; }
        public DateTime? EndContractDate { get; set; }
        public int? ContractSequenceNo { get; set; }
        public string FirstJoinEmployeeNo { get; set; }
        public DateTime? ResignDate { get; set; }
        public string ResignCode { get; set; }
        public string ResignRemark { get; set; }
        public string GradeCode { get; set; }
        public string GradeCodePrevious { get; set; }
        public DateTime? GradeCodeChangeDate { get; set; }
        public string PositionCode { get; set; }
        public string PositionCodePrevious { get; set; }
        public DateTime? PositionCodeChangeDate { get; set; }
        public string RankCode { get; set; }
        public string RankCodePrevious { get; set; }
        public DateTime? RankCodeChangeDate { get; set; }
        public string Level1Code { get; set; }
        public string Level2Code { get; set; }
        public string Level3Code { get; set; }
        public string Level4Code { get; set; }
        public string Level5Code { get; set; }
        public string Level1CodePrevious { get; set; }
        public DateTime? Level1CodeChangeDate { get; set; }
        public string Level2CodePrevious { get; set; }
        public DateTime? Level2CodeChangeDate { get; set; }
        public string Level3CodePrevious { get; set; }
        public DateTime? Level3CodeChangeDate { get; set; }
        public string Level4CodePrevious { get; set; }
        public DateTime? Level4CodeChangeDate { get; set; }
        public string Level5CodePrevious { get; set; }
        public DateTime? Level5CodeChangeDate { get; set; }
        public string WorkNatureCode { get; set; }
        public string WorkGroupCode { get; set; }
        public string WorkGroupAuthorizeCode { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
