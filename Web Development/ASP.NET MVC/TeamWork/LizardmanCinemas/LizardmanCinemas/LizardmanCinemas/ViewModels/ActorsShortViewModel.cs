using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class ActorsShortViewModel
    {
        public static Expression<Func<Actor, ActorsShortViewModel>> FromActor
        {
            get
            {
                return actor => new ActorsShortViewModel()
                {
                    Id = actor.Id,
                    Name = actor.FirstName + " " + actor.LastName,
                    Picture = actor.Picture
                };
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}