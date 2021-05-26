using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BikeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeApp.Models.ForecastData;
using BikeApp.Services;

namespace BikeApp.Controllers
{
    public class HomeController : Controller
    {
        public RestService _rs { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _rs = new RestService();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult Weather()
        {
            return View();
        }
        public IActionResult WeatherF(string id )
        {
            string prova = "https://pro.openweathermap.org/data/2.5/forecast/hourly?q=" + id + "&units=metric&lang=pl&cnt=16&appid=de324c3839d438273b1d6f72b2298694";
            Root results = _rs.GetForecastData(prova).Result;


            return View(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
