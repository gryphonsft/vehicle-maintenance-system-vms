using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
 // Projendeki namespace'i uygun şekilde değiştir
using AspProject1.Models;

public class IslemController : Controller
{
    private readonly ApplicationDbContext _context;

    public IslemController(ApplicationDbContext context)
    {
        _context = context;
    }

    // İşlem Sayfası
    [HttpGet]
public async Task<IActionResult> Index()
{
    if (HttpContext.Session.GetInt32("Id") == null)
    {
        return RedirectToAction("Login", "Hesap");
    }

    // Araclar ile ilişkili Islemler ve her Islem için BakimFiyatları'na eager loading
    var model = new IslemViewModel
    {
        Araclar = await _context.Araclar.ToListAsync(),
        BakimFiyatlari = await _context.BakimFiyatlari.ToListAsync(),
        Islemler = await _context.Islemler
            .Include(i => i.Arac)  // Arac'ı dahil et
            .Include(i => i.BakimFiyat)  // BakimFiyat'ı dahil et
            .ToListAsync()  // Islemleri listele
    };

    return View(model);
}

    // İşlem Kaydetme
    [HttpPost]
    public async Task<IActionResult> Ekle(int aracID, int bakimID, string islemNotu)
    {
        if (HttpContext.Session.GetInt32("Id") == null)
        {
            return RedirectToAction("Login", "Hesap");
        }
        if (aracID == 0 || bakimID == 0)
        {
            return RedirectToAction("Index");
        }

        var islem = new Islemler
        {
            AracID = aracID,
            BakimID = bakimID,
            IslemNotu = islemNotu
        };

        _context.Islemler.Add(islem);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
