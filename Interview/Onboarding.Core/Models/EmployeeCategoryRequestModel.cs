﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboarding.Core.Models
{
    public class EmployeeCategoryRequestModel
    {
        public int LookupCode { get; set; }
        public string? Description { get; set; }
    }
}
