using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttitudeAdmin.DBContext.Entities;
using Dapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Attitude.Business
{
    public class UserManager : BaserUserManger, IUserStore<ApplicationUser>, IUserLoginStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserSecurityStampStore<ApplicationUser>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ApplicationUser user)
        {
            using (var connection=GetConnection())
            {
                await connection.ExecuteAsync("InsertUser",
                    new
                    {
                        Id = Guid.NewGuid(), UserName = user.UserName, Password = user.PasswordHash,
                        SecondaryPassword = user.SecondaryPassword
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            using (var connection = GetConnection())
            {
                var applicationUser = await connection.QueryFirstOrDefaultAsync<ApplicationUser>("GetUserByUsernamePassword",
                    new {userName, password},
                    commandType: CommandType.StoredProcedure);
                return applicationUser;
            }
        }

        public Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }

    public class BaserUserManger
    {
        private static string ConnetionString => ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        public Func<SqlConnection> GetConnection = () => new SqlConnection(ConnetionString);
    }
}
