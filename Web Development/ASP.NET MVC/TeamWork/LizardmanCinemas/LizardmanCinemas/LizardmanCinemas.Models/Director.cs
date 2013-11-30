using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LizardmanCinemas.Models
{
    public class Director : Person
    {
        public virtual ICollection<Movie> Movies { get; set; }

        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }
    }
}
