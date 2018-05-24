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
    public class programasIngresoesController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: programasIngresoes
        public ActionResult Index()
        {
            var programasIngreso = db.programasIngreso.Include(p => p.presupuesto1);
            return View(programasIngreso.ToList());
        }

        // GET: programasIngresoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programasIngreso programasIngreso = db.programasIngreso.Find(id);
            if (programasIngreso == null)
            {
                return HttpNotFound();
            }
            return View(programasIngreso);
        }

        // GET: programasIngresoes/Create
        public ActionResult Create()
        {
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto");
            return View();
        }

        // POST: programasIngresoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProgramaIngreso,presupuesto,idPresupuesto")] programasIngreso programasIngreso)
        {
            if (ModelState.IsValid)
            {
                db.programasIngreso.Add(programasIngreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", programasIngreso.idPresupuesto);
            return View(programasIngreso);
        }

        // GET: programasIngresoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programasIngreso programasIngreso = db.programasIngreso.Find(id);
            if (programasIngreso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", programasIngreso.idPresupuesto);
            return View(programasIngreso);
        }

        // POST: programasIngresoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProgramaIngreso,presupuesto,idPresupuesto")] programasIngreso programasIngreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programasIngreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", programasIngreso.idPresupuesto);
            return View(programasIngreso);
        }

        // GET: programasIngresoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            programasIngreso programasIngreso = db.programasIngreso.Find(id);
            if (programasIngreso == null)
            {
                return HttpNotFound();
            }
            return View(programasIngreso);
        }

        // POST: programasIngresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            programasIngreso programasIngreso = db.programasIngreso.Find(id);
            db.programasIngreso.Remove(programasIngreso);
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
