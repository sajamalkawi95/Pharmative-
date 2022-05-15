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
    public class Dashbord : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Dashbord(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public ActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var AdminUsers = _context.PharmaviteUsers.Where(user => user.RoleIdfk == 2).ToList();
            var AdminCategory = _context.PharmaviteCategories.ToList();
            var AdminProducts = _context.PharmaviteProducts.ToList();
            var AdminEmp = _context.PharmaviteUsers.Where(emp => emp.RoleIdfk == 3).ToList();
            List<double> salesLastYear = SalesLastYear();
            return View(Tuple.Create(AdminUsers, AdminCategory, AdminProducts, AdminEmp , salesLastYear));
        }
        public async Task<IActionResult> Profile(decimal? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProfile = await _context.PharmaviteUsers.FindAsync(id);
            if (pharmaviteProfile == null)
            {
                return NotFound();
            }
            return View(pharmaviteProfile);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(decimal id, [Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,RoleId,Password,,ImageFile")] PharmaviteUser pharmaviteProfile)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            if (id != pharmaviteProfile.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmaviteProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaviteProfileExists(pharmaviteProfile.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Dashbord");
            }
            return View(pharmaviteProfile);
        }
        private bool PharmaviteProfileExists(decimal id)
        {
            return _context.PharmaviteUsers.Any(e => e.UserId == id);
        }

        public IActionResult Report()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            return View();
        }
        public IActionResult Reports()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            return View();
        }
        public List<double> SalesLastYear()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var orders = _context.FinReports.ToList();
            var lastYear = DateTime.Today.AddYears(-1).Year;
            List<double> yearSales = new List<double>();
            for(int month =1; month <=12; month++)
            {
                double monthSales = 0;

                var lastday = GetLastday(month, lastYear);
                DateTime dateTime1 = new DateTime(lastYear, month, 1);
                DateTime dateTime2 = new DateTime(lastYear, month, lastday);

               orders.Where(o => o.Orderdate >= dateTime1 && o.Orderdate <= dateTime2).ToList().ForEach(o => monthSales +=(double)( o.ProductOrderQty * o.ProductPrice));
                yearSales.Add(monthSales);
            }

            return yearSales;
        }

        public List<double> SalesYearBefor()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var orders = _context.FinReports.ToList();
            var lastYear = DateTime.Today.AddYears(-2).Year;
            List<double> yearSales = new List<double>();
            for (int month = 1; month <= 12; month++)
            {
                double monthSales = 0;
                orders.Where(o => o.Orderdate >= new DateTime(lastYear, month, 1) && o.Orderdate <= new DateTime(lastYear, month, GetLastday(month, lastYear))).ToList().ForEach(o => monthSales += (double)(o.ProductOrderQty * o.ProductPrice));
                yearSales.Add(monthSales);
            }

            return yearSales;
        }

        public List<double> SalesYearBefor2()
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            var orders = _context.FinReports.ToList();
            var lastYear = DateTime.Today.AddYears(-3).Year;
            List<double> yearSales = new List<double>();
            for (int month = 1; month <= 12; month++)
            {
                double monthSales = 0;
                orders.Where(o => o.Orderdate >= new DateTime(lastYear, month, 1) && o.Orderdate <= new DateTime(lastYear, month, 28)).ToList().ForEach(o => monthSales += (double)(o.ProductOrderQty * o.ProductPrice));
                yearSales.Add(monthSales);
            }

            return yearSales;
        }
        public int GetLastday(int month ,int year)
        {
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            int last =0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    last = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    last = 30;
                    break;
                case 2:
                    last = DateTime.IsLeapYear(year) ? 29 : 28;
                    break;
            }
            var x = last;
            return last;
        }

        [HttpGet]
        public ActionResult GetReport()
        {

            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            ViewBag.Role = HttpContext.Session.GetInt32("Role");
            DateTime dFirstDayOfThisMonth = DateTime.Today.AddDays( - ( DateTime.Today.Day - 1 ) );
            DateTime dLastDayOfLastMonth = dFirstDayOfThisMonth.AddDays (-1);
            DateTime dFirstDayOfLastMonth = dFirstDayOfThisMonth.AddMonths(-1);
           
 
             var lastMonth = _context.FinReports.Where(
                   o => o.Orderdate >= dFirstDayOfLastMonth );
            float totalSales = 0;
            lastMonth.ForEachAsync(e => totalSales +=(float) (e.ProductOrderQty * e.ProductPrice));
            string msg = totalSales.ToString();
           
            return Json(lastMonth);

        }

        ///// get data of all months of last year   
       
       
    }
}
