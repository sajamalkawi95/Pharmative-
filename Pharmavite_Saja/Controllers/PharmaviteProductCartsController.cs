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
    public class PharmaviteProductCartsController : Controller
    {
        private readonly ModelContext _context;

        public PharmaviteProductCartsController(ModelContext context)
        {
            _context = context;
        }

        // GET: PharmaviteProductCarts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.PharmaviteProductCarts.Include(p => p.OrderIdfkNavigation).Include(p => p.ProductIdfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteProductCarts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProductCart = await _context.PharmaviteProductCarts
                .Include(p => p.OrderIdfkNavigation)
                .Include(p => p.ProductIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ProductCartId == id);
            if (pharmaviteProductCart == null)
            {
                return NotFound();
            }

            return View(pharmaviteProductCart);
        }

        // GET: PharmaviteProductCarts/Create
        public IActionResult Create()
        {
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId");
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId");
            return View();
        }

        // POST: PharmaviteProductCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCartId,ProductIdfk,OrderIdfk")] PharmaviteProductCart pharmaviteProductCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteProductCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", pharmaviteProductCart.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", pharmaviteProductCart.ProductIdfk);
            return View(pharmaviteProductCart);
        }

        // GET: PharmaviteProductCarts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProductCart = await _context.PharmaviteProductCarts.FindAsync(id);
            if (pharmaviteProductCart == null)
            {
                return NotFound();
            }
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", pharmaviteProductCart.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", pharmaviteProductCart.ProductIdfk);
            return View(pharmaviteProductCart);
        }

        // POST: PharmaviteProductCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ProductCartId,ProductIdfk,OrderIdfk")] PharmaviteProductCart pharmaviteProductCart)
        {
            if (id != pharmaviteProductCart.ProductCartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteProductCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteProductCartExists(pharmaviteProductCart.ProductCartId))
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
            ViewData["OrderIdfk"] = new SelectList(_context.PharmaviteOrders, "OrderId", "OrderId", pharmaviteProductCart.OrderIdfk);
            ViewData["ProductIdfk"] = new SelectList(_context.PharmaviteProducts, "ProductId", "ProductId", pharmaviteProductCart.ProductIdfk);
            return View(pharmaviteProductCart);
        }

        // GET: PharmaviteProductCarts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProductCart = await _context.PharmaviteProductCarts
                .Include(p => p.OrderIdfkNavigation)
                .Include(p => p.ProductIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ProductCartId == id);
            if (pharmaviteProductCart == null)
            {
                return NotFound();
            }

            return View(pharmaviteProductCart);
        }

        // POST: PharmaviteProductCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pharmaviteProductCart = await _context.PharmaviteProductCarts.FindAsync(id);
            _context.PharmaviteProductCarts.Remove(pharmaviteProductCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteProductCartExists(decimal id)
        {
            return _context.PharmaviteProductCarts.Any(e => e.ProductCartId == id);
        }
    }
}
