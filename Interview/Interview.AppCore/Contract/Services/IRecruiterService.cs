using Interview.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.AppCore.Contract.Services
{
    public interface IRecruiterService
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync();

    }
}
