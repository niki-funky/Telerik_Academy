namespace LibrarySystem.Controllers
{
    using System.Web.Mvc;
    using LibrarySystem.Data;

    public class BaseController : Controller
    {
        public BaseController(IUowData db)
        {
            this.db = db;
        }

        protected IUowData db { get; set; }
    }
}