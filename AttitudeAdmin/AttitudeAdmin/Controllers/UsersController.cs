using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Attitude.Business;
using Attitude.Shared.Enums;
using Attitude.Shared.Extensions;
using AttitudeAdmin.DALRepository;
using AttitudeAdmin.DBContext;
using AttitudeAdmin.DBContext.Entities;
using AttitudeAdmin.Extensions;
using AttitudeAdmin.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PagedList;

namespace AttitudeAdmin.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        readonly IUserRepository<ApplicationUser> _repository = new UserRepository<ApplicationUser>();
        const int PageSize = 10;
        private ApplicationUserManager _userManager;
        private ApplicationUserRoleManager ApplicationUserRoleManager = new ApplicationUserRoleManager();

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

        public ActionResult Index(string currentFilter, int? page)
        {
            try
            {
                var users = _repository.Get().OrderBy(q => q.UserName);
                var pageNumber = (page ?? 1);
                return View(users.ToPagedList(pageNumber, PageSize));
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult Details(string id)
        {
            CreateRoleViewBag();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = GetUserById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        private ApplicationUser GetUserById(string id)
        {
            return _repository.Get(q => q.Id == id).SingleOrDefault();
        }

        public ActionResult Create()
        {
            CreateRoleViewBag();
            return View();
        }

        private void CreateRoleViewBag()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem()
            {
                Text = "SuperAdmin",
                Value = "1"
            });

            listItems.Add(new SelectListItem()
            {
                Text = "SystemAdmin",
                Value = "2"
            });
            ViewBag.Roles = listItems;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model)
        {
            try
            {
                CreateRoleViewBag();

                if (ModelState.IsValid)
                {
                    var applicationUser = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        PasswordHash = model.Password,
                        SecondaryPassword = model.SecondaryPassword.CreateMD5(),
                    };

                    var result = UserManager.Create(applicationUser, applicationUser.PasswordHash);
                    if (result.Succeeded)
                    {
                        var resultFind = UserManager.FindByName(model.UserName);
                        ApplicationUserRoleManager.Create(resultFind.Id, roleId: (model.RoleId == (int)RoleEnums.SuperAdmin ? "1" : "2"));
                        return RedirectToAction("Index");
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }

        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = GetUserById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            CreateRoleViewBag();

            return View(new EditViewModel()
            {
                UserName = applicationUser.UserName,
                Id = applicationUser.Id,
                RoleId = int.Parse(applicationUser.Roles.First().RoleId)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,RoleId")] EditViewModel applicationUser)
        {
            try
            {
                CreateRoleViewBag();

                if (ModelState.IsValid)
                {
                    var user = UserManager.FindByIdAsync(applicationUser.Id);
                    if (user.GetAwaiter().IsCompleted)
                    {
                        user.Result.UserName = applicationUser.UserName;
                        user.Result.Roles.Clear();
                        UserManager.Update(user.Result);

                        ApplicationUserRoleManager.Create(applicationUser.Id, roleId: (applicationUser.RoleId == (int)RoleEnums.SuperAdmin ? "1" : "2"));

                        return RedirectToAction("Index");
                    }
                }

                return View(applicationUser);
            }
            catch (Exception e)
            {
                LogHelper.Error(this, e);
                return View("Error");
            }
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = GetUserById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var applicationUser = GetUserById(id);
            _repository.Delete(applicationUser);
            return RedirectToAction("Index");
        }
    }
}
