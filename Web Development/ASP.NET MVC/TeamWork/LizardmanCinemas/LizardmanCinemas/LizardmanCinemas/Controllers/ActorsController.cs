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
    public class ActorsController : BaseController
    {
        //private DataContext db = new DataContext();
        IUowData db;

        public ActorsController()
            : base(null)
        {
            db = new UowData();
        }

        public ActorsController(IUowData db)
            : base(db)
        {
        }

        // GET: /Actors/
        public ActionResult Index()
        {
            //// if using Kendo ListView
            return View(db.Actors.All().Select(ActorsShortViewModel.FromActor).ToList());
            
            //return View(db.Actors.All().ToList());
        }

        // DataSource for the Kendo ListView
        public ActionResult ReadActors([DataSourceRequest]DataSourceRequest request)
        {
            var actors = db.Actors.All().Select(ActorsShortViewModel.FromActor).AsEnumerable();

            DataSourceResult result = actors.ToDataSourceResult(request);

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
            Actor actor = db.Actors.All().Include(d => d.Movies).FirstOrDefault(d => d.Id == id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            var model = new ActorDetails()
            {
                FullName = actor.FirstName + " " + actor.LastName,
                Id = actor.Id,
                Age = actor.Age,
                Picture = actor.Picture,
                Movies = actor.Movies.Select(m => new MovieDetails()
                {
                    Title = m.Title,
                    CategoryName = m.Category.Name,
                    DetailsUrl = "/Movies/Details/" + m.Id,
                })
            };

            return PartialView("_ActorDetails", model);
        }

        // GET: /Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.GetById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        public ActionResult ActorMovies(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.GetById(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_ActorMovies", actor);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
