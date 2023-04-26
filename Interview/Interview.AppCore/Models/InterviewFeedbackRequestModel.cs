using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Models
{
    public class InterviewFeedbackRequestModel
    {
        public int InterviewFeedBackId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
