using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Controllers;
using LibrarySystem.Models;
using LibrarySystem.Data;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [ValidateInput(false)]
    public class AdminController : BaseController
    {
        IUowData db;

        public AdminController()
            : base(null)
        {
            db = new UowData();
        }

        public AdminController(IUowData db)
            : base(db)
        {
        }

        // GET: /Admin/Admin/
        public ActionResult Index()
        {
            var books = db.Books.All();
            var models = books.Select(BookVM.FromBook).ToList();

            return View(models);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, BookVM model)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
                book = FromBook(model);

                try
                {
                    db.Books.Add(book);
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

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Books.All();

            var models = movies.Select(BookVM.FromBook).ToList();

            DataSourceResult result = models.ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, BookVM model)
        {
            var book = db.Books.All().Select(BookVM.FromBook).FirstOrDefault(b => b.BookId == model.BookId);
            if (book != null)
            {
                book = model;
            }
            else
            {
                ModelState.AddModelError("Movie", "Movie not found! Updating failed.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bookToEdit = FromBook(book);
                    db.Books.Update(bookToEdit);
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([DataSourceRequest] DataSourceRequest request, int bookId)
        {
            Book book = db.Books.GetById(bookId);
            if (book != null)
            {
                try
                {
                    db.Books.Delete(book);
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
                ModelState.AddModelError("Book", "Book not found! Deleting failed.");
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllCategories([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Categories.All();

            var models = movies.Select(CategoryVM.FromCategory);

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Admin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.GetById(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        // GET: /Admin/Admin/Create
        //public ActionResult Create()
        //{
        //    //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
        //    return View();
        //}

        // POST: /Admin/Admin/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
        //    return View(book);
        //}

        // GET: /Admin/Admin/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.GetById(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
        //    return View(book);
        //}

        // POST: /Admin/Admin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Books.Update(book);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
        //    return View(book);
        //}

        // GET: /Admin/Admin/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book book = db.Books.GetById(id);
        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book);
        //}

        // POST: /Admin/Admin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Book book = db.Books.GetById(id);
        //    db.Books.Delete(book);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public Book FromBook(BookVM bookVM)
        {
            return new Book()
            {
                BookId = bookVM.BookId,
                Title = bookVM.Title,
                Authors = bookVM.Authors,
                Category = new Category()
                {
                    CategoryId = bookVM.Category.CategoryId,
                    Name = bookVM.Category.Name
                },
                CategoryId = bookVM.Category.CategoryId,
                Description = bookVM.Description,
                ISBN = bookVM.ISBN,
                WebSite = bookVM.WebSite
            };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
