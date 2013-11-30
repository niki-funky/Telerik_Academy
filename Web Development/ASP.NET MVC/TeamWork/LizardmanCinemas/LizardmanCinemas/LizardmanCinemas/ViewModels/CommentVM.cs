using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LizardmanCinemas.Models;

namespace LizardmanCinemas.ViewModels
{
    public class CommentVM
    {
        public static Expression<Func<Comment, CommentVM>> FromComment
        {
            get
            {
                return c => new CommentVM()
                {
                    CommentText = c.CommentText,
                    CreatedOn = c.CreatedOn,
                    Username = c.User.UserName,
                    MovieName = c.Movie.Title
                };
            }
        }

        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public string DisplayDate { get; set; }
        public string CommentText { get; set; }
        public string MovieName { get; set; }
    }
}