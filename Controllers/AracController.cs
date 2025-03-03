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
                arac.Plaka = arac.Plaka?.Replace(" ", "");
                arac.Marka = arac.Marka?.Replace(" ", "");
                arac.Model = arac.Model?.Replace(" ", "");               
                arac.Telefon = arac.Telefon?.Replace(" ", "");
                arac.MusteriAdi = arac.MusteriAdi?.Replace(" ","");

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
        public ActionResult Search(string searchString)
        {
            var araclar = _context.Araclar.AsQueryable();
            if(string.IsNullOrEmpty(searchString)){
                return RedirectToAction("Liste");
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                araclar = araclar.Where(a =>
                    (a.Plaka ?? "").Contains(searchString) ||
                    (a.Marka ?? "").Contains(searchString) ||
                    (a.Model ?? "").Contains(searchString) ||
                    (a.MusteriAdi ?? "").Contains(searchString));
            }
            var sonucListesi = araclar.ToList();
            if(!sonucListesi.Any()){
                ViewData["SonucYok"]="Aramanıza uygun araç bulunamadı.";
            }

            ViewData["SearchString"] = searchString;
            return View("Liste", araclar.ToList());
        }


    }
}
