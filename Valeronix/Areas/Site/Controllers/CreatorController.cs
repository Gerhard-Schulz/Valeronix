using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            List<Creator> creatorList = _db.Creator.ToList();
            return View(creatorList);
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
