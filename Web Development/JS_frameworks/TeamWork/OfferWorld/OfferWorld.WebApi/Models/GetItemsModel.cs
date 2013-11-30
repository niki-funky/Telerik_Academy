﻿using OfferWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferWorld.WebApi.Models
{
    public class GetItemsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string AdInfo { get; set; }

        public string User { get; set; }

        public string Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public IEnumerable<PictureModel> Pictures { get; set; }
    }
}