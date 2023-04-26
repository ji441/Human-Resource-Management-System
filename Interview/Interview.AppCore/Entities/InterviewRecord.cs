using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Entities
{
    public class InterviewRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterviewId { get; set; }
        public Recruiter? Recruiter { get; set; }
        public int RecruiterId { get; set; }
        //submission to be done
        public int SubmissionId { get; set; }
        public int InterviewTypeCode { get; set; }
        public InterviewType? InterviewType { get; set; }
        public int InterviewRound { get; set; }
        public DateTime ScheduledOn { get; set; }
        public Interviewer? Interviewer { get; set; }
        public int InterviewerId { get; set; }
        public InterviewFeedback? InterviewFeedback { get; set; }
        public int FeedbackId { get; set; }
    }
}
