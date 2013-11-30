using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Movie Movie { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        [Column(TypeName="ntext")]
        public string CommentText { get; set; }
    }
}