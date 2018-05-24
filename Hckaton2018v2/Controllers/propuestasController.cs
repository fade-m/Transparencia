using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hckaton2018v2;

namespace Hckaton2018v2.Controllers
{
    public class propuestasController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: propuestas
        public ActionResult Index()
        {
            var propuestas = db.propuestas.Include(p => p.archivo).Include(p => p.candidato).Include(p => p.tipoPropuesta);
            return View(propuestas.ToList());
        }

        // GET: propuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propuestas propuestas = db.propuestas.Find(id);
            if (propuestas == null)
            {
                return HttpNotFound();
            }
            return View(propuestas);
        }

        // GET: propuestas/Create
        public ActionResult Create()
        {
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta");
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato");
            ViewBag.idTipoPropuesta = new SelectList(db.tipoPropuesta, "idTipoPropuesta", "tipoPropuesta1");
            return View();
        }

        // POST: propuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPropuesta,descripcion,idTipoPropuesta,idCandidato,idArchivo")] propuestas propuestas)
        {
            if (ModelState.IsValid)
            {
                db.propuestas.Add(propuestas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", propuestas.idArchivo);
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", propuestas.idCandidato);
            ViewBag.idTipoPropuesta = new SelectList(db.tipoPropuesta, "idTipoPropuesta", "tipoPropuesta1", propuestas.idTipoPropuesta);
            return View(propuestas);
        }

        // GET: propuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propuestas propuestas = db.propuestas.Find(id);
            if (propuestas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", propuestas.idArchivo);
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", propuestas.idCandidato);
            ViewBag.idTipoPropuesta = new SelectList(db.tipoPropuesta, "idTipoPropuesta", "tipoPropuesta1", propuestas.idTipoPropuesta);
            return View(propuestas);
        }

        // POST: propuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPropuesta,descripcion,idTipoPropuesta,idCandidato,idArchivo")] propuestas propuestas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propuestas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", propuestas.idArchivo);
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", propuestas.idCandidato);
            ViewBag.idTipoPropuesta = new SelectList(db.tipoPropuesta, "idTipoPropuesta", "tipoPropuesta1", propuestas.idTipoPropuesta);
            return View(propuestas);
        }

        // GET: propuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propuestas propuestas = db.propuestas.Find(id);
            if (propuestas == null)
            {
                return HttpNotFound();
            }
            return View(propuestas);
        }

        // POST: propuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            propuestas propuestas = db.propuestas.Find(id);
            db.propuestas.Remove(propuestas);
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
