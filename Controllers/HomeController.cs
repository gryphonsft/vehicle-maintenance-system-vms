using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspProject1.Models;

namespace AspProject1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
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
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
