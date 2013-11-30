using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LizardmanCinemas.Models
{
    public class Actor : Person
    {
        public virtual ICollection<Movie> Movies { get; set; }

        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }
    }
}
