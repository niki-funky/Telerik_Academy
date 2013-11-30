using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class ActorVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Actor, ActorVM>> FromActor
        {
            get
            {
                return act => new ActorVM
                {
                    Id = act.Id,
                    Name = act.FirstName + " " + act.LastName
                };
            }
        }
    }
}