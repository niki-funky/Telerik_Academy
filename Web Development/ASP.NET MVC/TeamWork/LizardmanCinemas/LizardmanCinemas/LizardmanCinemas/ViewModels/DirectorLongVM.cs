﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LizardmanCinemas.Models;
using Newtonsoft.Json;

namespace LizardmanCinemas.ViewModels
{
    public class DirectorLongVM
    {
        public int Id { get; set; }
        [UIHint("_UploadDirectorPicture")]
        public string Picture { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [UIHint("_SexDropDown")]
        public Sex Sex { get; set; }

        public static Expression<Func<Director, DirectorLongVM>> FromDirector
        {
            get
            {
                return act => new DirectorLongVM
                {
                    Id = act.Id,
                    FirstName = act.FirstName,
                    LastName = act.LastName,
                    Picture = act.Picture,
                    Age = act.Age,
                    Sex = act.Sex
                };
            }
        }
    }
}