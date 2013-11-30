using System;
using System.Linq;

namespace BloggingSystem.WebApi.Models
{
    public class LoggedUserModel
    {
        public string SessionKey { get; set; }

        public string Displayname { get; set; }
    }
}