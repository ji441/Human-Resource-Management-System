using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Models
{
    public class InterviewTypeResponseModel
    {
        public int LookupCode { get; set; }
        [StringLength(128, ErrorMessage = "Max 128 characters")]
        public string? Description { get; set; }
    }
}
