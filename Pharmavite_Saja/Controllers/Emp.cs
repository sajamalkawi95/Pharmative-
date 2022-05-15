using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmavite_Saja.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmavite_Saja.Controllers
{
    public class Emp : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Emp(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        public IActionResult Index()
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
            return View();
        }


        ///////////////////////////////////////
        ///

        public IActionResult Create()
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,Password ,ImageFile")] PharmaviteUser pharmaviteUser)
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
            if (ModelState.IsValid)
            {
                pharmaviteUser.RoleIdfk = 3;
                if (pharmaviteUser.ImageFile != null)
                {
                   
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + " " + pharmaviteUser.ImageFile.FileName;
                    string extension = Path.GetExtension(pharmaviteUser.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/EmpImages/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await pharmaviteUser.ImageFile.CopyToAsync(fileStream);
                    }
                    pharmaviteUser.Img = fileName;
                }
                else
                {
                    pharmaviteUser.Img = "user_avatar.jpg";
                }
                _context.Add(pharmaviteUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashbord");


            }

            return View();
        }

        /////////////////////////
        ///
            // GET: PharmaviteUsers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteUser = await _context.PharmaviteUsers.FindAsync(id);
            if (pharmaviteUser == null)
            {
                return NotFound();
            }
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleName", pharmaviteUser.RoleIdfk);
            return View(pharmaviteUser);
        }

        // POST: PharmaviteUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,RoleId,Password,ImageFile")] PharmaviteUser pharmaviteUser)
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
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
                return RedirectToAction("Index" , "Dashbord");
            }
            ViewData["RoleIdfk"] = new SelectList(_context.PharmaviteRoles, "RoleId", "RoleId", pharmaviteUser.RoleIdfk);
            return View(pharmaviteUser);
        }

        // GET: PharmaviteUsers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
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
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
            var pharmaviteUser = await _context.PharmaviteUsers.FindAsync(id);
            _context.PharmaviteUsers.Remove(pharmaviteUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashbord");
        }

        private bool PharmaviteUserExists(decimal id)
        {
            return _context.PharmaviteUsers.Any(e => e.UserId == id);
        }


        // GET: PharmaviteUsers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            TempData["Role"] = HttpContext.Session.GetInt32("Role");
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

    }



}
