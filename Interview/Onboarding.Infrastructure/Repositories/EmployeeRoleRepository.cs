﻿using Onboarding.Core.Contracts.Repositories;
using Onboarding.Core.Entities;
using Onboarding.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Infrastructure.Repositories
{
    public class EmployeeRoleRepository : BaseRepository<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
