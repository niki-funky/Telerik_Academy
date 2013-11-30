using System.Collections.Generic;
using System.Data.Entity;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LizardmanCinemas.Data;
using LizardmanCinemas.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LizardmanCinemas.Controllers
{
    public class HomeController : BaseController
    {
        IUowData db;

        public HomeController()
            : base(null)
        {
            db = new UowData();
        }

        public HomeController(IUowData db)
            : base(db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            //var model = new HomeVewModel();
            //model.Movies = db.Movies.OrderByDescending(x => x.Votes.Count(c => c.MovieId == x.Id)).Include("Director").Include("Country").Take(4).ToList();
            //model.LastMovie = db.Movies.OrderByDescending(x => x.Id).First();

           // var movies = db.Movies.All().Take(3).Select(MovieHomeVM.FromMovie).ToList();
            //var models = movies.All(x => { x.DisplayDate = "foo"; return true; });
            var models = db.Movies.All().Take(3).Select(MovieHomeVM.FromMovie).ToList();//.Include(m => m.Category).Include(m => m.Director);
            foreach (MovieHomeVM mov in models)
            {
                mov.Comments.All(x => { x.DisplayDate = x.CreatedOn.ToString("dd/MM/yy hh:mm"); return true; });
            }
            //var models = movies.Select(MovieHomeVM.FromMovie).Take(3).ToList();
            //var movies = db.Movies.All().OrderByDescending(x => x.Votes.Count(c => c.MovieId == x.Id))
            //    .Include("Director").Include("Country").Take(3).Select(m => MovieShortViewModel.FromMovie);

            return View(models);
        }

        public ActionResult ReadComments([DataSourceRequest]DataSourceRequest request, IEnumerable<MovieHomeVM> movies)
        {
            var models = db.Movies.All()
                .OrderByDescending(x => x.Comments.OrderBy(cc => cc.CreatedOn))
                .Take(10)
                .Select(MovieHomeVM.FromMovie).ToList();

            foreach (MovieHomeVM mov in models)
            {
                mov.Comments.All(x => { x.DisplayDate = x.CreatedOn.ToString("dd/MM/yy hh:mm"); return true; });
            }

            DataSourceResult result = models.ToDataSourceResult(request);

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}