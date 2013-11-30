using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class CountryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Country, CountryVM>> FromCountry
        {
            get
            {
                return cat => new CountryVM
                {
                    Id = cat.Id,
                    Name = cat.Name
                };
            }
        }
    }
}