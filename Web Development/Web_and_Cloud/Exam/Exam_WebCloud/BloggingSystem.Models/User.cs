using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BloggingSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6),]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string Displayname { get; set; }

        [Required]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }

        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            //this.Tags = new HashSet<Tag>();
        }
    }
}
