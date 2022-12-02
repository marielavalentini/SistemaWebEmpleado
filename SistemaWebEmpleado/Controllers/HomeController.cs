using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
