using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LizardmanCinemas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LizardmanCinemas.Data;
using System.Data.Entity;

namespace LizardmanCinemas.Controllers
{
    public class SearchController : BaseController
    {
        private const string CategoryName = "Categories";
        private const string CountryName = "Countries";
        private const string ActorName = "Actors";
        private const string DirectorName = "Directors";
        private const string MovieName = "Movies";

        IUowData db;

        public SearchController()
            : base(null)
        {
            db = new UowData();
        }

        public SearchController(IUowData db)
            : base(db)
        {
        }

        // GET: /Search/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSearchDropDownData()
        {
            var models = new HashSet<SearchOption>()
            {
                new SearchOption()
                {
                    Name = "All"
                },
                new SearchOption()
                {
                    Name = MovieName
                },
                new SearchOption()
                {
                    Name = ActorName
                },
                new SearchOption()
                {
                    Name = DirectorName
                },
                new SearchOption()
                {
                    Name = CategoryName
                },
                new SearchOption()
                {
                    Name = CountryName
                },
            };

            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public ActionResult GetSearchResults([DataSourceRequest]DataSourceRequest request, string text, string table)
        {
            if (table == MovieName)
            {
                List<SearchResult> models = SearchMovies(text);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            if (table == ActorName)
            {
                List<SearchResult> models = SearchActors(text);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            if (table == DirectorName)
            {
                List<SearchResult> models = SearchDirectors(text);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            if (table == CategoryName)
            {
                List<SearchResult> models = SearchCategory(text);
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            if (table == CountryName)
            {
                List<SearchResult> models = SearchCountries(text);
                return Json(models, JsonRequestBehavior.AllowGet);
            }

            List<SearchResult> modelsAll = SearchMovies(text);

            modelsAll.AddRange(SearchActors(text));
            modelsAll.AddRange(SearchDirectors(text));
            modelsAll.AddRange(SearchCountries(text));
            modelsAll.AddRange(SearchCategory(text));

            return Json(modelsAll, JsonRequestBehavior.AllowGet);
        }

        private List<SearchResult> SearchCategory(string text)
        {
            return db.Categories.All().ToList()
                    .Where(c => c.Name.ToLower().Contains(text.ToLower()))
                    .Select(c => new SearchResult()
                {
                    Type = "Category",
                    Name = string.Format("{0}", c.Name),
                    Url = string.Format("{0}{1}", "/Categories/DetailsView/", c.Id),
                    FullUrl = string.Format("{0}{1}", "/Categories/Details/", c.Id)
                }).ToList<SearchResult>();
        }

        private List<SearchResult> SearchCountries(string text)
        {
           return db.Country.All().ToList()
                .Where(c => c.Name.ToLower().Contains(text.ToLower()))
                .Select(c => new SearchResult()
            {
                Type = "Country",
                Name = string.Format("{0}", c.Name),
                Url = string.Format("{0}{1}", "/Countries/DetailsView/", c.Id),
                FullUrl = string.Format("{0}{1}", "/Countries/Details/", c.Id)
            }).ToList<SearchResult>();
        }

        private List<SearchResult> SearchDirectors(string text)
        {
            return db.Directors.All().ToList()
                .Where(a => (a.FirstName + " " + a.LastName).ToLower().Contains(text.ToLower()))
                .Select(c => new SearchResult()
            {
                Type = "Director",
                Name = string.Format("{0} {1}", c.FirstName, c.LastName),
                Url = string.Format("{0}{1}", "/Directors/DetailsView/", c.Id),
                FullUrl = string.Format("{0}{1}", "/Directors/Details/", c.Id)
            }).ToList<SearchResult>();
        }

        private List<SearchResult> SearchActors(string text)
        {
            return db.Actors.All().ToList()
                .Where(a => (a.FirstName + " " + a.LastName).ToLower().Contains(text.ToLower()))
                    .Select(c => new SearchResult()
            {
                Type = "Actor",
                Name = string.Format("{0} {1}", c.FirstName, c.LastName),
                Url = string.Format("{0}{1}", "/Actors/DetailsView/", c.Id),
                FullUrl = string.Format("{0}{1}", "/Actors/Details/", c.Id)
            }).ToList<SearchResult>();
        }

        private List<SearchResult> SearchMovies(string text)
        {
            List<SearchResult> mov = db.Movies.All().ToList()
                .Where(m => m.Title.ToLower().Contains(text.ToLower()))
                .Select(c => new SearchResult()
            {
                Type = "Movie",
                Name = c.Title,
                Url = string.Format("{0}{1}", "/Movies/DetailsView/", c.Id),
                FullUrl = string.Format("{0}{1}", "/Movies/Details/", c.Id)
            }).ToList<SearchResult>();

            return mov;
        }

        [ValidateInput(false)]
        public ActionResult Search(string query, string table)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View(new List<SearchResult>());
            }

            if (table == MovieName)
            {
                List<SearchResult> models = SearchMovies(query);
                return View(models);
            }
            if (table == ActorName)
            {
                List<SearchResult> models = SearchActors(query);
                return View(models);
            }
            if (table == DirectorName)
            {
                List<SearchResult> models = SearchDirectors(query);
                return View(models);
            }
            if (table == CategoryName)
            {
                List<SearchResult> models = SearchCategory(query);
                return View(models);
            }
            if (table == CountryName)
            {
                List<SearchResult> models = SearchCountries(query);
                return View(models);
            }

            List<SearchResult> modelsAll = SearchMovies(query);

            modelsAll.AddRange(SearchActors(query));
            modelsAll.AddRange(SearchDirectors(query));
            modelsAll.AddRange(SearchCountries(query));
            modelsAll.AddRange(SearchCategory(query));

            return View(modelsAll);
        }
    }
}