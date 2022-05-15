using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmavite_Saja.Models;

namespace Pharmavite_Saja.Controllers
{
    public class PharmaviteOrdersController : Controller
    {
        private readonly ModelContext _context;

        public PharmaviteOrdersController(ModelContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OrdersInRang(DateTime start , DateTime end ) 
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var modelOrders = _context.PharmaviteOrders.
                Where(order =>  order.OrderStartDate >= start && order.OrderStartDate <= end);
            return View(nameof(Index) , await modelOrders.ToListAsync());
        }

        // GET: PharmaviteOrders
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var modelContext = _context.PharmaviteOrders.Include(p => p.UserIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteOrders/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteOrder = await _context.PharmaviteOrders
                .Include(p => p.UserIdfkNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (pharmaviteOrder == null)
            {
                return NotFound();
            }

            return View(pharmaviteOrder);
        }

        // GET: PharmaviteOrders/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            ViewData["UserIdfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId");
            return View();
        }

        // POST: PharmaviteOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserIdfk,ProductQty,ProductStatus,OrderStartDate,DeleverdDate")] PharmaviteOrder pharmaviteOrder)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserIdfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId", pharmaviteOrder.UserIdfk);
            return View(pharmaviteOrder);
        }

        // GET: PharmaviteOrders/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteOrder = await _context.PharmaviteOrders.FindAsync(id);
            if (pharmaviteOrder == null)
            {
                return NotFound();
            }
            ViewData["UserIdfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId", pharmaviteOrder.UserIdfk);
            return View(pharmaviteOrder);
        }

        // POST: PharmaviteOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderId,UserIdfk,ProductQty,ProductStatus,OrderStartDate,DeleverdDate")] PharmaviteOrder pharmaviteOrder)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id != pharmaviteOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteOrderExists(pharmaviteOrder.OrderId))
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
            ViewData["UserIdfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId", pharmaviteOrder.UserIdfk);
            return View(pharmaviteOrder);
        }

        // GET: PharmaviteOrders/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteOrder = await _context.PharmaviteOrders
                .Include(p => p.UserIdfkNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (pharmaviteOrder == null)
            {
                return NotFound();
            }

            return View(pharmaviteOrder);
        }

        // POST: PharmaviteOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmaviteOrder = await _context.PharmaviteOrders.FindAsync(id);
            _context.PharmaviteOrders.Remove(pharmaviteOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteOrderExists(decimal id)
        {
            return _context.PharmaviteOrders.Any(e => e.OrderId == id);
        }
    }
}
