using System;
using System.Linq;
using ChatChannel.Models;
using Error_Handler_Control;

namespace ChatChannel.Chatter
{
    public partial class CreateMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        protected void lnbSaveMessage_Click(object sender, EventArgs e)
        {
            using (ChatEntities context = new ChatEntities())
            {
                Message message = new Message();
                context.Messages.Add(message);

                message.Content = this.tbMessageContent.Text;
                message.PostDate = DateTime.Now;

                string firstName = (User.Identity.Name.Split(' '))[0];
                string lastName = (User.Identity.Name.Split(' '))[1];

                message.UserId = context.UserDetails.
                    Where(name => name.FirstName == firstName && name.LastName == lastName).
                    Select(x => x.UserId).FirstOrDefault();

                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Message created.");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        public void lnbReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
        }

    }
}