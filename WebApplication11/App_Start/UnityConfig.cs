using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using WebApplication11.App_Start;
using WebApplication11.Controllers;
using WebApplication11.Models;

namespace WebApplication11
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IUserStore<Account>, UserStore<Account>>();
            container.RegisterType<UserManager<Account>>();
            container.RegisterType<DbContext, MyDbContext>();
            container.RegisterType<ApplicationUserManager>();
        }
    }
}