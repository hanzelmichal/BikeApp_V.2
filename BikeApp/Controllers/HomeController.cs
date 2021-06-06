﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BikeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BikeApp.Models.ForecastData;
using BikeApp.Services;
using Microsoft.AspNetCore.Identity;
using BikeApp.Areas.Identity.Data;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using BikeApp.Data;
using Microsoft.AspNet.Identity;

namespace BikeApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public INotyfService _notifyService { get; }
        public BikeAuthContext _context { get; set; }
        public RestService _rs { get; set; }
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, INotyfService notifyService, BikeAuthContext context, UserManager userManager)
        {
            _rs = new RestService();
            _logger = logger;
            _notifyService = notifyService;
            _context = context;
            _userManager = userManager;
        }
            public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Maps()
        {
            _notifyService.Custom("Correct data download", 5, "#1EB980", "fa fa-home");
            return View();
        }

        public IActionResult Weather()
        {
            return View();
        }
        public IActionResult Result(LocationModel location)
        {
            return RedirectToAction("WeatherF", "Home", new { lat = Math.Round(location.Latitude, 3), lon = Math.Round(location.Longitude, 3) });
        }
        public IActionResult WeatherF(double lat, double lon, string id, LocationModel location)
        {
            _notifyService.Custom("Correct data download", 5, "#1EB980", "fa fa-home");
            if (id == null)
            {
                string prova = "https://pro.openweathermap.org/data/2.5/forecast/hourly?lat=" + lat + "&lon=" + lon + "&units=metric&appid=de324c3839d438273b1d6f72b2298694";
                Root results = _rs.GetForecastData(prova).Result;
                return View(results);

            }
            else
            {
                string prova = "https://pro.openweathermap.org/data/2.5/forecast/hourly?q=" + id + "&units=metric&appid=de324c3839d438273b1d6f72b2298694";
                Root results = _rs.GetForecastData(prova).Result;
                return View(results);
            }
        }
        [Authorize]
        public IActionResult Logout()
        {
            _notifyService.Custom("Succes logout", 5, "#1EB980", "fa fa-home");
            return View();
        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _notifyService.Custom("Some unknown problem ", 5, "#FF6859", "fa fa-home");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult AddRoute(UserRoute userRoute)
        {
            _context.UserRoute.Add(userRoute);
            return RedirectToAction(nameof(Maps));
        }
    }
}
