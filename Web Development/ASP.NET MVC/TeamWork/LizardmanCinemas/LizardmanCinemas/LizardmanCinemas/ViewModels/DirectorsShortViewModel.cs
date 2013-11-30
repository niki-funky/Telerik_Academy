using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class DirectorsShortViewModel
    {
        public static Expression<Func<Director, DirectorsShortViewModel>> FromDirector
        {
            get
            {
                return director => new DirectorsShortViewModel()
                {
                    Id = director.Id,
                    Name = director.FirstName + " " + director.LastName,
                    Age = director.Age,
                    Picture = director.Picture
                };
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Picture { get; set; }
        public int Age { get; set; }
    }
}