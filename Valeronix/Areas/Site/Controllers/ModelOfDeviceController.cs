using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Valeronix.Areas.Identity;
using Valeronix.Data;
using Valeronix.Models.DatabaseModels;
using Valeronix.Models.ViewModels;

namespace Valeronix.Areas.Site.Controllers
{
    [Area("Site")]
    [Authorize(Roles = Roles.Admin)]
    public class ModelOfDeviceController : Controller
    {
        public readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public ModelOfDeviceController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        //public IActionResult Index()
        //{
        //    List<ModelOfDevice> modelOfDeviceList = _db.ModelOfDevice.Include(u => u.Creator).ToList();
        //    return View(modelOfDeviceList);
        //}

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var modelOfDevice = _db.ModelOfDevice.Include(u => u.Creator).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                modelOfDevice = modelOfDevice.Where(c => c.Name.Contains(searchString) || c.Creator.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    modelOfDevice = modelOfDevice.OrderByDescending(c => c.Creator.Name).ThenBy(c => c.Name);
                    break;
                default:
                    modelOfDevice = modelOfDevice.OrderBy(c => c.Creator.Name).ThenBy(c => c.Name);
                    break;
            }
            return View(modelOfDevice.ToList());
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
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateModelOfDevice modelOfDevice)
        {
            if (!ModelState.IsValid)
            {
                return View(modelOfDevice);
            }

            ModelOfDevice model = modelOfDevice.ToModelOfDevice();
            string wwwRootPath = _environment.WebRootPath;
            if (modelOfDevice.PhotoUrl != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(modelOfDevice.PhotoUrl.FileName);
                string modelOfDevicePath = Path.Combine(wwwRootPath, Path.Combine("images", "devices"));
                using (var fileStream = new FileStream(Path.Combine(modelOfDevicePath, fileName), FileMode.Create))
                {
                    modelOfDevice.PhotoUrl.CopyTo(fileStream);
                };
                model.PhotoUrl = fileName;
            }
            _db.ModelOfDevice.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ModelOfDevice? modelOfDeviceFromDb = _db.ModelOfDevice.Find(id);
            if (modelOfDeviceFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CreatorList = _db.Creator.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CreatorList = CreatorList;

            return View(modelOfDeviceFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditModelOfDevice modelOfDevice)
        {
            var modelOfDeviceFromDb = _db.ModelOfDevice.FirstOrDefault(u => u.Id == modelOfDevice.Id);

            if (modelOfDeviceFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(modelOfDevice);
            }

            modelOfDeviceFromDb.Update(modelOfDevice);
            string wwwRootPath = _environment.WebRootPath;
            if (modelOfDevice.PhotoUrl != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(modelOfDevice.PhotoUrl.FileName);
                string modelOfDevicePath = Path.Combine(wwwRootPath, Path.Combine("images", "modelOfDevices"));
                string oldPhotoPath = Path.Combine(modelOfDevicePath, modelOfDeviceFromDb.PhotoUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldPhotoPath))
                {
                    System.IO.File.Delete(oldPhotoPath);
                }
                using (var fileStream = new FileStream(Path.Combine(modelOfDevicePath, fileName), FileMode.Create))
                {
                    modelOfDevice.PhotoUrl.CopyTo(fileStream);
                }
                modelOfDeviceFromDb.PhotoUrl = fileName;
            }
            _db.ModelOfDevice.Update(modelOfDeviceFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            ModelOfDevice? modelOfDeviceFromDb = _db.ModelOfDevice.Find(id);
            if (modelOfDeviceFromDb == null)
            {
                return NotFound();
            }
            _db.ModelOfDevice.Remove(modelOfDeviceFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
