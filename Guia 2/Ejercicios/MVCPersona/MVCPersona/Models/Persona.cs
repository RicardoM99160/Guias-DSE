using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPersona.Models
{
    public class Persona
    {
        public int ID { get; set; }

        [Display(Name = "DUI")]
        public string dui { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Display(Name = "Correo")]
        public string correo { get; set; }
    }

    public class PersonaDBContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }
}