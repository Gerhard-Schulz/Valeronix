using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Valeronix.Data;
using Valeronix.Models.DatabaseModels;

namespace Valeronix.Areas.Site.Controllers
{
    [Area("Site")]
    public class ShopController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ShopController(ApplicationDbContext db) => _db = db;

        public IActionResult Computer()
        {
            List<Computer> computerList = _db.Computer.
                Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).
                Include(u => u.VideoCard).ThenInclude(u => u.Creator).
                Include(u => u.OS).ThenInclude(u => u.Creator).
                Include(u => u.Processor).ThenInclude(u => u.Creator).ToList();

            return View(computerList);
        }

        public IActionResult Keyboard()
        {
            List<Keyboard> keyboardList = _db.Keyboard.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(keyboardList);
        }

        public IActionResult Monitor()
        {
            List<MonitorMagaz> monitorList = _db.MonitorMagaz.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(monitorList);
        }

        public IActionResult Mouse()
        {
            List<Mouse> mouseList = _db.Mouse.Include(u => u.ModelOfDevice).ThenInclude(u => u.Creator).ToList();
            return View(mouseList);
        }

        public IActionResult Processor()
        {
            List<Processor> processorList = _db.Processor.Include(u => u.Creator).ToList();
            return View(processorList);
        }

        public IActionResult VideoCard()
        {
            List<VideoCard> videoCardList = _db.VideoCard.Include(u => u.Creator).ToList();
            return View(videoCardList);
        }
    }
}
