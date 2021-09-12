using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPelicula.Models;

namespace MvcPelicula.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculaDBContext db = new PeliculaDBContext();

        // GET: Peliculas
        public ActionResult Index(string buscarString, string generoPelicula, string precioPelicula, string directorPelicula)
        {
            var directores = from d in db.Directores select d;
            var directoresLst = new List<Director>();
            directoresLst.AddRange(directores.Distinct());

            var peliculas = from p in db.Peliculas select p;

            foreach (var pelicula in peliculas)
            {
                pelicula.Director = directoresLst.Single(s => s.DirectorID == pelicula.DirectorID);
            }

            var GeneroLst = new List<string>();
            var GeneroQry = from d in db.Peliculas orderby d.Genero select d.Genero;
            GeneroLst.AddRange(GeneroQry.Distinct());
            ViewBag.generoPelicula = new SelectList(GeneroLst, "Acción");

            var fromDatabaseEF = new SelectList(db.Directores.ToList(), "DirectorID", "Nombre");
            ViewBag.directorPelicula = fromDatabaseEF;

            if (!String.IsNullOrEmpty(buscarString))
            {
                peliculas = peliculas.Where(s => s.Titulo.Contains(buscarString));
            }

            if (!String.IsNullOrEmpty(generoPelicula))
            {
                peliculas = peliculas.Where(x => x.Genero == generoPelicula);
            }

            if(!String.IsNullOrEmpty(precioPelicula))
            {
                decimal precio = Decimal.Parse(precioPelicula);
                peliculas = peliculas.Where(y => y.Precio == precio);
            }

            if (!String.IsNullOrEmpty(directorPelicula))
            {
                int directorID = int.Parse(directorPelicula);
                peliculas = peliculas.Where(x => x.DirectorID == directorID);
            }



            return View(peliculas);
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);

            Director director = db.Directores.Find(pelicula.DirectorID);
            ViewData["director"] = director.Nombre;

            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            var directores = from d in db.Directores select d.Nombre;
            var fromDatabaseEF = new SelectList(db.Directores.ToList(), "DirectorID", "Nombre");
            ViewData["directores"] = fromDatabaseEF;

            return View();
        }

        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor")] Pelicula pelicula, int directorID)
        {
            var directores = from d in db.Directores select d;
            var directoresLst = new List<Director>();
            directoresLst.AddRange(directores.Distinct());

            Director directorSelec = directoresLst.Single(s => s.DirectorID == directorID);
            pelicula.Director = directorSelec;
            pelicula.DirectorID = directorSelec.DirectorID;


            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pelicula pelicula = db.Peliculas.Find(id);

            Director director = db.Directores.Find(pelicula.DirectorID);
            pelicula.Director = director;

            var directores = from d in db.Directores select d.Nombre;
            var fromDatabaseEF = new SelectList(db.Directores.ToList(), "DirectorID", "Nombre", director.Nombre);
            ViewData["directores"] = fromDatabaseEF;

            
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,FechaLanzamiento,Genero,Precio,Calificacion,Productor")] Pelicula pelicula, int directorID)
        {
            var directores = from d in db.Directores select d;
            var directoresLst = new List<Director>();
            directoresLst.AddRange(directores.Distinct());

            Director directorSelec = directoresLst.Single(s => s.DirectorID == directorID);
            pelicula.Director = directorSelec;
            pelicula.DirectorID = directorSelec.DirectorID;


            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);

            Director director = db.Directores.Find(pelicula.DirectorID);
            ViewData["director"] = director.Nombre;

            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
