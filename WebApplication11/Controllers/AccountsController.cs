using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebApplication11.App_Start;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{

    public class AccountsController : Controller
    {
        private MyDbContext _dbContext;

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


        public AccountsController()
        {
        }


        public ActionResult Index(string[] ids, string[] roleNames)
        {
            foreach (var id in ids)
            {
                UserManager.AddToRoles(id, roleNames);
            }
            Account acc = _dbContext.Users.Find("");
            return View("Register");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account account = UserManager.Find(username, password);
            if (account == null)
            {
                return HttpNotFound();
            }
            // success
            var ident = UserManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect("/Home");
        }


        // GET: Accounts
        public ActionResult Register()
        {
            _dbContext.Products.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Store(string username, string password)
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
            IdentityResult result = await UserManager.CreateAsync(account, password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(account.Id, "User");
            }
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