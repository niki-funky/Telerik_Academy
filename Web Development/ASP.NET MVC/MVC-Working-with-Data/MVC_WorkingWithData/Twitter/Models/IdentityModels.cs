using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    // You can add profile data for the user by adding more properties to your User class, 
    // please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string Avatar { get; set; }
        public string Email { get; set; }
    }
}