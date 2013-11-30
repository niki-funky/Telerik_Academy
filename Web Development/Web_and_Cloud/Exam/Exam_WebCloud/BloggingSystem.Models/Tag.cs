using System;
using System.Linq;

namespace BloggingSystem.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }
    }
}
