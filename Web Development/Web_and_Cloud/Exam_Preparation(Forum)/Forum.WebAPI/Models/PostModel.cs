﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class PostModel
    {
        public string Content { get; set; }

        public string PostedBy { get; set; }

        public DateTime PostDate { get; set; }

        public string Rating { get; set; }
    }
}