using System.Collections.Generic;
using LizardmanCinemas.Models;

namespace LizardmanCinemas.ViewModels
{
    public class HomeVewModel
    {
        public List<Movie> Movies { get; set; }

        public Movie LastMovie { get; set; }

        public HomeVewModel()
        {
            Movies = new List<Movie>();
        }
    }
}