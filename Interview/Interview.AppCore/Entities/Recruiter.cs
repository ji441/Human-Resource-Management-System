using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Entities
{
    public class Recruiter
    {
        public int RecruiterId { get; set; }
        [Required(ErrorMessage ="Required")]
        [Column(TypeName = "nvarchar(128)")]
        public string? FistName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "nvarchar(128)")]

        public string? LastName { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
