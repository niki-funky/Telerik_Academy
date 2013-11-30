using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BloggingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public virtual User User { get; set; }
    }
}
