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
    public class PharmaviteProductsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PharmaviteProductsController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
          
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: PharmaviteProducts
        public async Task<IActionResult> Index()
        {
 
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var modelContext = _context.PharmaviteProducts.Include(p => p.CategoryIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteProducts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
             ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProduct = await _context.PharmaviteProducts
                .Include(p => p.CategoryIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (pharmaviteProduct == null)
            {
                return NotFound();
            }

            return View(pharmaviteProduct);
        }

        // GET: PharmaviteProducts/Create
        public IActionResult Create()
        {
            ViewBag.Role = HttpContext.Session.GetInt32("Role");

            ViewData["CategoryIdfk"] = new SelectList(_context.PharmaviteCategories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: PharmaviteProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryIdfk,ProductName,DateFrom,DateTo,Price,ProductDesc,ProductQuantity , ImageFile")] PharmaviteProduct pharmaviteProduct)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (ModelState.IsValid)
            {



                if (pharmaviteProduct.ImageFile != null)
                {
                    string upFile = Path.Combine(_hostEnvironment.WebRootPath, "CategoryImages");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + pharmaviteProduct.ImageFile.FileName;
                    string filePath = Path.Combine(upFile, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        pharmaviteProduct.ImageFile.CopyTo(fileStream);
                    }
                    pharmaviteProduct.Productimg = uniqueFileName;
                }
                else
                {
                    pharmaviteProduct.Productimg = "Drug.jpg";
                }



                _context.Add(pharmaviteProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index" , "Dashbord");
            }
            ViewData["CategoryIdfk"] = new SelectList(_context.PharmaviteCategories, "CategoryId", "CategoryName", pharmaviteProduct.CategoryIdfk);
            return View(pharmaviteProduct);
        }

        // GET: PharmaviteProducts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProduct = await _context.PharmaviteProducts.FindAsync(id);
            if (pharmaviteProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryIdfk"] = new SelectList(_context.PharmaviteCategories, "CategoryId", "CategoryName", pharmaviteProduct.CategoryIdfk);
            return View(pharmaviteProduct);
        }

        // POST: PharmaviteProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ProductId,CategoryIdfk,ProductName,DateFrom,DateTo,Price,ProductDesc,ProductQuantity ,ImageFile ")] PharmaviteProduct pharmaviteProduct)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id != pharmaviteProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                if (pharmaviteProduct.ImageFile != null)
                {
                    string upFile = Path.Combine(_hostEnvironment.WebRootPath, "CategoryImages");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + pharmaviteProduct.ImageFile.FileName;
                    string filePath = Path.Combine(upFile, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        pharmaviteProduct.ImageFile.CopyTo(fileStream);
                    }
                    pharmaviteProduct.Productimg = uniqueFileName;
                }
                else
                {
                    pharmaviteProduct.Productimg = "Drug.jpg";
                }




                try
                {
                    _context.Update(pharmaviteProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteProductExists(pharmaviteProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index" , "Dashbord");
            }
            ViewData["CategoryIdfk"] = new SelectList(_context.PharmaviteCategories, "CategoryId", "CategoryName", pharmaviteProduct.CategoryIdfk);
            return View(pharmaviteProduct);
        }

        // GET: PharmaviteProducts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProduct = await _context.PharmaviteProducts
                .Include(p => p.CategoryIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (pharmaviteProduct == null)
            {
                return NotFound();
            }

            return View(pharmaviteProduct);
        }

        // POST: PharmaviteProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var pharmaviteProduct = await _context.PharmaviteProducts.FindAsync(id);
            _context.PharmaviteProducts.Remove(pharmaviteProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index" , "Dashbord");
        }

        private bool PharmaviteProductExists(decimal id)
        {
            return _context.PharmaviteProducts.Any(e => e.ProductId == id);
        }
    }
}
