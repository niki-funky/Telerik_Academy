using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LizardmanCinemas.Controllers;
using LizardmanCinemas.Models;
using LizardmanCinemas.Data;
using LizardmanCinemas.ViewModels;
using System.IO;
using System.Web;

namespace LizardmanCinemas.Areas.Admin.Controllers
{
    public class DirectorAdminController : BaseController
    {
        IUowData db;

        public DirectorAdminController()
            : base(null)
        {
            db = new UowData();
        }

        public DirectorAdminController(IUowData db)
            : base(db)
        {
        }

        // GET: /Admin/Directors/
        public ActionResult Index()
        {
            var directors = db.Directors.All();

            var models = directors.Select(DirectorLongVM.FromDirector).ToList();

            return View(models);
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var actors = db.Directors.All();

            var models = actors.Select(DirectorLongVM.FromDirector).ToList();

            DataSourceResult result = models.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult Save(HttpPostedFileBase file)
        {
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            fileName += extension;
            var physicalPath = Path.Combine(Server.MapPath("~/Content/Directors/"), fileName);

            file.SaveAs(physicalPath);

            return Json(new { PosterUrl = fileName }, "text/plain");
        }



        // GET: /Admin/Directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.GetById(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: /Admin/Directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Directors/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: /Admin/Directors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.GetById(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: /Admin/Directors/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Update(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(director);
        }

        // GET: /Admin/Directors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.GetById(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: /Admin/Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = db.Directors.GetById(id);
            db.Directors.Delete(director);
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
