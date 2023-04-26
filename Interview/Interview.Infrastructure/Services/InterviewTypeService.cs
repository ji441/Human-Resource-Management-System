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
    public class InterviewTypeService : IInterviewTypeService
    {
        private readonly IInterviewTypeRepository _typerepo;
        public InterviewTypeService(IInterviewTypeRepository typerepo) {
            _typerepo= typerepo;
        }
        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingType = await _typerepo.GetByIdAsync(model.LookupCode);
            if (existingType != null)
            {
                throw new Exception("type already exist");
            }
            InterviewType type = new InterviewType();
            if(model != null)
            {
                type = model.Toentity();
                return await _typerepo.InsertAsync(type);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteInterviewTypeAsync(int id)
        {
            return await _typerepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync()
        {
            var types = await _typerepo.GetAllAsync();
            var response = types.Select(x => x.ToInterviewTypeResponseModel());
            return response;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var existingtype = await _typerepo.GetByIdAsync(id);
            if(existingtype != null)
            {
                return existingtype.ToInterviewTypeResponseModel();
            }
            else
            {
                throw new Exception("type is not found");
            }
        }

        public async Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingtype = await _typerepo.GetByIdAsync(model.LookupCode);
            if(existingtype == null)
            {
                throw new Exception("type is not found");
            }
            InterviewType type = new InterviewType();
            if(model != null)
            {
                type = model.Toentity();
                return await _typerepo.UpdateAsync(type);
            }
            else
            { return -1; }
        }
    }
}
