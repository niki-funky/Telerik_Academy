using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatChannel.Models
{
    public class MessageModel
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public System.DateTime PostDate { get; set; }
        public string UserId { get; set; }
    }
}