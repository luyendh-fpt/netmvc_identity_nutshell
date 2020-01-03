﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebApplication11.App_Start;
using WebApplication11.Controllers;
using WebApplication11.Models;

[assembly: OwinStartup(typeof(WebApplication11.Startup))]
namespace WebApplication11
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
                //    Provider = new CookieAuthenticationProvider
                //    {
                //        // Enables the application to validate the security stamp when the user logs in.
                //        // This is a security feature which is used when you change a password or add an external login to your account.  
                //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                //            validateInterval: TimeSpan.FromMinutes(30),
                //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                //    }
            });
        }
    }
}