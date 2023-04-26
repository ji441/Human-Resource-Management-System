using Interview.AppCore.Contract.Repositories;
using Interview.AppCore.Entities;
using Interview.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Repositories
{
    public class InterviewFeedbackRepository : BaseRepository<InterviewFeedback>, IInterviewFeedbackRepository
    {
        public InterviewFeedbackRepository(InterviewDbContext context):base(context)
            {}
    }
}
