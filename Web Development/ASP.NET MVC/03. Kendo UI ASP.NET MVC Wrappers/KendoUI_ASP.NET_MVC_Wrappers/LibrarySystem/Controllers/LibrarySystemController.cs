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
using LibrarySystem.Models;
using LibrarySystem.Data;

namespace LibrarySystem.Controllers
{
    public class LibrarySystemController : BaseController
    {
        //private DataContext db = new DataContext();
        IUowData db;

        public LibrarySystemController()
            : base(null)
        {
            db = new UowData();
        }

        public LibrarySystemController(IUowData db)
            : base(db)
        {
        }


        // GET: /LibrarySystem/
        public ActionResult Index()
        {
            var result = this.db.Categories.All()
                .Include("Books").ToList()
                .Select(x => new TreeViewItemModel
                {
                    Text = x.Name,
                    //Id = x.CategoryId.ToString(),
                    Items = x.Books
                    .Select(y => new TreeViewItemModel
                    {
                        Text = y.Title,
                        Id = y.BookId.ToString()
                    }).ToList()
                });
            //var books = db.Books.All().Include(b => b.Category);
            //return View(books.ToList());
            return View(result);
        }

        // GET: /LibrarySystem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: /LibrarySystem/Search/someString
        // [ValidateAntiForgeryToken]
        //public ActionResult Search([DataSourceRequest] DataSourceRequest request,string book)
        public ActionResult Search(string book)
        {
            if (book == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var books = db.Books.All().Where(b => b.Title.Contains(book) ||
                b.Authors.Contains(book)).Select(BookShortVM.FromBook).ToList();
            if (books == null)
            {
                return HttpNotFound();
            }

            //var result = books.ToDataSourceResult(request, o => new BookViewModel()
            //{
            //    BookId = o.BookId,
            //    Title = o.Title,
            //    Authors = o.Authors,
            //    CategoryName = o.Category.Name
            //});

            return View("Search", books); //result.Data);
        }

        // GET: /LibrarySystem/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.All(), "CategoryId", "Name");
            return View();
        }

        // POST: /LibrarySystem/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.All(), "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: /LibrarySystem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.All(), "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // POST: /LibrarySystem/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Update(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.All(), "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: /LibrarySystem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /LibrarySystem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.GetById(id);
            db.Books.Delete(book);
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
