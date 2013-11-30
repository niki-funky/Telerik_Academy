using System;
using System.Linq;
using ChatChannel.Models;
using Error_Handler_Control;

namespace ChatChannel.Admin
{
    public partial class EditDeleteMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public IQueryable<Message> grvMessages_GetData()
        {
            ChatEntities context = new ChatEntities();
            return context.Messages.OrderByDescending(m => m.PostDate);
        }

        public void grvMessages_DeleteItem(int messageId)
        {
            ChatEntities context = new ChatEntities();
            Message message = context.Messages.
                FirstOrDefault(q => q.MessageId == messageId);
            try
            {
                context.Messages.Remove(message);
                context.SaveChanges();
                this.grvMessages.PageIndex = 0;
                ErrorSuccessNotifier.AddInfoMessage("Message successfully deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}