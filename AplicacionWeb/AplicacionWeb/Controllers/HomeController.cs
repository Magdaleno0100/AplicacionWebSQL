using AplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Adopta";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Mascota mascota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Mascota sdb = new DAL.Mascota();
                    if (sdb.AgregarMascota(mascota))
                    {
                        ViewBag.Message = "Gracias por registrar a " + mascota.Nombre;
                        ModelState.Clear();
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Error al registrar mascota";
            }
            
            return View();
        }

        public ActionResult Adoptar()
        {
            ViewBag.Message = "Bienvenido, encuentra tu mascota ideal";
            DAL.Mascota sdb = new DAL.Mascota();
            List<Mascota> mascotas = sdb.ObtenerMascotas();
            return View(mascotas);
        }

    }
}