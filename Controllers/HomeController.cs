using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIFHA_WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SIFHA_WEB.Models.Conexion;

namespace SIFHA_WEB.Controllers
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
            if (HttpContext.Session.GetString("N_usuario") == null)
            {
                return Redirect("~/login/Login");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("N_usuario") == null)
            {
                return Redirect("~/login/Login");
            }

            
            return View();
        }

        public ActionResult Salir()
        {
            HttpContext.Session.Clear();
            return Redirect("~/login/login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
