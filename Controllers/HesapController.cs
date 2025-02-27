using Microsoft.AspNetCore.Mvc;
using AspProject1.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace AspProject1.Controllers
{
    public class HesapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HesapController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Register(Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                _context.Kisiler.Add(kisiler);
                _context.SaveChanges();
                return RedirectToAction("Login"); 
            }
            return View(kisiler);
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Kisiler.SingleOrDefault(u => u.Username == kisiler.Username && u.Password == kisiler.Password);

                if (user != null)
                {
                  
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);

                   

                    return RedirectToAction("Main", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
                }
            }
            return View(kisiler);
        }





        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
