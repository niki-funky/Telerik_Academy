﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class LoggedUserModel
    {
        public string SessionKey { get; set; }

        public string Nickname { get; set; }
    }
}