﻿using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}