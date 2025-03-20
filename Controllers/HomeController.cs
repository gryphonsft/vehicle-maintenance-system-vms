using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspProject1.Models;

namespace AspProject1.Controllers;

public class HomeController : Controller
{
    
private readonly ApplicationDbContext _db;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Main()
    {
        if (HttpContext.Session.GetInt32("Id") == null)
        {

            return RedirectToAction("Login", "Hesap");
        }

        int toplamAraclarim = _db.Araclar.Count();
        int bakimTuruSayisi = _db.BakimFiyatlari.Count();
        int tamamlananBakim = _db.Islemler.Count();


        ViewBag.ToplamAraclarim = toplamAraclarim;
        ViewBag.BakimTuruSayisi = bakimTuruSayisi;
        ViewBag.TamamlananBakim = tamamlananBakim;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
