using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proj.Models;

namespace proj.Controllers;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult About()
    {
        ViewBag.Name = "Jan";
        ViewBag.Time = DateTime.Now.Hour;
        ViewBag.WelcomeText = ViewBag.Time < 17 ? $"Dzień dobry" : "Dobry wieczór";

        Dane[] people = {
            new Dane { Name = "Jan", Lastname = "Nowak" },
            new Dane { Name = "Tom", Lastname = "Nowak" }
        };

        return View(people);
    }

    public IActionResult Birthdays(Birthday birthday)
    {
        ViewBag.WelcomeText = $"Wiataj {birthday.Name} masz {DateTime.Now.Year - birthday.Year}!";

        return View();
    }

    public IActionResult Calc(CalcData data)
    {
        switch (data.Operation)
        {
            case "+":
                ViewBag.Calculated = data.NumberOne + data.NumberTwo;
                break;
            case "-":
                ViewBag.Calculated = data.NumberOne - data.NumberTwo;
                break;
            case "*":
                ViewBag.Calculated = data.NumberOne * data.NumberTwo;
                break;
            case "/":
                ViewBag.Calculated = data.NumberOne / data.NumberTwo;
                break;
        }

        return View();
    }
}
