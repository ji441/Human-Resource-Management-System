using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Entities
{
    public class Interviewer
    {
        public int InterviewerId { get; set; }
        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "nvarchar(128)")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "nvarchar(128)")]
        public string? LastName { get; set; }
        public int? EmployeeId { get; set; }
    }
}
