using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Twitter.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        //[Required(ErrorMessage = "You must be logged!")]
        public string Creator { get; set; }
        [Required(ErrorMessage = "Content should not be empty!")]
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
