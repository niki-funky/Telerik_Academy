using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferWorld.WebApi.Models
{
    public class EditUserModel
    {
        public string Username { get; set; }

        public string AuthCode { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Avatar { get; set; }
    }
}