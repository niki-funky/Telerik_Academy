using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryVM>> FromCategory
        {
            get
            {
                return cat => new CategoryVM
                {
                    Id = cat.Id,
                    Name = cat.Name
                };
            }
        }
    }
}