using Interview.AppCore.Contract.Repositories;
using Interview.AppCore.Contract.Services;
using Interview.AppCore.Entities;
using Interview.AppCore.Models;
using Interview.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly IRecruiterRepository _rrepo;
        public RecruiterService(IRecruiterRepository rrepo)
        {
            _rrepo = rrepo;
        }
        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await _rrepo.GetByIdAsync(model.RecruiterId);
            if (existingRecruiter != null) {
                throw new Exception("Already exists");
            }
            Recruiter recruiter = new Recruiter();
            if(model != null)
            {
                recruiter = model.Toentity();
                return await _rrepo.InsertAsync(recruiter);
            }
            else
            {
                return -1;
            }

        }

        public Task<int> DeleteRecruiterAsync(int id)
        {
            return _rrepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync()
        {
            var recruiters = await _rrepo.GetAllAsync();
            var response = recruiters.Select(x => x.ToRecruiterResponseModel());
            return response;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var recruiter = await _rrepo.GetByIdAsync(id);
            if(recruiter != null)
            {
                var response = recruiter.ToRecruiterResponseModel();
                return response;
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public async Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            var existingRecruiter = await _rrepo.GetByIdAsync(model.RecruiterId);
            if(existingRecruiter == null)
            {
                throw new Exception("Recruiter does not exist");
            }
            Recruiter recruiter = new Recruiter();
            if(model != null)
            {
                recruiter = model.Toentity();
                return await _rrepo.UpdateAsync(recruiter);
            }
            else
            {
                return -1;
            }
        }
    }
}
