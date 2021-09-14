using EstacionamientoMVC.Data;
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
        public EstacionamientoContext Bd { get; set; }

        public HomeController(EstacionamientoContext context)
        {
            Bd = context;
        }


        public IActionResult Index()
        {
            if (!Bd.Personas.Any()) //si no hay personas
            {
                //las creo y agrego
                Persona persona1 = new Persona();
                persona1.Nombre = "Pedro";
                persona1.Apellido = "Picapiedra";

                Persona persona2 = new Persona() { Nombre = "Pablo", Apellido = "Marmol" };

                //Estas dos personas, quiero pasarselas al ORM para que me las guarde
                Bd.Personas.Add(persona1);//agrego una persona
                Bd.Personas.Add(persona2);//agrego otra
                Bd.SaveChanges(); //guardo en la base de datos realmente.
            }


            List<Persona> personasEnDb = Bd.Personas.ToList();

            //Genero otra persona. Supervisor

            Persona supervisor = new Persona() { Nombre = "Vilma", Apellido = "Picapiedra" };
            supervisor.DNI = 4;

            ViewBag.Supervisor = supervisor;
            

            return View(personasEnDb);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }



}

