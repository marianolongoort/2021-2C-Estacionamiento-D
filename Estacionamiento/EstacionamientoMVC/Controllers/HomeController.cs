using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
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
            Persona persona1 = new Persona();
            persona1.Nombre = "Pedro";
            persona1.Apellido = "Picapiedra";

            Persona persona2 = new Persona() { Nombre = "Pablo", Apellido = "Marmol" };

            List<Persona> listaPersonas = new List<Persona>();
            listaPersonas.Add(persona1);
            listaPersonas.Add(persona2);

            return View(listaPersonas);
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
}

