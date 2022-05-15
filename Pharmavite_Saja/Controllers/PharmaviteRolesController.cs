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
    public class PharmaviteRolesController : Controller
    {
        private readonly ModelContext _context;

        public PharmaviteRolesController(ModelContext context)
        {
            _context = context;
        }

        // GET: PharmaviteRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PharmaviteRoles.ToListAsync());
        }

        // GET: PharmaviteRoles/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteRole = await _context.PharmaviteRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (pharmaviteRole == null)
            {
                return NotFound();
            }

            return View(pharmaviteRole);
        }

        // GET: PharmaviteRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PharmaviteRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,RoleDesc")] PharmaviteRole pharmaviteRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmaviteRole);
        }

        // GET: PharmaviteRoles/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteRole = await _context.PharmaviteRoles.FindAsync(id);
            if (pharmaviteRole == null)
            {
                return NotFound();
            }
            return View(pharmaviteRole);
        }

        // POST: PharmaviteRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("RoleId,RoleName,RoleDesc")] PharmaviteRole pharmaviteRole)
        {
            if (id != pharmaviteRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteRoleExists(pharmaviteRole.RoleId))
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
            return View(pharmaviteRole);
        }

        // GET: PharmaviteRoles/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteRole = await _context.PharmaviteRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (pharmaviteRole == null)
            {
                return NotFound();
            }

            return View(pharmaviteRole);
        }

        // POST: PharmaviteRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmaviteRole = await _context.PharmaviteRoles.FindAsync(id);
            _context.PharmaviteRoles.Remove(pharmaviteRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteRoleExists(decimal id)
        {
            return _context.PharmaviteRoles.Any(e => e.RoleId == id);
        }
    }
}
