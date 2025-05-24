using System.Diagnostics;
using DynatraceWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynatraceWebApp.Controllers
{
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

        public IActionResult ThrowException()
        {
            throw new Exception("This is a test exception triggered intentionally!");
        }

        public IActionResult DivideByZero()
        {
            int zero = 0;
            int result = 5 / zero; // Will throw DivideByZeroException
            return Content($"Result: {result}");
        }

        public IActionResult NullReference()
        {
            string? str = null;
            int len = str.Length; // Will throw NullReferenceException
            return Content($"Length: {len}");
        }
        public IActionResult Http500()
        {
            return StatusCode(500, "Simulated Internal Server Error");
        }

        public async Task<IActionResult> Delay()
        {
            await Task.Delay(5000); // 5-second delay
            return Content("Response after delay");
        }

        public IActionResult LogWarning()
        {
            _logger.LogWarning("This is a test warning logged intentionally.");
            return Content("Warning logged.");
        }


        public IActionResult ThrowArgumentException()
        {
            throw new ArgumentException("Intentional argument exception.");
        }

    }
}
