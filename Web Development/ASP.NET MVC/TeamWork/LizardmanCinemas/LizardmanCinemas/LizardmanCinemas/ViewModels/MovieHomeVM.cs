using System.Collections.Generic;
using LizardmanCinemas.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LizardmanCinemas.ViewModels
{
    public class MovieHomeVM
    {
        public static Expression<Func<Movie, MovieHomeVM>> FromMovie
        {
            get
            {
                return movie => new MovieHomeVM()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Poster = movie.Poster,
                    Year = movie.Year,
                    Trailer = movie.Trailer,
                    Comments = movie.Comments.Select(c => new CommentVM()
                    {
                        CommentText = c.CommentText,
                        CreatedOn = c.CreatedOn,
                        Username = c.User.UserName
                    }).ToList()
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int Year { get; set; }
        public virtual ICollection<CommentVM> Comments { get; set; }

        public MovieHomeVM()
        {
            this.Comments = new HashSet<CommentVM>();
        }
    }
}
