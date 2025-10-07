using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CalculadoraBin.Models;

namespace CalculadoraBin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET: /
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // POST: /Home/Calcular
    [HttpPost]
    public IActionResult Calcular(CalculadoraModel modelo)
    {
        if (!modelo.Validar(out string error))
        {
            ViewBag.Error = error;
            return View("Index", modelo);
        }

        modelo.CalcularOperaciones();
        return View("Resultado", modelo);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}