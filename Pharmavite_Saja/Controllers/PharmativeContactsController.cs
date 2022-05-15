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
    public class PharmativeContactsController : Controller
    {
        private readonly ModelContext _context;

        public PharmativeContactsController(ModelContext context)
        {
            _context = context;
        }

        // GET: PharmativeContacts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.PharmativeContacts.Include(p => p.WebsiteIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmativeContacts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmativeContact = await _context.PharmativeContacts
                .Include(p => p.WebsiteIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (pharmativeContact == null)
            {
                return NotFound();
            }

            return View(pharmativeContact);
        }

        // GET: PharmativeContacts/Create
        public IActionResult Create()
        {
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite");
            return View();
        }

        // POST: PharmativeContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,WebsiteIdfk,PhoneNumber,Email,FbAccaunt,LiAccaunt,InstaAccaunt")] PharmativeContact pharmativeContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmativeContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmativeContact.WebsiteIdfk);
            return View(pharmativeContact);
        }

        // GET: PharmativeContacts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmativeContact = await _context.PharmativeContacts.FindAsync(id);
            if (pharmativeContact == null)
            {
                return NotFound();
            }
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmativeContact.WebsiteIdfk);
            return View(pharmativeContact);
        }

        // POST: PharmativeContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ContactId,WebsiteIdfk,PhoneNumber,Email,FbAccaunt,LiAccaunt,InstaAccaunt")] PharmativeContact pharmativeContact)
        {
            if (id != pharmativeContact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmativeContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmativeContactExists(pharmativeContact.ContactId))
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
            ViewData["WebsiteIdfk"] = new SelectList(_context.PharmaviteWebsites, "IdPharmavite", "IdPharmavite", pharmativeContact.WebsiteIdfk);
            return View(pharmativeContact);
        }

        // GET: PharmativeContacts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmativeContact = await _context.PharmativeContacts
                .Include(p => p.WebsiteIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (pharmativeContact == null)
            {
                return NotFound();
            }

            return View(pharmativeContact);
        }

        // POST: PharmativeContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmativeContact = await _context.PharmativeContacts.FindAsync(id);
            _context.PharmativeContacts.Remove(pharmativeContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmativeContactExists(decimal id)
        {
            return _context.PharmativeContacts.Any(e => e.ContactId == id);
        }
    }
}
