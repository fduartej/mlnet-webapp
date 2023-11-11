using System.Diagnostics;
using ConsoleMLApp;
using Microsoft.AspNetCore.Mvc;
using mlnet_webapp.Models;

namespace mlnet_webapp.Controllers;

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

    public IActionResult Evaluate()
    {
        return View("MLTest/Index");
    }

    [HttpPost]
    public IActionResult Evaluate(Contacto objContacto)
    {
        var sampleData = new SentimentModel.ModelInput()
        {
            Col0 = objContacto.Name
        };

        // Load model and predict output of sample data
        var result = SentimentModel.Predict(sampleData);

        // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
        var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";

        ViewData["Message"] = string.Concat("El texto es  " , sentiment);
        return View("MLTest/Index");
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
