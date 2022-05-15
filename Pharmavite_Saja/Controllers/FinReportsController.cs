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
    public class FinReportsController : Controller
    {
        private readonly ModelContext _context;

        public FinReportsController(ModelContext context)
        {
            _context = context;
        }

        // GET: FinReports
        public async Task<IActionResult> Index()
        {

            var modelContext = _context.FinReports.Include(f => f.OrderIdfkNavigation).Include(f => f.ProductIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: FinReports/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finReport = await _context.FinReports
                .Include(f => f.OrderIdfkNavigation)
                .Include(f => f.ProductIdfkNavigation)
                .FirstOrDefaultAsync(m => m.RId == id);
            if (finReport == null)
            {
                return NotFound();
            }

            return View(finReport);
        }

        // GET: FinReports/Create
        public IActionResult Create()
        {
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId");
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId");
            return View();
        }

        // POST: FinReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RId,OrderIdfk,ProductName,ProductPrice,ProductOrderQty,Orderdate,Deleverddate,ProductIdfk")] FinReport finReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", finReport.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", finReport.ProductIdfk);
            return View(finReport);
        }

        // GET: FinReports/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finReport = await _context.FinReports.FindAsync(id);
            if (finReport == null)
            {
                return NotFound();
            }
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", finReport.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", finReport.ProductIdfk);
            return View(finReport);
        }

        // POST: FinReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("RId,OrderIdfk,ProductName,ProductPrice,ProductOrderQty,Orderdate,Deleverddate,ProductIdfk")] FinReport finReport)
        {
            if (id != finReport.RId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinReportExists(finReport.RId))
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
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", finReport.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", finReport.ProductIdfk);
            return View(finReport);
        }

        // GET: FinReports/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finReport = await _context.FinReports
                .Include(f => f.OrderIdfkNavigation)
                .Include(f => f.ProductIdfkNavigation)
                .FirstOrDefaultAsync(m => m.RId == id);
            if (finReport == null)
            {
                return NotFound();
            }

            return View(finReport);
        }

        // POST: FinReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var finReport = await _context.FinReports.FindAsync(id);
            _context.FinReports.Remove(finReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinReportExists(decimal id)
        {
            return _context.FinReports.Any(e => e.RId == id);
        }
    }
}
