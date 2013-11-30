using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferWorld.WebApi.Models
{
    public class ItemCreateModel
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string AdInfo { get; set; }

        public string Category { get; set; }

        public string Pictures { get; set; }
    }
}