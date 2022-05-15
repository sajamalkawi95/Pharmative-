using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pharmavite_Saja.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pharmavite_Saja.Controllers
{
    public class HomeController : Controller
    {
         private readonly ModelContext _context;

        public HomeController(ModelContext context)
        {
             _context = context;
        }



        [HttpGet]
        public async Task<ActionResult> Index ()
        {

            TempData["name"] = HttpContext.Session.GetString("UsaerName");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            

            var webSite = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            var categoriese =   _context.PharmaviteCategories.ToList();
            var abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            var testimonial =   _context.PharmaviteTestimonials.ToList();
            var contact = await _context.PharmativeContacts.FindAsync((decimal)1);
            var product =   _context.PharmaviteProducts.ToList();

            ViewData["website"] = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewData["abouteUs"] = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewData["contact"] = await _context.PharmativeContacts.FindAsync((decimal)1);
            var test =  _context.PharmaviteTestimonials.ToList();

            return View(Tuple.Create(webSite , categoriese , abouteUs , testimonial , contact , product , test));
        }

        public async Task<IActionResult> UserProfile(decimal? id)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");

            if (id == null)
            {
                return NotFound();
            }

            var pharmaviteProfile = await _context.PharmaviteUsers.FindAsync(id);
            if (pharmaviteProfile == null)
            {
                return NotFound();
            }


            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);

            return View(pharmaviteProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserProfile (decimal id, [Bind("UserId,RoleIdfk,UserName,Img,PhoneNumber,Email,Bod,Address,RoleId,Password,,ImageFile")] PharmaviteUser pharmaviteProfile)
        {
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
return RedirectToAction(nameof(Index), "Home");
            }
            return View(pharmaviteProfile);
        }
        private bool PharmaviteProfileExists(decimal id)
{
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");


            ViewBag.website =  _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs =  _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact =  _context.PharmativeContacts.FindAsync((decimal)1);


            return _context.PharmaviteUsers.Any(e => e.UserId == id);
}


[HttpGet]
        public async Task<IActionResult> ProductsAsync(int id)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");

            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");


            if (TempData["id"] == null)
            {
                TempData["UserName"] = "non".ToString();
            }


            var product = (id == 0) ? _context.PharmaviteProducts.ToList()
                 : _context.PharmaviteProducts.Where(product => product.CategoryIdfk == id).ToList();

            var Cat =  _context.PharmaviteCategories.ToList();
            ViewBag.Category = Cat ;


            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);


            return View(product);
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Order (decimal? id)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");


            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);

            if (id == null)
            {
                return NotFound();
            }

            var categoryId = _context.PharmaviteProducts.Find(id).CategoryIdfk;

            if(TempData["id"] == null)
            {
                TempData["UserName"] = "non".ToString();
                return RedirectToAction("Products", "Home" , -1);
            }
            var pharmaviteProduct = await _context.PharmaviteProducts
                .Include(p => p.CategoryIdfkNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            var pharmaviteOrder =  _context.PharmaviteOrders.ToList();
        //    ViewData["UserAdminfk"] = new SelectList(_context.PharmaviteUsers)
            if (pharmaviteProduct == null)
            {
                return NotFound();
            }
            ViewBag.Products =  _context.PharmaviteProducts.ToList();
            return View( pharmaviteProduct  );
        }
     
        [HttpPost]
      
        public async  Task<ActionResult> OrdersAsync (Order2Model order)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = order.UserId;

            var userId = HttpContext.Session.GetInt32("UsaerId");

            PharmaviteOrder pharmaviteOrder = new PharmaviteOrder(order.UserId, order.Qty, order.Sts);
            _context.Add(pharmaviteOrder);
            await _context.SaveChangesAsync();

            PharmaviteProductCart Cart = new PharmaviteProductCart();
            Cart.OrderIdfk = _context.PharmaviteOrders.OrderByDescending(p => p.OrderId).FirstOrDefault().OrderId;
            var lastCart = _context.PharmaviteProductCarts.OrderByDescending(p => p.ProductCartId).FirstOrDefault();
            Cart.ProductCartId = lastCart != null ? lastCart.ProductCartId + 1 : 0;
            Cart.ProductIdfk = order.productId;
            _context.Add(Cart);
             await _context.SaveChangesAsync();




            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);


            return RedirectToAction("Cart", "Home", new { @id = order.UserId });
        }

        public class Order2Model
        {
             public int UserId { get; set; }
            public int productId { get; set; }
            public string Sts { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime delDate { get; set; }
            public int Qty { get; set; }
        }

        public async Task<IActionResult> CartAsync(int id)
        {
            var cart = _context.PharmaviteProductCarts.Include(p => p.OrderIdfkNavigation).Include(p => p.ProductIdfkNavigation);


            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            var userId = HttpContext.Session.GetInt32("UsaerId");
            var order = _context.PharmaviteOrders.Where(order => order.UserIdfk == userId);


            var products = _context.PharmaviteProducts;

            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);

            return View(Tuple.Create(await cart.ToListAsync(), await order.ToListAsync(), await products.ToListAsync()));

        }

        public async Task<ActionResult> Checkout (int card_number ,int userId , int total)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");
            var cart =  _context.PharmaviteProductCarts;
 
            var userCard = _context.PharmaviteCards.Where(num => num.Cardnumber.Equals((decimal)card_number)).FirstOrDefault();

            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);


            List<FinReport> bill = new List<FinReport>();
            if (userCard != null )
            {
                if((decimal)total < userCard.Balanc)
                {
                    foreach (var item in cart)
                    {
                        var product = _context.PharmaviteProducts.Find(item.ProductIdfk);
                        var order = _context.PharmaviteOrders.Find(item.OrderIdfk);
                         var fR = _context.FinReports.OrderByDescending(p => p.RId).FirstOrDefault();
                        var id = fR != null ? fR.RId + 1 : 0;
                        if (order.UserIdfk == (decimal)userId)
                        {
                            FinReport finReport = new FinReport
                            {
                                RId = id ,
                                OrderIdfk = order.OrderId,
                                ProductName = product.ProductName,
                                ProductIdfk = product.ProductId,
                                ProductPrice = product.Price,
                                ProductOrderQty = order.ProductQty,

                                Orderdate = DateTime.Today
                            };

                            _context.Add(finReport);
                            bill.Add(finReport);

                            _context.SaveChanges();

                            product.ProductQuantity -= order.ProductQty;
                            _context.Update(product);
                            _context.SaveChanges();

                        }
                        _context.PharmaviteOrders.Remove(order);
                        _context.SaveChanges();

                        _context.PharmaviteProductCarts.Remove(item);
                        _context.SaveChanges();

                    }
                    userCard.Balanc -= total;
                    _context.Update(userCard);
                    _context.SaveChanges();

                }
                else
                {
                    ViewData["Msg"] = "Your Balance is Less than the total .. =< ";
                }

            }
            else
            {
                ViewData["Msg"] = "Invaled card Number .. =< ";
            }


            if(ViewData["Msg"] != null)
            {
                var carts = _context.PharmaviteProductCarts.Include(p => p.OrderIdfkNavigation).Include(p => p.ProductIdfkNavigation);


                ViewBag.name = HttpContext.Session.GetString("UsaerName");
                ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
                var user_Id = HttpContext.Session.GetInt32("UsaerId");
                var order = _context.PharmaviteOrders.Where(order => order.UserIdfk == userId);


                var products = _context.PharmaviteProducts;


                return View( "Cart" ,Tuple.Create(await cart.ToListAsync(), await order.ToListAsync(), await products.ToListAsync()));
            }


            return View("UserInvoce" , bill);
        }



        public async Task<ActionResult> UserInvoceAsync(object obj)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");


            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);


            return View(obj);
        }

        public async Task<ActionResult> SerchResultAsync(string searchTxt)
        {
            ViewBag.name = HttpContext.Session.GetString("UsaerName");
            ViewBag.id = HttpContext.Session.GetInt32("UsaerId");
            TempData["id"] = HttpContext.Session.GetInt32("UsaerId");


            ViewBag.website = await _context.PharmaviteWebsites.FindAsync((decimal)1);
            ViewBag.abouteUs = await _context.PharmaviteAbouteUs.FindAsync((decimal)1);
            ViewBag.contact = await _context.PharmativeContacts.FindAsync((decimal)1);

           
         var categorys = _context.PharmaviteCategories.Where(c => c.CategoryName.ToUpper().Contains(searchTxt.ToUpper()));
             return View(categorys);
        }

   
    }
}
