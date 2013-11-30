using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class DirectorDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Picture { get; set; }

        public IEnumerable<MovieDetails> Movies { get; set; }
    }
}