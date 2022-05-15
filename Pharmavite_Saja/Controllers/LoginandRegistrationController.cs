using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmavite_Saja.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmavite_Saja.Controllers
{
    public class LoginandRegistrationController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LoginandRegistrationController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public IActionResult Regester()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(string email ,string pass)
        {
            var User = new PharmaviteUser() ;
            try
            {
            User = await _context.PharmaviteUsers.FirstAsync(user => user.Email == email && user.Password == pass );

            }catch(Exception e)
            {
                return View();
            }
            if (User != null)
            {
                if (User.RoleIdfk == 2)
                {
                    HttpContext.Session.SetString("UsaerName", User.UserName);
                    HttpContext.Session.SetInt32("UsaerId", (int)User.UserId);
                    ViewData["id"] = User.UserId;
                    TempData["id"] = User.UserId.ToString();

                    return RedirectToAction("Index", "Home" , User);
                    
                }
                else if (User.RoleIdfk == 1)
                {

                    HttpContext.Session.SetString("UsaerName", User.UserName);
                    HttpContext.Session.SetInt32("UsaerId", (int)User.UserId);
                    HttpContext.Session.SetInt32("Role", (int)User.RoleIdfk);

                    TempData["Role"] = "1";
                    TempData["id"] = User.UserId.ToString();
                    return RedirectToAction("Index", "Dashbord"  ); 
                }
                else if (User.RoleIdfk == 3)
                {
                    HttpContext.Session.SetString("UsaerName", User.UserName);
                    HttpContext.Session.SetInt32("UsaerId", (int)User.UserId);
                    HttpContext.Session.SetInt32("Role", (int)User.RoleIdfk);

                    TempData["Role"] = "3";
                    TempData["id"] = User.UserId.ToString();
                    return RedirectToAction("Index", "Dashbord");
                }   
            }

           return View();
        }

        [HttpPost]
         public async Task<IActionResult> Regester([Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,Password,ImageFile")] PharmaviteUser pharmaviteUser)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                pharmaviteUser.RoleIdfk = 2;
                if (pharmaviteUser.ImageFile != null)
                {
                    string upFile = Path.Combine(_hostEnvironment.WebRootPath, "UserImages");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + pharmaviteUser.ImageFile.FileName;
                    string filePath = Path.Combine(upFile, uniqueFileName);

                    using (var fileStream = new FileStream(filePath , FileMode.Create))
                    {
                        pharmaviteUser.ImageFile.CopyTo(fileStream);
                    }
                    pharmaviteUser.Img = uniqueFileName;
                    
                }
                else
                {
                    pharmaviteUser.Img = "user_avatar.jpg";
                }
                _context.Add(pharmaviteUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");


            }

            return View();
        }

 


    }
}
