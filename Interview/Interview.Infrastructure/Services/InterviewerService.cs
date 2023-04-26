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
    public class InterviewerService : IInterviewerService
    {
        private readonly IInterviewerRepository _interviewerRepository;
        public InterviewerService(IInterviewerRepository interviewerRepository)
        {
            _interviewerRepository=interviewerRepository;
        }

        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await _interviewerRepository.GetByIdAsync(model.InterviewerId);
            if (existingInterviewer != null)
            {
                throw new Exception("interviewer already exist");
            }
            Interviewer interviewer = new Interviewer();
            if (model != null)
            {
                interviewer.InterviewerId = model.InterviewerId;
                interviewer.FirstName=model.FirstName;
                interviewer.LastName=model.LastName;
                interviewer.EmployeeId = model.EmployeeId;
            }
            return await _interviewerRepository.InsertAsync(interviewer);

        }

        public async Task<int> DeleteInterviewerAsync(int id)
        {
            return await _interviewerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewersAsync()
        {
            var interviewers = await _interviewerRepository.GetAllAsync();
            var response = interviewers.Select(x => x.ToInterviewerResponseModel());
            return response;
        }

        public async Task<InterviewerResponseModel> GetInterviewerById(int id)
        {
            var interviewer = await _interviewerRepository.GetByIdAsync(id);
            if(interviewer != null)
            {
                var response = interviewer.ToInterviewerResponseModel();
                return response;
                
            }
            else
            {
                throw new NotFoundException("Interviewer",id);
            }
        }

        public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await _interviewerRepository.GetByIdAsync(model.InterviewerId);
            if(existingInterviewer == null)
            {
                throw new Exception("Interviewer does not exist");
            }
            Interviewer interviewer = new Interviewer();
            if(model != null)
            {
                interviewer.InterviewerId = model.InterviewerId;
                interviewer.FirstName=model.FirstName;
                interviewer.LastName=model.LastName;
                interviewer.EmployeeId = model.EmployeeId;
                return await _interviewerRepository.UpdateAsync(interviewer);

            }
            else
            {
                return -1;
            }

        }
    }
}
