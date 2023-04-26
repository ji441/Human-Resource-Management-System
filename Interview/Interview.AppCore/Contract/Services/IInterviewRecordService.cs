using Interview.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Contract.Services
{
    public interface IInterviewRecordService
    {
        Task<int> AddInterviewRecordAsync(InterviewRecordRequestModel model);
        Task<int> DeleteInterviewRecordAsync(int id);
        Task<int> UpdateInterviewRecordAsync(InterviewRecordRequestModel model);
        Task<InterviewRecordResponseModel> GetInterviewRecordByIdAsync(int id);
        Task<IEnumerable<InterviewRecordResponseModel>> GetAllInterviewRecordsAsync();
    }
}
