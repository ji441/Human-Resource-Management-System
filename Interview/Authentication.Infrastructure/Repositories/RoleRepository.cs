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
    public class RoleRepository : IBaseRepository<Role> , IRoleRepository

    {
        protected readonly AuthenticationDbContext dbContext;
        public RoleRepository(AuthenticationDbContext dbContext)
        {
            this.dbContext=dbContext;
        }  

        public async Task<int> DeleteAsync(int id)
        {
            using(IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Delete From Roles Where RoleId = @RoleId", new {RoleId = id});
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using(IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QueryAsync<Role>("Select * From Roles");
            }
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            using(IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.QuerySingleOrDefaultAsync<Role>("Select * From Roles Where RoleId = @RoleId", new { RoleId = id });
            }
        }

        public async Task<int> InsertAsync(Role entity)
        {
            using(IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Insert Into Roles Values(@RoleId,@Name,@Description)", entity);
            }
        }

        public async Task<int> UpdateAsync(Role entity)
        {
            using(IDbConnection conn = dbContext.GetConnection())
            {
                return await conn.ExecuteAsync("Update Roles set Name = @Name,Description = @Description Where RoleId = @RoleId", entity);
            }
        }
    }
}
