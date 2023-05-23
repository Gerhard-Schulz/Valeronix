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
    public class VideoCardController : Controller
    {
        public readonly ApplicationDbContext _db;
        public VideoCardController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<VideoCard> videoCardList = _db.VideoCard.Include(u => u.Creator).ToList();
            return View(videoCardList);
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
        public IActionResult Add(VideoCard videoCard)
        {
            if (ModelState.IsValid)
            {
                _db.VideoCard.Add(videoCard);
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

            VideoCard? videoCardFromDb = _db.VideoCard.Find(id);
            if (videoCardFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CreatorList = _db.Creator.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CreatorList = CreatorList;

            return View(videoCardFromDb);
        }

        [HttpPost]
        public IActionResult Edit(VideoCard videoCard)
        {
            if (ModelState.IsValid)
            {
                _db.VideoCard.Update(videoCard);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            VideoCard? videoCardFromDb = _db.VideoCard.Find(id);
            if (videoCardFromDb == null)
            {
                return NotFound();
            }
            _db.VideoCard.Remove(videoCardFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
