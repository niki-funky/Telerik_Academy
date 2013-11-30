using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LizardmanCinemas.Controllers;
using LizardmanCinemas.Data;
using LizardmanCinemas.Helper;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LizardmanCinemas.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ValidateInput(false)]
    public class MovieAdminController : BaseController
    {
        IUowData db;

        public MovieAdminController()
            : base(null)
        {
            db = new UowData();
        }

        public MovieAdminController(IUowData db)
            : base(db)
        {
        }

        // GET: /Admin/MovieAdmin/
        public ActionResult Index()
        {
            var movies = db.Movies.All();//.Include(m => m.Category).Include(m => m.Director);

            var models = movies.Select(MovieVM.FromMovie).ToList();

            foreach (var mov in models)
            {
                mov.ParentsGuideName = Enum.GetName(typeof(ParentsGuide), mov.ParentsGuideId);
            }

            return View(models);
        }

        public ActionResult GetMovie(string movieTitle)
        {
            IMDb imdb = new IMDb(movieTitle, true);

            var movieDate = int.Parse(imdb.Year);
            if (db.Movies.All().Any(m => m.Title == movieTitle && m.Year == movieDate))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Movie already exists");
            }

            var movie = new Movie()
            {
                Title = imdb.Title,
                Year = int.Parse(imdb.Year),
                Duration = int.Parse(imdb.Runtime),
                Description = imdb.Storyline,
                ParentsGuide = 0,
                Poster = GetPoster(imdb.PosterFull),
            };
            // actors
            movie.Actors = new List<Actor>();
            foreach (var actor in imdb.Cast)
            {
                var actorName = actor.ToString().Split(' ');
                if (actorName.Length > 1)
                {
                    var currActorFirst = actorName[0];
                    var currActorLast = actorName[1];

                    if (currActorFirst != null && currActorLast != null
                        && db.Actors.All().All(a => !a.FirstName.Contains(currActorFirst)
                        && !a.LastName.Contains(currActorLast)))
                    {
                        movie.Actors.Add(new Actor()
                        {
                            FirstName = currActorFirst,
                            LastName = currActorLast,
                        });
                    }
                }
            }
            // directors
            var directorName = imdb.Directors[0].ToString().Split(' ');
            if (directorName.Length > 1)
            {
                var currDirectorFirst = directorName[0];
                var currDirectorLast = directorName[0];
                if (currDirectorFirst != null && currDirectorLast != null
                    && db.Directors.All().All(d => !d.FirstName.Contains(currDirectorFirst)
                    && !d.LastName.Contains(currDirectorLast)))
                {
                    movie.Director = imdb.Directors.ToArray().Select(d => new Director()
                    {
                        FirstName = d.ToString().Split(' ')[0],
                        LastName = d.ToString().Split(' ')[1],
                    }).FirstOrDefault();
                }
            }
            // categories
            var currGenre = imdb.Genres[0].ToString();
            var imdbCategories = imdb.Genres.ToArray().Select(i => new Category()
                                 {
                                     Name = i.ToString()
                                 }).ToList();
            var matchingCategories = db.Categories.All().ToList()
                .Where(c => imdbCategories.Any(cc => cc.Name == c.Name)).ToList();

            if (matchingCategories.Count() > 0)
            {
                movie.Category = matchingCategories.FirstOrDefault();
            }
            else
            {
                movie.Category = new Category()
                {
                    Name = currGenre
                };
            }
            // countries
            var currCountry = imdb.Countries[0].ToString();
            var imdbCountries = imdb.Countries.ToArray().Select(i => new Country()
                {
                    Name = i.ToString()
                }).ToList();
            var matchingCountries = db.Country.All().ToList()
                .Where(c => imdbCountries.Any(cc => cc.Name == c.Name)).ToList();

            if (matchingCountries.Count() > 0)
            {
                movie.Country = matchingCountries.FirstOrDefault();
            }
            else
            {
                movie.Country = new Country()
                {
                    Name = currCountry
                };
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            var movies = db.Movies.All().Select(MovieVM.FromMovie);

            return View("Index", movies.ToList());
        }

        private string GetPoster(string file)
        {
            string fileName = string.Empty;
            using (WebClient wc = new WebClient())
            {
                //Uri uri = new Uri(file , UriKind.Absolute);
                fileName = Guid.NewGuid() + ".jpg";
                var serverPath = Server.MapPath("~/Content/Posters/" + fileName);
                wc.DownloadFile(file, serverPath);
            }

            return fileName;
        }


        public ActionResult GetAllCategories([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Categories.All();

            var models = movies.Select(CategoryVM.FromCategory);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllDirectors([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Directors.All();

            var models = movies.Select(DirectorVM.FromDirector);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllActors([DataSourceRequest]DataSourceRequest request, string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                var models = db.Actors.All()
                    .Where(a=> (a.FirstName + " " + a.LastName).ToLower().Contains(text.ToLower()))
                    .Select(ActorVM.FromActor);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var models = db.Actors.All().Select(ActorVM.FromActor);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Movies.All();

            var models = movies.Select(MovieVM.FromMovie).ToList();

            foreach (var mov in models)
            {
                mov.ParentsGuideName = Enum.GetName(typeof(ParentsGuide), mov.ParentsGuideId);
            }

            DataSourceResult result = models.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult GetAllCountries([DataSourceRequest]DataSourceRequest request)
        {
            var countries = db.Country.All();

            var models = countries.Select(CountryVM.FromCountry);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllParentsGuides([DataSourceRequest]DataSourceRequest request)
        {
            var models = new HashSet<ParentsGuideVM>()
            {
                new ParentsGuideVM()
                {
                    Id=0,
                    Name="Under 12"
                },
                                new ParentsGuideVM()
                {
                    Id=1,
                    Name="Under 16"
                },
                                new ParentsGuideVM()
                {
                    Id=2,
                    Name="Under 18"
                }
            };

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // POST: /Admin/MovieAdmin/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, MovieVM model)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie = MovieVM.ToMovieSimple(movie, model);

                MovieVMToMovieNavigationProps(model, movie);

                model = new MovieVM()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Category = new CategoryVM()
                    {
                        Id = movie.Category.Id,
                        Name = movie.Category.Name
                    },
                    CategoryName = movie.Category.Name,
                    DirectorName = movie.Director.FirstName + " " + movie.Director.LastName,
                    Director = new DirectorVM()
                    {
                        Id = movie.Director.Id,
                        Name = movie.Director.FirstName + " " + movie.Director.LastName,
                    },
                    Actors = movie.Actors.Select(a => new ActorVM()
                    {
                        Id = a.Id,
                        Name = a.FirstName + " " + a.LastName,
                    }),
                    Country = new CountryVM()
                    {
                        Id = movie.Country.Id,
                        Name = movie.Country.Name,
                    },
                    CountryName = movie.Country.Name,
                    ParentsGuideId = (int)(movie.ParentsGuide),
                    Poster = movie.Poster,
                    Year = movie.Year,
                    Duration = movie.Duration,
                    Description = movie.Description,
                };

                model.ParentsGuideName = Enum.GetName(typeof(ParentsGuide), model.ParentsGuideId);

                try
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DatabaseException",
                       "Database error while updating the entries. Try updating again." + ex.Message);
                }
            }

            return Json((new[] { model }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        // POST: /Admin/MovieAdmin/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, MovieVM model)
        {
            var movie = db.Movies.All().Include(a => a.Actors).ToList().FirstOrDefault(m => m.Id == model.Id);
            if (movie != null)
            {
                movie = MovieVM.ToMovieSimple(movie, model);

                MovieVMToMovieNavigationProps(model, movie);
            }
            else
            {
                ModelState.AddModelError("Movie", "Movie not found! Updating failed.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DatabaseException",
                       "Database error while updating the entries. Try updating again." + ex.Message);
                }
            }

            return Json((new[] { model }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        private void MovieVMToMovieNavigationProps(MovieVM model, Movie movie)
        {
            HashSet<Actor> actors = new HashSet<Actor>();
            if (model.Actors != null)
            {
                foreach (var act in model.Actors)
                {
                    var currentActor = db.Actors.All().FirstOrDefault(a => a.Id == act.Id);
                    if (currentActor != null)
                    {
                        actors.Add(currentActor);
                    }
                }
            }

            movie.Actors = actors;
            if (model.Category != null)
            {
                var currentCategory = db.Categories.All().FirstOrDefault(c => c.Id == model.Category.Id);
                if (currentCategory != null)
                {
                    movie.Category = currentCategory;
                }
                else
                {
                    movie.Category = db.Categories.All().First();
                }
            }
            else
            {
                movie.Category = db.Categories.All().First();
            }

            if (model.Country != null)
            {
                var currentCountry = db.Country.All().FirstOrDefault(c => c.Id == model.Country.Id);
                if (currentCountry != null)
                {
                    movie.Country = currentCountry;
                }
                else
                {
                    movie.Country = db.Country.All().First();
                }
            }
            else
            {
                movie.Country = db.Country.All().First();
            }

            if (model.Director != null)
            {
                var currentDirector = db.Directors.All().FirstOrDefault(c => c.Id == model.Director.Id);
                if (currentDirector != null)
                {
                    movie.Director = currentDirector;
                }
                else
                {
                    movie.Director = db.Directors.All().First();
                }
            }
            else
            {
                movie.Director = db.Directors.All().First();
            }
        }

        public ActionResult Save(HttpPostedFileBase file)
        {
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            fileName += extension;
            var physicalPath = Path.Combine(Server.MapPath("~/Content/Posters/"), fileName);

            file.SaveAs(physicalPath);

            return Json(new { PosterUrl = fileName }, "text/plain");
        }

        // POST: /Admin/MovieAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([DataSourceRequest] DataSourceRequest request, int id)
        {
            Movie movie = db.Movies.All().FirstOrDefault(b => b.Id == id);
            if (movie != null)
            {
                try
                {
                    db.Movies.Delete(movie);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DatabaseException",
                       "Database error while updating the entries. Try deleting again." + ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("Movie", "Movie not found! Deleting failed.");
            }

            return Json((new[] { movie }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
