using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class AccountRepository : IBaseRepository<Account>, IAccountRepository
    {
        protected readonly AuthenticationDbContext dbContext;
        public AccountRepository(AuthenticationDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From Accounts Where UserId = @UserId", new { UserId = id });
            }
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<Account>("Select * From Accounts");
            }
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<Account>("Select * From Accounts Where UserId = @UserId", new { UserId = id });
            }
        }

        public async Task<int> InsertAsync(Account entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into Accounts Values(@UserId,@EmployeeId,@Email,@RoleId,@FirstName,@LastName,@HashPassword,@Salt)", entity);
            }
        }

        public async Task<int> UpdateAsync(Account entity)
        {
            using (IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update Accounts set EmployeeId = @EmployeeId,Email = @Email,RoleId = @RoleId,FirstName = @FirstName,LastName = @LastNmae,HashPassword = @HashPassword,Salt=@Salt Where UserId = @UserId", entity);
            }
        }

        

        
    }
}
