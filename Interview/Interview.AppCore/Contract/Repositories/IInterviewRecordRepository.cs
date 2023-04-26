using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Interview.AppCore.Entities;

namespace Interview.AppCore.Contract.Repositories
{
    public interface IInterviewRecordRepository : IBaseRepository<InterviewRecord>
    {
        public Task<IEnumerable<InterviewRecord>> GetAllrelated(Expression<Func<InterviewRecord, bool>> filter);
    }
    
}
