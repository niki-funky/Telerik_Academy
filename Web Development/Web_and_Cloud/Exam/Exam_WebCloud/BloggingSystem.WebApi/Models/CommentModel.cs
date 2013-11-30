using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class CommentModel
    {
        [DataMemberAttribute(Name = "text")]
        public string Text { get; set; }
        [DataMemberAttribute(Name = "postDate")]
        public DateTime PostDate { get; set; }
        [DataMemberAttribute(Name = "commentedBy")]
        public string CommentedBy { get; set; }
    }
}