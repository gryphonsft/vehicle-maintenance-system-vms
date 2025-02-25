using Microsoft.AspNetCore.Mvc;
using AspProject1.Models; // AraclarContext ve Araclar modeli burada
using System.Linq;

namespace AspProject1.Controllers
{
    public class AracController : Controller
    {
        private readonly AraclarContext _context;

       
        public AracController(AraclarContext context)
        {
            _context = context;
        }

       
        public IActionResult Giris()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Giris(Araclar arac)
        {
            if (ModelState.IsValid)
            {
                _context.Araclar.Add(arac);
                _context.SaveChanges();
                return RedirectToAction("Liste");
            }
            return View(arac);
        }


        public IActionResult Liste()
        {
            var araclar = _context.Araclar.ToList();


            return View(araclar);
        }

    }
}
