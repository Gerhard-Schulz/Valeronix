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
    public class MonitorController : Controller
    {
        public readonly ApplicationDbContext _db;
        public MonitorController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<MonitorMagaz> monitorList = _db.MonitorMagaz.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(monitorList);
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
        public IActionResult Add(MonitorMagaz monitor)
        {
            if (ModelState.IsValid)
            {
                _db.MonitorMagaz.Add(monitor);
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

            MonitorMagaz? monitorFromDb = _db.MonitorMagaz.Find(id);
            if (monitorFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View(monitorFromDb);
        }

        [HttpPost]
        public IActionResult Edit(MonitorMagaz monitor)
        {
            if (ModelState.IsValid)
            {
                _db.MonitorMagaz.Update(monitor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            MonitorMagaz? monitorFromDb = _db.MonitorMagaz.Find(id);
            if (monitorFromDb == null)
            {
                return NotFound();
            }
            _db.MonitorMagaz.Remove(monitorFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
