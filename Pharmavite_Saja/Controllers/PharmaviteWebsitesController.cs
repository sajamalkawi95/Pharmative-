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
    public class PharmaviteWebsitesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PharmaviteWebsitesController(ModelContext context ,  IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: PharmaviteWebsites
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var modelContext = _context.PharmaviteWebsites.Include(p => p.UserAdminfkNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: PharmaviteWebsites/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteWebsite = await _context.PharmaviteWebsites
                .Include(p => p.UserAdminfkNavigation)
                .FirstOrDefaultAsync(m => m.IdPharmavite == id);
            if (pharmaviteWebsite == null)
            {
                return NotFound();
            }

            return View(pharmaviteWebsite);
        }

        // GET: PharmaviteWebsites/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            ViewData["UserAdminfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId");
            return View();
        }

        // POST: PharmaviteWebsites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPharmavite,WebsiteName,WebsiteLogo1,WebsiteLogo2,WebsiteHeroimg,UserAdminfk,WebsiteWallet,WebsiteHeroimg2,WebsiteHeroimg3,WebsiteDesc")] PharmaviteWebsite pharmaviteWebsite)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (ModelState.IsValid)
            {
                _context.Add(pharmaviteWebsite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserAdminfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserName", pharmaviteWebsite.UserAdminfk);
            return View(pharmaviteWebsite);
        }

        // GET: PharmaviteWebsites/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteWebsite = await _context.PharmaviteWebsites.FindAsync(id);
            var aboutus = await _context.PharmaviteAbouteUs.FindAsync(id);
            var contactInfo = await _context.PharmativeContacts.FindAsync(id);
            if (pharmaviteWebsite == null)
            {
                return NotFound();
            }
            ViewData["UserAdminfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId", pharmaviteWebsite.UserAdminfk);
            return View(Tuple.Create(pharmaviteWebsite , aboutus , contactInfo));
        }

        // POST: PharmaviteWebsites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("IdPharmavite,WebsiteName,WebsiteLogo1,WebsiteLogo2,WebsiteHeroimg,UserAdminfk,WebsiteWallet,WebsiteHeroimg2,WebsiteHeroimg3,WebsiteDesc ,LogoFile ,HeroFile , HeroFile2 , HeroFile3")] PharmaviteWebsite pharmaviteWebsite , string aboute1 , string aboute2 , PharmaviteAbouteU pharmaviteAbouteU)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");


            if (ModelState.IsValid)
            {
                try
                {
                    if(pharmaviteWebsite.LogoFile != null && pharmaviteWebsite.HeroFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string logoName = Guid.NewGuid().ToString() + "_" +
                        pharmaviteWebsite.LogoFile.FileName;
                    
                        string hero1Name = Guid.NewGuid().ToString() + "_" +
                        pharmaviteWebsite.HeroFile.FileName;

                        string hero2Name = Guid.NewGuid().ToString() + "_" +
                       pharmaviteWebsite.HeroFile2.FileName;

                        string hero3Name = Guid.NewGuid().ToString() + "_" +
                       pharmaviteWebsite.HeroFile3.FileName;

                        string logoPath = Path.Combine(wwwRootPath + "/webImages/", logoName);
                        using (var fileStream = new FileStream(logoPath, FileMode.Create))
                        {
                            await pharmaviteWebsite.LogoFile.CopyToAsync(fileStream);
                        }

                        string hero1Path = Path.Combine(wwwRootPath + "/webImages/", hero1Name);
                        using (var fileStream = new FileStream(hero1Path, FileMode.Create))
                        {
                            await pharmaviteWebsite.HeroFile.CopyToAsync(fileStream);
                        }

                        string hero2Path = Path.Combine(wwwRootPath + "/webImages/", hero2Name);
                        using (var fileStream = new FileStream(hero2Path, FileMode.Create))
                        {
                            await pharmaviteWebsite.HeroFile2.CopyToAsync(fileStream);
                        }

                        string hero3Path = Path.Combine(wwwRootPath + "/webImages/", hero3Name);
                        using (var fileStream = new FileStream(hero2Path, FileMode.Create))
                        {
                            await pharmaviteWebsite.HeroFile3.CopyToAsync(fileStream);
                        }


                        pharmaviteWebsite.WebsiteLogo1 = logoName;
                        pharmaviteWebsite.WebsiteHeroimg = hero2Name;
                        pharmaviteWebsite.WebsiteHeroimg2 = hero2Name;
                        pharmaviteWebsite.WebsiteHeroimg3 = hero3Name;
                        pharmaviteAbouteU.Aboute1 = aboute1;
                        pharmaviteAbouteU.Aboute2 = aboute2;
                    }
                    _context.Update(pharmaviteWebsite);
                    await _context.SaveChangesAsync();

                    _context.Update(pharmaviteAbouteU);


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteWebsiteExists(pharmaviteWebsite.IdPharmavite))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index) , nameof(Dashbord));
            }
            ViewData["UserAdminfk"] = new SelectList(_context.PharmaviteUsers, "UserId", "UserId", pharmaviteWebsite.UserAdminfk);
            return View(pharmaviteWebsite);
        }

        // GET: PharmaviteWebsites/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteWebsite = await _context.PharmaviteWebsites
                .Include(p => p.UserAdminfkNavigation)
                .FirstOrDefaultAsync(m => m.IdPharmavite == id);
            if (pharmaviteWebsite == null)
            {
                return NotFound();
            }

            return View(pharmaviteWebsite);
        }

        // POST: PharmaviteWebsites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var pharmaviteWebsite = await _context.PharmaviteWebsites.FindAsync(id);
            _context.PharmaviteWebsites.Remove(pharmaviteWebsite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaviteWebsiteExists(decimal id)
        {
            return _context.PharmaviteWebsites.Any(e => e.IdPharmavite == id);
        }
    }
}
