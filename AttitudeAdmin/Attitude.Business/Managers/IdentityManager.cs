using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attitude.Shared.Entities;
using AttitudeAdmin.DALRepository;
using AttitudeAdmin.DBContext;
using AttitudeAdmin.DBContext.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Attitude.Business
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<AttitudeDbContext>()));
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleManager
    {
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AttitudeDbContext()));

        public IdentityResult Create(string roleName)
        {
            var identitResult = new IdentityResult();
            if (!roleManager.RoleExists(roleName))
            {
                return roleManager.Create(new IdentityRole(roleName));
            }

            return IdentityResult.Success;
        }

        public bool RoleExists(string roleName)
        {
            return roleManager.RoleExists(roleName);
        }
    }

    public class ApplicationUserRoleManager
    {
        public IdentityResult Create(string userId, string roleId)
        {
            IUserRepository<IdentityUserRole> repository = new UserRepository<IdentityUserRole>();
            repository.Add(new IdentityUserRole()
            {
                RoleId = roleId,
                UserId = userId
            });
            return IdentityResult.Success;
        }

        public IdentityResult Remove(string userId)
        {
            IUserRepository<IdentityUserRole> repository = new UserRepository<IdentityUserRole>();
            var userRoles = repository.Get(q => q.UserId == userId);
            if (userRoles.Any())
            {
                foreach (var identityUserRole in userRoles)
                {
                    repository.Delete(identityUserRole);
                }

                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }
    }
}
