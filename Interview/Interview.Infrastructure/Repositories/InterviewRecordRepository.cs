using Interview.AppCore.Contract.Repositories;
using Interview.AppCore.Entities;
using Interview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories
{
    public class InterviewRecordRepository : BaseRepository<InterviewRecord>, IInterviewRecordRepository
    {
        public InterviewRecordRepository(InterviewDbContext context) : base(context)
        { }

        public async Task<IEnumerable<InterviewRecord>> GetAllrelated(Expression<Func<InterviewRecord, bool>> filter)
        {
            return await _dbContext.InterviewRecords.Include("Recruiter").Include("InterviewType").Include("Interviewer")
                .Include("InterviewFeedback").Where(filter).ToListAsync();
            
        }
    }
}
