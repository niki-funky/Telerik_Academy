using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LizardmanCinemas.Models;
using System.Linq.Expressions;

namespace LizardmanCinemas.ViewModels
{
    public class MovieShortViewModel
    {
        public static Expression<Func<Movie, MovieShortViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieShortViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Poster = movie.Poster,
                    Year = movie.Year
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }

        public int Year { get; set; }       
    }
}