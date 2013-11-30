using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class CreatedPost
    {
        [DataMemberAttribute(Name = "id")]
        public int Id { get; set; }
        [DataMemberAttribute(Name = "title")]
        public string Title { get; set; }
    }
}