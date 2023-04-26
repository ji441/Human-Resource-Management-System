﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Data
{
    public class AuthenticationDbContext
    {
        private readonly string connectionString;
        public AuthenticationDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection GetConnection() {
            return new SqlConnection(connectionString);
        }
    }
}
