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
    public class KeyboardController : Controller
    {
        public readonly ApplicationDbContext _db;
        public KeyboardController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Keyboard> keyboardList = _db.Keyboard.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(keyboardList);
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
        public IActionResult Add(Keyboard keyboard)
        {
            if (ModelState.IsValid)
            {
                _db.Keyboard.Add(keyboard);
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

            Keyboard? keyboardFromDb = _db.Keyboard.Find(id);
            if (keyboardFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View(keyboardFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Keyboard keyboard)
        {
            if (ModelState.IsValid)
            {
                _db.Keyboard.Update(keyboard);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Keyboard? keyboardFromDb = _db.Keyboard.Find(id);
            if (keyboardFromDb == null)
            {
                return NotFound();
            }
            _db.Keyboard.Remove(keyboardFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
