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
    public class InterviewerRepository : BaseRepository<Interviewer>, IInterviewerRepository
    {
        public InterviewerRepository(InterviewDbContext context) : base(context) { }
    }
    
}
