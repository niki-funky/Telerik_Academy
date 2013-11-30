using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LizardmanCinemas.Models.Attributes;

namespace LizardmanCinemas.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string CategoryName { get; set; }

        [UIHint("_CategoryDropdown")]
        [Required]
        public CategoryVM Category { get; set; }

        public string DirectorName { get; set; }

        [UIHint("_DirectorDropdown")]
        public DirectorVM Director { get; set; }

        [UIHint("_ActorsMultiSelect")]
        public IEnumerable<ActorVM> Actors { get; set; }

        [Required]
        [RangeYearToCurrent(1800)]
        public int Year { get; set; }

        [Range(1, 180)]
        public int Duration { get; set; }

        [UIHint("_UploadPoster")]
        public string Poster { get; set; }

        [UIHint("_CountryDropdown")]
        public string CountryName { get; set; }

        public CountryVM Country { get; set; }

        [UIHint("_ParentsGuideDropdown")]
        public int ParentsGuideId { get; set; }

        [UIHint("_ParentsGuideDropdown")]
        public ParentsGuideVM ParentsGuide { get; set; }

        public string ParentsGuideName { get; set; }

        public static Expression<Func<Movie, MovieVM>> FromMovie
        {
            get
            {
                return m => new MovieVM
                {
                    Id = m.Id,
                    Title = m.Title,
                    Category = new CategoryVM()
                    {
                        Id = m.Category.Id,
                        Name = m.Category.Name
                    },
                    CategoryName = m.Category.Name,
                    DirectorName = m.Director.FirstName + " " + m.Director.LastName,
                    Director = new DirectorVM()
                    {
                        Id = m.Director.Id,
                        Name = m.Director.FirstName + " " + m.Director.LastName,
                    },
                    Actors = m.Actors.Select(a => new ActorVM()
                    {
                        Id = a.Id,
                        Name = a.FirstName + " " + a.LastName,
                    }),
                    Country = new CountryVM()
                    {
                        Id = m.Country.Id,
                        Name = m.Country.Name,
                    },
                    CountryName = m.Country.Name,
                    ParentsGuideId = (int)(m.ParentsGuide),
                    Poster = m.Poster,
                    Year = m.Year,
                    Duration = m.Duration,
                    Description = m.Description,
                };
            }
        }

        public static Movie ToMovieSimple(Movie movie, MovieVM model)
        {
            movie.Title = model.Title;
            movie.ParentsGuide = (ParentsGuide)model.ParentsGuideId;
            movie.Poster = model.Poster;
            movie.Year = model.Year;
            movie.Description = model.Description;
            movie.Duration = model.Duration;

            return movie;
        }
    }
}