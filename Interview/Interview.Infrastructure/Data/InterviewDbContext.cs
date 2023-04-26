using Interview.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Infrastructure.Data
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions options) : base(options) { }


        public DbSet<InterviewRecord> InterviewRecords { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedbacks { get; set;}
        public DbSet<InterviewType> InterviewTypes { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
    }
}
