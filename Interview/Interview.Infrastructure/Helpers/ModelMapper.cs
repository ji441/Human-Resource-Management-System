using Interview.AppCore.Entities;
using Interview.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Helpers
{
    public static class ModelMapper
    {
        //convert object to our response model
        public static InterviewRecordResponseModel ToInterviewRecordResponseModel(this InterviewRecord interviewRecord)
        {
            return new InterviewRecordResponseModel
            {
                InterviewId = interviewRecord.InterviewId,
                RecruiterId = interviewRecord.RecruiterId,
                InterviewTypeCode = interviewRecord.InterviewTypeCode,
                InterviewRound = interviewRecord.InterviewRound,
                ScheduledOn = interviewRecord.ScheduledOn,
                InterviewerId = interviewRecord.InterviewerId,
                FeedbackId = interviewRecord.FeedbackId,
                SubmissionId= interviewRecord.SubmissionId,


            };
        }
        public static InterviewerResponseModel ToInterviewerResponseModel(this Interviewer interviewer)
        {
            return new InterviewerResponseModel
            {
                InterviewerId = interviewer.InterviewerId,
                FirstName = interviewer.FirstName,
                LastName = interviewer.LastName,
                EmployeeId = interviewer.EmployeeId
            };
        }
        public static InterviewFeedbakResponseModel ToInterviewFeedbackResponseModel(this InterviewFeedback interviewFeedback)
        {
            return new InterviewFeedbakResponseModel
            {
                InterviewFeedBackId = interviewFeedback.InterviewFeedbackId,
                Rating = interviewFeedback.Rating,
                Comment = interviewFeedback.Comment
            };
        }
        public static InterviewTypeResponseModel ToInterviewTypeResponseModel(this InterviewType interviewType)
        {
            return new InterviewTypeResponseModel
            {
                LookupCode = interviewType.LookupCode,
                Description = interviewType.Description
            };
        }
        public static RecruiterResponseModel ToRecruiterResponseModel(this Recruiter recruiter)
        {
            return new RecruiterResponseModel
            {
                RecruiterId = recruiter.RecruiterId,
                FirstName = recruiter.FistName,
                LastName = recruiter.LastName,
                EmployeeId = recruiter.EmployeeId
            };
        }
        //convert model to object
        public static InterviewFeedback Toentity(this InterviewFeedbackRequestModel model )
        {
            return new InterviewFeedback
            {
                InterviewFeedbackId = model.InterviewFeedBackId,
                Rating= model.Rating,
                Comment = model.Comment,


            };
        }
        public static InterviewType Toentity(this InterviewTypeRequestModel model)
        {
            return new InterviewType
            {
                LookupCode = model.LookupCode,
                Description = model.Description,
            };
        }
        public static Recruiter Toentity(this RecruiterRequestModel model)
        {
            return new Recruiter
            {
                RecruiterId= model.RecruiterId,
                FistName=model.FirstName,
                LastName=model.LastName,
                EmployeeId= model.EmployeeId
            };
        }
    }
}
