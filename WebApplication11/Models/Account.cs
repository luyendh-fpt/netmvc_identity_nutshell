﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication11.Models
{
    public class Account: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}