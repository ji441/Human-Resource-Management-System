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
    public class InterviewFeedbakService : IInterviewFeedbackService
    {
        private readonly IInterviewFeedbackRepository _feedbackRepository;
        public InterviewFeedbakService(IInterviewFeedbackRepository feedbackRepository)
        {
            _feedbackRepository=feedbackRepository;
        }

        public async Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var existingFeedback = await _feedbackRepository.GetByIdAsync(model.InterviewFeedBackId);
            if (existingFeedback != null)
            {
                throw new Exception("feedback already exists");
            }
            InterviewFeedback feedback = new InterviewFeedback();
            if( model != null)
            {
                feedback = model.Toentity();
            }
            return await _feedbackRepository.InsertAsync(feedback);
        }

        public async Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            return await _feedbackRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewFeedbakResponseModel>> GetAllInterviewFeedback()
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();
            var response = feedbacks.Select(x=>x.ToInterviewFeedbackResponseModel());
            return response;
        }

        public async Task<InterviewFeedbakResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if(feedback != null)
            {
                var response = feedback.ToInterviewFeedbackResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("feedback",id);
            }
        }

        public async Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var exsistingfeedback = await _feedbackRepository.GetByIdAsync(model.InterviewFeedBackId);
            if(exsistingfeedback == null) 
            {
                throw new Exception("feedback does not exist");
            }
            InterviewFeedback feedback = new InterviewFeedback();
            if(model != null)
            {
                feedback = model.Toentity();
                return await _feedbackRepository.UpdateAsync(feedback);
            }
            else
            {
                return -1;
            }
        }
    }
}
