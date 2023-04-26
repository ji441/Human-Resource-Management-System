using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Models
{
    public class InterviewerResponseModel
    {
        public int InterviewerId { get; set; }
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        [Required(ErrorMessage = "Required")]
        public string? FirstName { get; set; }
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        [Required(ErrorMessage = "Required")]
        public string? LastName { get; set; }
        public int? EmployeeId { get; set; }
    }
}
