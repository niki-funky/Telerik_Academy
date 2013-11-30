namespace LizardmanCinemas.Controllers
{
    using System.Web.Mvc;
    using LizardmanCinemas.Data;

    public class BaseController : Controller
    {
        public BaseController(IUowData db)
        {
            this.db = db;
        }

        protected IUowData db { get; set; }
    }
}