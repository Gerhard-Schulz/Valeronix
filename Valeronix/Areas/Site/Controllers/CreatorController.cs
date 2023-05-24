using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Valeronix.Areas.Identity;
using Valeronix.Data;
using Valeronix.Models.DatabaseModels;

namespace Valeronix.Areas.Site.Controllers
{
    [Area("Site")]
    [Authorize(Roles = Roles.Admin)]
    public class CreatorController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CreatorController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var creator = from c in _db.Creator select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                creator = creator.Where(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    creator = creator.OrderByDescending(c => c.Name);
                    break;
                //case "Date":
                //    creator = creator.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    creator = creator.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    creator = creator.OrderBy(c => c.Name);
                    break;
            }
            return View(creator);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Creator creator)
        {
            if (ModelState.IsValid)
            {
                _db.Creator.Add(creator);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Creator? creatorFromDb = _db.Creator.Find(id);
            if (creatorFromDb == null)
            {
                return NotFound();
            }
            return View(creatorFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Creator creator)
        {
            if (ModelState.IsValid)
            {
                _db.Creator.Update(creator);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Creator? creatorFromDb = _db.Creator.Find(id);
            if (creatorFromDb == null)
            {
                return NotFound();
            }
            _db.Creator.Remove(creatorFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
