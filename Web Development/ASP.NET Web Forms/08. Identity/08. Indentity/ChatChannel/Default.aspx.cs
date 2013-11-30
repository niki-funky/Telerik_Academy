using System;
using System.Linq;
using System.Web.UI;
using ChatChannel.Models;

namespace ChatChannel
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ChatEntities context = new ChatEntities())
            {
                //SELECT FirstName, LastName, Content, PostDate
                //FROM Messages, UserDetails
                //where Messages.UserId = UserDetails.UserId

                var messages = from usr in context.UserDetails
                               from msg in context.Messages
                               where usr.UserId == msg.UserId
                               select new MessageModel()
                               {
                                   UserName = usr.FirstName + " " + usr.LastName + ": ",
                                   Content = msg.Content,
                                   PostDate = msg.PostDate

                               };
                this.lvMessages.DataSource = messages.ToList();
                this.DataBind();
            }
        }
    }
}