using System;
using System.Linq;
using ChatChannel.Models;
using Error_Handler_Control;

namespace ChatChannel.Moderator
{
    public partial class EditMessage : System.Web.UI.Page
    {
        bool isNewMessage = false;
        private int messageId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.messageId =
                Convert.ToInt32(Request.Params["messageId"]);
            isNewMessage = (this.messageId == 0);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewMessage)
            {
                using (ChatEntities context = new ChatEntities())
                {
                    Message message = context.Messages.Find(messageId);
                    this.tbMessageContent.Text = message.Content;
                }
            }
        }

        protected void lnbSaveMessage_Click(object sender, EventArgs e)
        {
            using (ChatEntities context = new ChatEntities())
            {
                Message message;
                if (isNewMessage)
                {
                    message = new Message();
                    context.Messages.Add(message);
                }
                else
                {
                    message = context.Messages.Find(this.messageId);
                }

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
                    ErrorSuccessNotifier.AddInfoMessage("Message " +
                        (this.isNewMessage ? "created." : "edited."));
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        public void lnbReturn_Click(object sender, EventArgs e)
        {
                Response.Redirect("EditMessages.aspx", false);
        }

    }
}