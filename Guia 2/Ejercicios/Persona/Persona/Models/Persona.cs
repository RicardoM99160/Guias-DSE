using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Persona.Models
{
    public class Persona
    {
        public string DUI { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
    }

    public class PersonaDBContext: DbContext
    {
        public DbSet<Persona> Personas { get; set; }
    }
}