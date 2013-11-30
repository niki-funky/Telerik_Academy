using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using ChatChannel.Models;
using Error_Handler_Control;

namespace ChatChannel.Moderator
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
    }
}