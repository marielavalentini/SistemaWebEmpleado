using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoDBContext _context;

        public EmpleadoController(EmpleadoDBContext context)
        {
            _context = context;
        }
        // GET: /empleado
        public ActionResult Index()
        {
            return View("Index", _context.Empleados.ToList());
        }

    
        [HttpGet("/empleado/ListarPorTitulo/{titulo}")]
        //GET: /empleado/listarPorTitulo/titulo
        public IActionResult ListarPorTitulo(string titulo)
        {
            List<Empleado> lista = (from e in _context.Empleados
                                  where e.Titulo == titulo
                                  select e).ToList();
            return View("Index", lista);
        }

        //GET: /empleado/insertar
        public ActionResult Insertar()
        {
            Empleado empleado = new Empleado();
            return View("Insertar", empleado);
        }

        //POST: /empleado/insertar
        [HttpPost]

        public ActionResult Insertar(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Insertar", empleado);
            }
            else
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: /empleado/detalle/id

        [HttpGet]
        [ActionName("Detalle")]

        public ActionResult Detalle(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado != null)
            {
                return View("Detalle", empleado);
            }
            else
            {
                return NotFound();
            }
        }

        //GET: empleado/delete/id

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();

            }
            return View("Delete", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]

        //POST: /empleado/DeleteConfirmed/id

        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("/empleado/Modificar/{EmpleadoId}")]
        
        public ActionResult Modificar(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Modificar", empleado);
            }
        }

        [HttpPost]

        public ActionResult Modificar(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Modificar", empleado);
            }
            else
            {
                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return View("Index", empleado);
            }
        }
    }
}
