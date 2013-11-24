using System;
using System.Linq;

namespace StudentSystem.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
