﻿using Microsoft.AspNetCore.Authorization;
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
    public class ProcessorController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ProcessorController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Processor> processorList = _db.Processor.Include(u => u.Creator).ToList();
            return View(processorList);
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
        public IActionResult Add(Processor processor)
        {
            if (ModelState.IsValid)
            {
                _db.Processor.Add(processor);
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

            Processor? processorFromDb = _db.Processor.Find(id);
            if (processorFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CreatorList = _db.Creator.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CreatorList = CreatorList;

            return View(processorFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Processor processor)
        {
            if (ModelState.IsValid)
            {
                _db.Processor.Update(processor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Processor? processorFromDb = _db.Processor.Find(id);
            if (processorFromDb == null)
            {
                return NotFound();
            }
            _db.Processor.Remove(processorFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
