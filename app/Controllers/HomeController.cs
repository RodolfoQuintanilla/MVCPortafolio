using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Servicios;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRespositorioProyectos repositorioProyectos;
    private readonly ServicioDelimitado servicioDelimitado;
    private readonly ServicioTransitorio servicioTransitorio;
    private readonly ServicioUnico servicioUnico;

    public HomeController(ILogger<HomeController> logger,
    IRespositorioProyectos repositorioProyectos,
    ServicioDelimitado servicioDelimitado,
    ServicioTransitorio servicioTransitorio,
    ServicioUnico servicioUnico
    )
    {
        this.repositorioProyectos = repositorioProyectos;
        this.servicioDelimitado = servicioDelimitado;
        this.servicioTransitorio = servicioTransitorio;
        this.servicioUnico = servicioUnico;
        _logger = logger;
    }

    public IActionResult Index()
    {

        var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
        var guiaViewModel = new EjemploGUIDViewModel()
        {
            Delimitado = servicioDelimitado.ObtenerGuid,
            Trancitorio = servicioTransitorio.ObtenerGuid,
            Unico = servicioUnico.ObtenerGuid
        };

        var modelo = new HomeIndexViewModel()
        {
            Proyectos = proyectos,
            EjemploGUID_1 = guiaViewModel

        };
        return View(modelo);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
