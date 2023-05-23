using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Valeronix.Areas.Identity;
using Valeronix.Data;
using Valeronix.Models.DatabaseModels;

namespace Valeronix.Areas.Site.Controllers
{
    [Area("Site")]
    [Authorize(Roles = Roles.Admin)]
    public class OSController : Controller
    {
        public readonly ApplicationDbContext _db;
        public OSController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<OS> osList = _db.OS.Include(u => u.Creator).ToList();
            return View(osList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> CreatorList = _db.Creator.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CreatorList = CreatorList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(OS os)
        {
            if (ModelState.IsValid)
            {
                _db.OS.Add(os);
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

            OS? osFromDb = _db.OS.Find(id);
            if (osFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CreatorList = _db.Creator.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CreatorList = CreatorList;

            return View(osFromDb);
        }

        [HttpPost]
        public IActionResult Edit(OS os)
        {
            if (ModelState.IsValid)
            {
                _db.OS.Update(os);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            OS? osFromDb = _db.OS.Find(id);
            if (osFromDb == null)
            {
                return NotFound();
            }
            _db.OS.Remove(osFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
