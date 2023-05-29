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
    public class ComputerController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ComputerController(ApplicationDbContext db) => _db = db;

        public IActionResult Index(string searchString)
        {
            var computerList = _db.Computer.
                Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).
                Include(u => u.VideoCard).ThenInclude(u => u.Creator).
                Include(u => u.OS).ThenInclude(u => u.Creator).
                Include(u => u.Processor).ThenInclude(u => u.Creator).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                computerList = computerList.Where(c => c.Adapter.Contains(searchString) || c.MemoryType.Contains(searchString) || c.MemoryVolume.Contains(searchString) ||
                c.OzuMemory.Contains(searchString) || c.OS.Creator.Name.Contains(searchString) || c.OS.Name.Contains(searchString) || 
                c.Processor.Creator.Name.Contains(searchString) || c.VideoCard.Creator.Name.Contains(searchString) || c.VideoCard.Name.Contains(searchString) ||
                c.ModelOfDevice.Name.Contains(searchString) || c.ModelOfDevice.Creator.Name.Contains(searchString) || c.Price.ToString().Contains(searchString));
            }

            return View(computerList.ToList());
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> OSList = _db.OS.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.OSList = OSList;

            IEnumerable<SelectListItem> ProcessorList = _db.Processor.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ProcessorList = ProcessorList;

            IEnumerable<SelectListItem> VideoCardList = _db.VideoCard.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.VideoCardList = VideoCardList;

            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Computer computer)
        {
            if (ModelState.IsValid)
            {
                _db.Computer.Add(computer);
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

            Computer? computerFromDb = _db.Computer.Find(id);
            if (computerFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> OSList = _db.OS.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.OSList = OSList;

            IEnumerable<SelectListItem> ProcessorList = _db.Processor.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ProcessorList = ProcessorList;

            IEnumerable<SelectListItem> VideoCardList = _db.VideoCard.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.VideoCardList = VideoCardList;

            IEnumerable<SelectListItem> ModelOfDeviceList = _db.ModelOfDevice.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.ModelOfDeviceList = ModelOfDeviceList;

            return View(computerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Computer computer)
        {
            if (ModelState.IsValid)
            {
                _db.Computer.Update(computer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Computer? computerFromDb = _db.Computer.Find(id);
            if (computerFromDb == null)
            {
                return NotFound();
            }
            _db.Computer.Remove(computerFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
