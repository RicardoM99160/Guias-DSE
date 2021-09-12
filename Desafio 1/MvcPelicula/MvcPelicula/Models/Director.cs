using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcPelicula.Models
{
    public class Director
    {
        public int DirectorID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}