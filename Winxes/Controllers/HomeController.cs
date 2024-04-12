using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Winxes.Models;

namespace Winxes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Winx> winx = [];
        using (StreamReader leitor = new("Data\\winx.json"))
        {
            string dados = leitor.ReadToEnd();
            winx = JsonSerializer.Deserialize<List<Winx>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        ViewData["Tipos"] = tipos;
        return View(winx);
    }

public IActionResult Details(int id)
{
        List<Winx> winx = [];

        return View();
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
