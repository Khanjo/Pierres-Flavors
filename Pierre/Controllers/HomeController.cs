using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
    public class HomeController : Controller
    {
        private readonly PierreContext _db;

        public HomeController(PierreContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            Treat[] treats = _db.Treats.ToArray();
            Flavor[] flavors = _db.Flavors.ToArray();
            Dictionary<string, object[]> model = new()
            {
                { "treats", treats },
                { "flavors", flavors }
            };
            return View(model);
        }

    }
}