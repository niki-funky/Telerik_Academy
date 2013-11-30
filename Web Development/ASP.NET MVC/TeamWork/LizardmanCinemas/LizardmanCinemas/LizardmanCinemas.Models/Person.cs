using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public Sex Sex { get; set; }
    }
}