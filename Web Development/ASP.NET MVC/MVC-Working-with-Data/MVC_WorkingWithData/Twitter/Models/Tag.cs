using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
