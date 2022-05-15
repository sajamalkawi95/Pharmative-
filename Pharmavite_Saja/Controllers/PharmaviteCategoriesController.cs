using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmavite_Saja.Models;

namespace Pharmavite_Saja.Controllers
{
    public class PharmaviteCategoriesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PharmaviteCategoriesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: PharmaviteCategories
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            return View(await _context.PharmaviteCategories.ToListAsync());
        }

    public async Task<IActionResult> CategoryAdmin()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            return PartialView(await _context.PharmaviteCategories.ToListAsync());
        }

        // GET: PharmaviteCategories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteCategory = await _context.PharmaviteCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (pharmaviteCategory == null)
            {
                return NotFound();
            }

            return View(pharmaviteCategory);
        }

        // GET: PharmaviteCategories/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            return View();
        }

        // POST: PharmaviteCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryImg,CategoryName,ImageFile")] PharmaviteCategory pharmaviteCategory)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (ModelState.IsValid)
            {
                 if (pharmaviteCategory.ImageFile != null)
                {
                    string upFile = Path.Combine(_hostEnvironment.WebRootPath, "CategoryImages");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + pharmaviteCategory.ImageFile.FileName;
                    string filePath = Path.Combine(upFile, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        pharmaviteCategory.ImageFile.CopyTo(fileStream);
                    }
                    pharmaviteCategory.CategoryImg = uniqueFileName;
                }
                else
                {
                    pharmaviteCategory.CategoryImg = "Drug.jpg";
                }
                _context.Add(pharmaviteCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashbord");
            }
            return View();
        }

        // GET: PharmaviteCategories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteCategory = await _context.PharmaviteCategories.FindAsync(id);
            if (pharmaviteCategory == null)
            {
                return NotFound();
            }
            return View(pharmaviteCategory);
        }

        // POST: PharmaviteCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CategoryId,CategoryImg,CategoryName,ImageFile")] PharmaviteCategory pharmaviteCategory)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id != pharmaviteCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (pharmaviteCategory.ImageFile != null)
                {
                    string upFile = Path.Combine(_hostEnvironment.WebRootPath, "CategoryImages");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + pharmaviteCategory.ImageFile.FileName;
                    string filePath = Path.Combine(upFile, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        pharmaviteCategory.ImageFile.CopyTo(fileStream);
                    }
                    pharmaviteCategory.CategoryImg = uniqueFileName;
                }
                else
                {
                    pharmaviteCategory.CategoryImg = "Drug.jpg";
                }
                try
                {

                    _context.Update(pharmaviteCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteCategoryExists(pharmaviteCategory.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Dashbord");
            }
            return View(pharmaviteCategory);
        }

        // GET: PharmaviteCategories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteCategory = await _context.PharmaviteCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (pharmaviteCategory == null)
            {
                return NotFound();
            }

            return View(pharmaviteCategory);
        }

        // POST: PharmaviteCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var pharmaviteCategory = await _context.PharmaviteCategories.FindAsync(id);
            _context.PharmaviteCategories.Remove(pharmaviteCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Dashbord");
        }

        private bool PharmaviteCategoryExists(decimal id)
        {
            return _context.PharmaviteCategories.Any(e => e.CategoryId == id);
        }
    }
}
