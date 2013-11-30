using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BloggingSystem.Models;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class PostModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMemberAttribute(Name = "title")]
        public string Title { get; set; }
        [DataMemberAttribute(Name = "text")]
        public string Text { get; set; }
        [DataMemberAttribute(Name = "postDate")]
        public DateTime PostDate { get; set; }
        [DataMemberAttribute(Name = "postedBy")]
        public string PostedBy { get; set; }
        [DataMemberAttribute(Name = "tags")]
        public IEnumerable<string> Tags { get; set; }
        [DataMemberAttribute(Name = "comments")]
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}