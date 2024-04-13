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
        List<Winx> winx = GetWinx();
        List<Tipo> tipos = GetTipos();
        ViewData["Tipos"] = tipos;
        return View(winx);
    }

    public IActionResult Details(int id)
    {
        List<Winx> winx = GetWinx();
        List<Tipo> tipos = GetTipos();
        DetailsVM details = new() {
            Tipos = tipos;
            Atual = winx.FirstOrDefault(p => p.Numero == id),
            Anterior = winx.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = winx.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Winx> GetWinx()
    {
        using (StreamReader leitor = new("Data\\winx.json"))
        {
            string dado = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Winx>> (dados);
        }
    }

    private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
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
