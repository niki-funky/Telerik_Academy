using System;
using System.Linq;
using System.Runtime.Serialization;

namespace BloggingSystem.WebApi.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMemberAttribute(Name = "username")]
        public string Username { get; set; }
        [DataMemberAttribute(Name = "displayname")]
        public string Displayname { get; set; }
        [DataMemberAttribute(Name = "authCode")]
        public string AuthCode { get; set; }
    }
}