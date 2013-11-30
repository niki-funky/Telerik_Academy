using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.Models
{
    public class ApplicationUser : User
    {
        public string Email { get; set; }

        public string ProfilePicture { get; set; }
    }
}