using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        public string Poster { get; set; }

        public string CategoryName { get; set; }

        public string DetailsUrl { get; set; }
    }
}