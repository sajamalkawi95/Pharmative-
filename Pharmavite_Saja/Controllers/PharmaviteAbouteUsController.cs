using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmavite_Saja.Models;

namespace Pharmavite_Saja.Controllers
{
    public class PharmaviteAbouteUsController : Controller
    {
        private readonly ModelContext _context;

        public PharmaviteAbouteUsController(ModelContext context)
        {
            _context = context;
        }

        // GET: PharmaviteAbouteUs
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.PharmaviteAbouteUs.Include(p => p.WebsiteIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteAbouteUs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteAbouteU = await _context.PharmaviteAbouteUs
                .Include(p => p.WebsiteIdfkNavigation)
                .FirstOrDefaultAsync(m => m.AbouteId == id);
            if (pharmaviteAbouteU == null)
            {
                return NotFound();
            }

            return View(pharmaviteAbouteU);
        }

        // GET: PharmaviteAbouteUs/Create
        public IActionResult Create()
        {
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite");
            return View();
        }

        // POST: PharmaviteAbouteUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbouteId,Aboute1,Aboute2,WebsiteIdfk")] PharmaviteAbouteU pharmaviteAbouteU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteAbouteU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmaviteAbouteU.WebsiteIdfk);
            return View(pharmaviteAbouteU);
        }

        // GET: PharmaviteAbouteUs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteAbouteU = await _context.PharmaviteAbouteUs.FindAsync(id);
            if (pharmaviteAbouteU == null)
            {
                return NotFound();
            }
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmaviteAbouteU.WebsiteIdfk);
            return View(pharmaviteAbouteU);
        }

        // POST: PharmaviteAbouteUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AbouteId,Aboute1,Aboute2,WebsiteIdfk")] PharmaviteAbouteU pharmaviteAbouteU)
        {
            if (id != pharmaviteAbouteU.AbouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteAbouteU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteAbouteUExists(pharmaviteAbouteU.AbouteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmaviteAbouteU.WebsiteIdfk);
            return View(pharmaviteAbouteU);
        }

        // GET: PharmaviteAbouteUs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteAbouteU = await _context.PharmaviteAbouteUs
                .Include(p => p.WebsiteIdfkNavigation)
                .FirstOrDefaultAsync(m => m.AbouteId == id);
            if (pharmaviteAbouteU == null)
            {
                return NotFound();
            }

            return View(pharmaviteAbouteU);
        }

        // POST: PharmaviteAbouteUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmaviteAbouteU = await _context.PharmaviteAbouteUs.FindAsync(id);
            _context.PharmaviteAbouteUs.Remove(pharmaviteAbouteU);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteAbouteUExists(decimal id)
        {
            return _context.PharmaviteAbouteUs.Any(e => e.AbouteId == id);
        }
    }
}
