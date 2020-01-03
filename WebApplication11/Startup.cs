using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebApplication11.App_Start;
using WebApplication11.Controllers;
using WebApplication11.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication11.Startup))]
namespace WebApplication11
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<MyDbContext>(MyDbContext.Create);
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}