using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Pierre.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly PierreContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, PierreContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Flavors Index";
            List<Flavor> model = _db.Flavors.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PageTitle = "Create Flavor";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ViewBag.PageTitle = "Flavor Details";
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [Authorize]
        public ActionResult AddTreat(int id)
        {
            ViewBag.PageTitle = "Add Treat";
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult AddTreat(Flavor flavor, int treatId)
        {
#nullable enable
            TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
#nullable disable
            if (joinEntity == null && treatId != 0)
            {
                _db.TreatFlavors.Add(new TreatFlavor() { TreatId = treatId, FlavorId = flavor.FlavorId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = flavor.FlavorId });
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.PageTitle = "Edit Flavor";
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Flavors.Update(flavor);
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = flavor.FlavorId });
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.PageTitle = "Delete Flavor";
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            _db.Flavors.Remove(thisFlavor);
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