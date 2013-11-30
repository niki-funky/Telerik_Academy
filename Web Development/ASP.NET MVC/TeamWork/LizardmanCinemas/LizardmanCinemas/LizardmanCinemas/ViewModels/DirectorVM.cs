using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LizardmanCinemas.ViewModels
{
    public class DirectorVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Director, DirectorVM>> FromDirector
        {
            get
            {
                return d => new DirectorVM
                {
                    Id = d.Id,
                    Name = d.FirstName + " " + d.LastName
                };
            }
        }
    }
}
