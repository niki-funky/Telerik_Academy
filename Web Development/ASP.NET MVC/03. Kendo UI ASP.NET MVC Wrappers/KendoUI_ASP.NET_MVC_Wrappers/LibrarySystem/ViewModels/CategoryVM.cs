using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LibrarySystem.Models;

namespace LibrarySystem.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryVM>> FromCategory
        {
            get
            {
                return cat => new CategoryVM
                {
                    CategoryId = cat.CategoryId,
                    Name = cat.Name
                };
            }
        }
    }
}
