using System;
using System.Data.Entity;
using System.Linq;
using LizardmanCinemas.Models;

namespace LizardmanCinemas.Data
{
    interface IDataContext
    {
        IDbSet<Movie> Movies { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Actor> Actors { get; set; }

        IDbSet<Director> Directors { get; set; }

        IDbSet<Country> Country { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }
    }
}
