using Interview.AppCore.Contract.Repositories;
using Interview.AppCore.Contract.Services;
using Interview.AppCore.Entities;
using Interview.AppCore.Models;
using Interview.Infrastructure.Helpers;
using RecCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Services
{
    public class InterviewRecordService : IInterviewRecordService
    {
        private readonly IInterviewRecordRepository interviewRecordRepository;
        public InterviewRecordService(IInterviewRecordRepository _ir)
        {
            interviewRecordRepository= _ir;
        }

        public async Task<int> AddInterviewRecordAsync(InterviewRecordRequestModel model)
        {
            InterviewRecord interviewRecord = new InterviewRecord();
            if(model != null)
            {
                interviewRecord.InterviewId = model.InterviewId;
                interviewRecord.InterviewerId=model.InterviewerId;
                interviewRecord.InterviewRound = model.InterviewRound;
                interviewRecord.RecruiterId = model.RecruiterId;
                interviewRecord.InterviewTypeCode= model.InterviewTypeCode;
                interviewRecord.FeedbackId= model.FeedbackId;
                interviewRecord.ScheduledOn = model.ScheduledOn;
                interviewRecord.Recruiter = model.Recruiter;
                interviewRecord.InterviewType = model.InterviewType;
                interviewRecord.Interviewer = model.Interviewer;
                interviewRecord.InterviewFeedback = model.Interviewfeedback;
                interviewRecord.SubmissionId = model.SubmissionId;
                
            }
            return await interviewRecordRepository.InsertAsync(interviewRecord);
        }

        public async Task<int> DeleteInterviewRecordAsync(int id)
        {
            return await interviewRecordRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewRecordResponseModel>> GetAllInterviewRecordsAsync()
        {
            var records = await interviewRecordRepository.GetAllAsync();
            var response = records.Select(x => x.ToInterviewRecordResponseModel());
            return response;
        }

        public async Task<InterviewRecordResponseModel> GetInterviewRecordByIdAsync(int id)
        {
            var record = await interviewRecordRepository.GetByIdAsync(id);
            if(record != null)
            {
                var response = record.ToInterviewRecordResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("interview record",id);
            }
        }

        public async Task<int> UpdateInterviewRecordAsync(InterviewRecordRequestModel model)
        {
            var existingInterviewRecord = await interviewRecordRepository.GetAllrelated(x => model.InterviewId == x.InterviewId);
            if (existingInterviewRecord == null) {
                throw new Exception("Interview Record does not exist");

            }
            InterviewRecord record = new InterviewRecord();
            if(model != null)
            {
                record.InterviewId = model.InterviewId;
                record.RecruiterId= model.RecruiterId;
                record.InterviewTypeCode= model.InterviewTypeCode;
                record.InterviewType = model.InterviewType;
                record.InterviewRound= model.InterviewRound;
                record.ScheduledOn= model.ScheduledOn;
                record.InterviewerId = model.InterviewerId;
                record.Interviewer = model.Interviewer;
                record.FeedbackId= model.FeedbackId;
                record.SubmissionId= model.SubmissionId;
                return await interviewRecordRepository.UpdateAsync(record);
            }
            else
            {
                return -1;
            }

        }
    }
}
