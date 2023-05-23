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
    public class MouseController : Controller
    {
        public readonly ApplicationDbContext _db;
        public MouseController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Mouse> mouseList = _db.Mouse.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(mouseList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                _db.Mouse.Add(mouse);
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

            Mouse? mouseFromDb = _db.Mouse.Find(id);
            if (mouseFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View(mouseFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                _db.Mouse.Update(mouse);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Mouse? mouseFromDb = _db.Mouse.Find(id);
            if (mouseFromDb == null)
            {
                return NotFound();
            }
            _db.Mouse.Remove(mouseFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
