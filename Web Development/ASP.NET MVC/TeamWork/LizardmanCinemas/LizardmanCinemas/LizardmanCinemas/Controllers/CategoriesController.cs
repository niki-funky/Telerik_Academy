using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LizardmanCinemas.Data;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;

namespace LizardmanCinemas.Controllers
{
    public class CategoriesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Categories/
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: /Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var movies = db.Movies.Where(m => m.Category.Id == category.Id);

            return View(movies);
        }

        public ActionResult DetailsView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Category category = db.Categories.FirstOrDefault(c => c.Id == id);
            
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryMovies = db.Movies.Where(m => m.Category.Id == category.Id);

            var model = categoryMovies.Select(MovieShortViewModel.FromMovie);

            return PartialView("_CategoryMoviesPopUp", model);
        }

        public ActionResult GetMovies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selectedMovies = db.Movies
                .Where(x => x.Category.Id == id).ToList();

            return PartialView("_CategoryMovies", selectedMovies);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
