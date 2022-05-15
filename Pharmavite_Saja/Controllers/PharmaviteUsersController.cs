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
    public class PharmaviteUsersController : Controller
    {
        private readonly ModelContext _context;

        public PharmaviteUsersController(ModelContext context)
        {
            _context = context;
        }
 

        // GET: PharmaviteUsers
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.PharmaviteUsers.Include(p => p.RoleIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteUsers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteUser = await _context.PharmaviteUsers
                .Include(p => p.RoleIdfkNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (pharmaviteUser == null)
            {
                return NotFound();
            }

            return View(pharmaviteUser);
        }

        // GET: PharmaviteUsers/Create
        public IActionResult Create()
        {
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleId");
            return View();
        }

        // POST: PharmaviteUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,RoleId,Password  ,ImageFile")] PharmaviteUser pharmaviteUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleId", pharmaviteUser.RoleIdfk);
            return View(pharmaviteUser);
        }

        // GET: PharmaviteUsers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteUser = await _context.PharmaviteUsers.FindAsync(id);
            if (pharmaviteUser == null)
            {
                return NotFound();
            }
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleId", pharmaviteUser.RoleIdfk);
            return View(pharmaviteUser);
        }

        // POST: PharmaviteUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,RoleId,Password,ImageFile")] PharmaviteUser pharmaviteUser)
        {
            if (id != pharmaviteUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteUserExists(pharmaviteUser.UserId))
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
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleId", pharmaviteUser.RoleIdfk);
            return View(pharmaviteUser);
        }

        // GET: PharmaviteUsers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteUser = await _context.PharmaviteUsers
                .Include(p => p.RoleIdfkNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (pharmaviteUser == null)
            {
                return NotFound();
            }

            return View(pharmaviteUser);
        }

        // POST: PharmaviteUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmaviteUser = await _context.PharmaviteUsers.FindAsync(id);
            _context.PharmaviteUsers.Remove(pharmaviteUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteUserExists(decimal id)
        {
            return _context.PharmaviteUsers.Any(e => e.UserId == id);
        }
    }
}
