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
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace LizardmanCinemas.Controllers
{
    public class DirectorsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Directors/
        public ActionResult Index()
        {
            //// if using Kendo ListView
            return View(db.Directors.Select(DirectorsShortViewModel.FromDirector).ToList());

            //return View(db.Directors.ToList());
        }

        public ActionResult ReadDirectors([DataSourceRequest]DataSourceRequest request)
        {
            var directors = db.Directors.Select(DirectorsShortViewModel.FromDirector);

            DataSourceResult result = directors.ToDataSourceResult(request);

            return Json(result);
        }

        // For Search Result Window
        // GET: /Directors/DetailsView/5
        public ActionResult DetailsView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Include(d => d.Movies).FirstOrDefault(d=> d.Id == id);
            if (director == null)
            {
                return HttpNotFound();
            }

            var model = new DirectorDetails()
            {
                FullName = director.FirstName + " " + director.LastName,
                Id = director.Id,
                Age = director.Age,
                Movies = director.Movies.Select(m => new MovieDetails()
                {
                     Title = m.Title,
                     CategoryName = m.Category.Name,
                     DetailsUrl = "/Movies/Details/" + m.Id
                })
            };

            return PartialView("_DirectorDetails", model);
        }

        // GET: /Directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        public ActionResult DirectorMovies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DirectorMovies", director);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
