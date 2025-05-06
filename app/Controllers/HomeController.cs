using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;

namespace app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var proyectos = ObtenerProyectos().Take(3).ToList();
        var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
        return View(modelo);
    }

    public List<Proyecto> ObtenerProyectos()
    {
        return new List<Proyecto>() {
            new Proyecto()
                {
                Titulo="Amazon",
                Descripcion="Amazon es una de las empresas más grandes del mundo",
                Link="http://amazon.com",
                ImagenUrl="~/img/amazin.png"
                },

                 new Proyecto()
                {
                Titulo="New York Time",
                Descripcion="Pagina de noticias en React",
                Link="https://www.nytimes.com/",
                ImagenUrl="~/img/nyt.png"
                },

                 new Proyecto()
                {
                Titulo="Reddit",
                Descripcion="Red social",
                Link="https://www.reddit.com/",
                ImagenUrl="~/img/reddit.png"
                },

                 new Proyecto()
                {
                Titulo="Steam",
                Descripcion="Amazon es una de las empresas más grandes del mundo",
                Link="https://store.steampowered.com/",
                ImagenUrl="~/img/steam.png"
                },
        };
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
