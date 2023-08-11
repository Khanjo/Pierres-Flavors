using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using Pierre.ViewModels;

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

        public ActionResult Search(string searchTerm)
        {
            List<Treat> treatResults = _db.Treats.Where(treat => treat.Name.Contains(searchTerm) || treat.Description.Contains(searchTerm)).ToList();

            List<Flavor> flavorResults = _db.Flavors.Where(flavor => flavor.Flav.Contains(searchTerm)).ToList();

            var searchResults = new SearchResults
            {
                TreatResults = treatResults,
                FlavorResults = flavorResults
            };

            return View("SearchResults", searchResults);
        }
    }
}