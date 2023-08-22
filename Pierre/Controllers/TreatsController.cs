using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

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
            ViewBag.PageTitle = "Treats Index";
            List<Treat> model = _db.Treats.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PageTitle = "Create Treat";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.PageTitle = "Create Treat";
                return View(treat);
            }
            else
            {
                _db.Treats.Add(treat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            ViewBag.PageTitle = "Treat Details";
            Treat thisTreat = _db.Treats.Include(treat => treat.JoinEntities).ThenInclude(join => join.Flavor).FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize]
        public ActionResult AddFlavor(int id)
        {
            ViewBag.PageTitle = "Add Flavor";
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Flav");
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int flavorId)
        {
#nullable enable
            TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => join.FlavorId == flavorId && join.TreatId == treat.TreatId);
#nullable disable
            if (joinEntity == null && flavorId != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = treat.TreatId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.PageTitle = "Edit Treat";
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Treats.Update(treat);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = treat.TreatId });
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.PageTitle = "Delete Treat";
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteJoin(int joinId)
        {
            TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
            _db.TreatFlavors.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}