using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LizardmanCinemas.Controllers;
using LizardmanCinemas.Models;
using LizardmanCinemas.Data;
using LizardmanCinemas.ViewModels;
using LizardmanCinemas.Helper;
using System.IO;

namespace LizardmanCinemas.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ValidateInput(false)]
    public class ActorAdminController : BaseController
    {
        IUowData db;

        public ActorAdminController()
            : base(null)
        {
            db = new UowData();
        }

        public ActorAdminController(IUowData db)
            : base(db)
        {
        }

        // GET: /Admin/ActorAdmin/
        public ActionResult Index()
        {
            var actors = db.Actors.All();

            var models = actors.Select(ActorLongVM.FromActor).ToList();

            return View(models);
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var actors = db.Actors.All();

            var models = actors.Select(ActorLongVM.FromActor).ToList();

            DataSourceResult result = models.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult GetAllSexes()
        {
            var models = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                     Value = "0",
                     Text = "Male"
                },
                new SelectListItem()
                {
                     Value = "1",
                     Text = "Female"
                },
            };

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(HttpPostedFileBase file)
        {
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            fileName += extension;
            var physicalPath = Path.Combine(Server.MapPath("~/Content/Actors/"), fileName);

            file.SaveAs(physicalPath);

            return Json(new { PosterUrl = fileName }, "text/plain");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }   

        // POST: /Admin/ActorAdmin/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Update(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }       

        // POST: /Admin/ActorAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.GetById(id);
            db.Actors.Delete(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
