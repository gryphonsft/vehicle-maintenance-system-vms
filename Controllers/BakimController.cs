using AspProject1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspProject1.Controllers
{
    public class BakimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BakimController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Bakim()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Hesap");
            }
            var bakimListesi = _context.BakimFiyatlari.ToList();
            return View(bakimListesi);
            
        }

        [HttpGet]
        public IActionResult BakimEkle()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Hesap");
            }
            return View();
        }
        [HttpPost]
        public IActionResult BakimEkle(BakimFiyatlari bakim)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Hesap");
            }
            if (ModelState.IsValid)
            {
                _context.BakimFiyatlari.Add(bakim);
                _context.SaveChanges();
                return RedirectToAction("Bakim");
            }
            return View(bakim);
            
        }
    }
}
