using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Servicios;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRespositorioProyectos repositorioProyectos;


    public HomeController(ILogger<HomeController> logger,
    IRespositorioProyectos repositorioProyectos,
    IConfiguration configuracionXXX
    )
    {
        this.repositorioProyectos = repositorioProyectos;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

        var modelo = new HomeIndexViewModel()
        {
            Proyectos = proyectos,

        };
        return View(modelo);
    }

    public IActionResult Proyectos()
    {
        var proyectos = repositorioProyectos.ObtenerProyectos();

        return View(proyectos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contacto()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Contacto(ContactoViewModel contactoViewModel)
    {
        return RedirectToAction("Gracias");
    }

public IActionResult Gracias(){
    return View();
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
