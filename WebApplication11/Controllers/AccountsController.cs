using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class AccountsController : Controller
    {
        private MyDbContext dbContext = new MyDbContext();
        private UserManager<Account> userManager;

        public AccountsController()
        {
            UserStore<Account> userStore = new UserStore<Account>(dbContext);
            userManager = new UserManager<Account>(userStore);
        }

        public ActionResult Index(string[] ids, string[] roleNames)
        {
            foreach (var id in ids)
            {
                userManager.AddToRoles(id, roleNames);
            }
            Account acc = dbContext.Users.Find("");
            return View("Register");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account account = userManager.Find(username, password);
            if (account == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = userManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }


        // GET: Accounts
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(string username, string password)
        {
            var account = new Account()
            {
                UserName = username,
                FirstName =  "Xuan Hung",
                LastName = "Dao",
                Avatar = "avatar",
                Birthday = DateTime.Now,
                CreatedAt = DateTime.Now
            };
            IdentityResult result = userManager.Create(account, password);
            userManager.AddToRole(account.Id, "User");
            return View("Register");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}