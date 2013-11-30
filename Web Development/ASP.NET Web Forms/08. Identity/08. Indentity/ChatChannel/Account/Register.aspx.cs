using System.Web.Security;
using ChatChannel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ChatChannel.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {            
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string userName = firstName + " " + lastName;
            string password = Password.Text;
            string email = Email.Text;
            bool admin = Admin.Checked;
            bool moderator = Moderator.Checked;

            var manager = new AuthenticationIdentityManager(new IdentityStore());
            User u = new User(userName) 
            { 
                UserName = userName
            };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                using (ChatEntities ce = new ChatEntities())
                {
                    ce.UserDetails.Add(new UserDetail()
                    {
                        UserId = u.Id,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Admin = admin,
                        Moderator = moderator
                    });

                    ce.SaveChanges();
                }
                if (admin)
                {
                    // Add Administrator.
                    if (!Roles.RoleExists("Admin"))
                    {
                        Roles.CreateRole("Admin");
                    }
                    
                    Membership.CreateUser(userName, password, email);
                    Roles.AddUserToRole(userName, "Admin");
                }
                else if (moderator)
                {
                    // Add Moderator
                    if (!Roles.RoleExists("Moderator"))
                    {
                        Roles.CreateRole("Moderator");
                    }

                    Membership.CreateUser(userName, password, email);
                    Roles.AddUserToRole(userName, "Moderator");
                }
                
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}