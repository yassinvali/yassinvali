using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Attitude.Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AttitudeAdmin.Controllers
{
    public class BaseController:Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public string UserId {
            get
            {
                var findByName = UserManager.FindByNameAsync(User.Identity.Name);
                findByName.Wait();
                return findByName.Result.Id;
            }
        }
    }
}