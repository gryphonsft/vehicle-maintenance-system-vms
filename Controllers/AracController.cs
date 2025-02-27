using Microsoft.AspNetCore.Mvc;
using AspProject1.Models; // AraclarContext ve Araclar modeli burada
using System.Linq;

namespace AspProject1.Controllers
{
    public class AracController : Controller
    {
        private readonly ApplicationDbContext _context;


        public AracController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
           
                return RedirectToAction("Login", "Hesap");
            }
            return View();
        }



        [HttpPost]
        public IActionResult AracEkle(Araclar arac)
        {
          
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Hesap");
               
            }
            if (ModelState.IsValid)
            {

                _context.Araclar.Add(arac);
                _context.SaveChanges();
                return RedirectToAction("Giris");

            }
            return View(arac);
        }


        public IActionResult Liste()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Hesap");
            }

            var araclar = _context.Araclar.ToList();
            return View(araclar);
        }
    

        public IActionResult Silme(int Id)
        {
          
            var arac = _context.Araclar.Find(Id);
            if (arac != null)

            {
                _context.Araclar.Remove(arac);
                _context.SaveChanges();
            }

            return RedirectToAction("Liste");
        }
        
        public IActionResult Bakim()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {

               

                return RedirectToAction("Login", "Hesap");
            }
            return View();
        }

    }
}
