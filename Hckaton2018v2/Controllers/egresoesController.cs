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
    public class egresoesController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: egresoes
        public ActionResult Index()
        {
            var egreso = db.egreso.Include(e => e.archivo).Include(e => e.presupuesto);
            return View(egreso.ToList());
        }

        // GET: egresoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            egreso egreso = db.egreso.Find(id);
            if (egreso == null)
            {
                return HttpNotFound();
            }
            return View(egreso);
        }

        // GET: egresoes/Create
        public ActionResult Create()
        {
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta");
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto");
            return View();
        }

        // POST: egresoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEgreso,idPresupuesto,idArchivo,cantidad,descripcion,votosPositivos,votosNegativos,latitud,longitud")] egreso egreso)
        {
            if (ModelState.IsValid)
            {
                db.egreso.Add(egreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", egreso.idArchivo);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", egreso.idPresupuesto);
            return View(egreso);
        }

        // GET: egresoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            egreso egreso = db.egreso.Find(id);
            if (egreso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", egreso.idArchivo);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", egreso.idPresupuesto);
            return View(egreso);
        }

        // POST: egresoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEgreso,idPresupuesto,idArchivo,cantidad,descripcion,votosPositivos,votosNegativos,latitud,longitud")] egreso egreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(egreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArchivo = new SelectList(db.archivo, "idArchivo", "ruta", egreso.idArchivo);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", egreso.idPresupuesto);
            return View(egreso);
        }

        // GET: egresoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            egreso egreso = db.egreso.Find(id);
            if (egreso == null)
            {
                return HttpNotFound();
            }
            return View(egreso);
        }

        // POST: egresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            egreso egreso = db.egreso.Find(id);
            db.egreso.Remove(egreso);
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
