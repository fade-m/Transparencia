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
    public class preguntasController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: preguntas
        public ActionResult Index()
        {
            var pregunta = db.pregunta.Include(p => p.candidato);
            return View(pregunta.ToList());
        }

        // GET: preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: preguntas/Create
        public ActionResult Create()
        {
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato");
            return View();
        }

        // POST: preguntas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPregunta,idCandidato,nombre,pregunta1,votosPositivos,votosNegativos,respuesta")] pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.pregunta.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", pregunta.idCandidato);
            return View(pregunta);
        }

        // GET: preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", pregunta.idCandidato);
            return View(pregunta);
        }

        // POST: preguntas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPregunta,idCandidato,nombre,pregunta1,votosPositivos,votosNegativos,respuesta")] pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCandidato = new SelectList(db.candidato, "idCandidato", "idCandidato", pregunta.idCandidato);
            return View(pregunta);
        }

        // GET: preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pregunta pregunta = db.pregunta.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pregunta pregunta = db.pregunta.Find(id);
            db.pregunta.Remove(pregunta);
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
