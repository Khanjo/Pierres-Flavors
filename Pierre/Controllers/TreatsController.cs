using Pierre.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pierre.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierreContext _db;

        public TreatsController(PierreContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Recipe> model = _db.Recipes.ToList();
        }
    }
}