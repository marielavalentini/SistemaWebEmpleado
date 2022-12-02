using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;
using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoDBContext : DbContext
    {
        public EmpleadoDBContext(DbContextOptions<EmpleadoDBContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPCIONAL PARA INICIALIZAR DATOS EN LA BASE DE DATOS
            //INICIALIZA LA TABLA PERSONA CON DOS INSTANCIAS

            modelBuilder.Entity<Empleado>().HasData(
               new Empleado
               {
                   EmpleadoId = 1,
                   Nombre = "Alfonso",
                   Apellido = "Hutcher",
                   DNI = "42167241",
                   Legajo = "AA12345",
                   Titulo= "Administrativo" 
               },
               new Empleado
               {
                   EmpleadoId = 2,
                   Nombre = "Juan",
                   Apellido = "Perez",
                   DNI = "12345678",
                   Legajo = "AA34567",
                   Titulo = "Operario"
               },
               new Empleado
               { 
                   EmpleadoId = 3,
                   Nombre = "Maria",
                   Apellido = "Lopez",
                   DNI = "34571291",
                   Legajo = "AA98765",
                   Titulo = "Administrativo"
               });
        }
    }
}

