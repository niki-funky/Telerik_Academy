using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LizardmanCinemas.Models.Attributes;

namespace LizardmanCinemas.Models
{
    public class Movie
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string Title { get; set; }

        public virtual Director Director { get; set; }

        [Required]
        [RangeYearToCurrent(1800)]
        public int Year { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Range(1, 180)]
        public int Duration { get; set; }

        public string Trailer { get; set; }

        public string Poster { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public  virtual Country Country { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ParentsGuide ParentsGuide { get; set; }

        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }
    }
}