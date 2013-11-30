using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class TagModel
    {
        [DataMemberAttribute(Name = "id")]
        public int Id { get; set; }
        [DataMemberAttribute(Name = "name")]
        public string Name { get; set; }
        [DataMemberAttribute(Name = "posts")]
        public int Posts { get; set; }
    }
}