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
    public class presupuestoesController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: presupuestoes
        public ActionResult Index()
        {
            var presupuesto = db.presupuesto.Include(p => p.estado);
            return View(presupuesto.ToList());
        }

        // GET: presupuestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuesto presupuesto = db.presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // GET: presupuestoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre");
            return View();
        }

        // POST: presupuestoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPresupuesto,prepTotal,idEstado")] presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.presupuesto.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", presupuesto.idEstado);
            return View(presupuesto);
        }

        // GET: presupuestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuesto presupuesto = db.presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", presupuesto.idEstado);
            return View(presupuesto);
        }

        // POST: presupuestoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPresupuesto,prepTotal,idEstado")] presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.estado, "idEstado", "nombre", presupuesto.idEstado);
            return View(presupuesto);
        }

        // GET: presupuestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            presupuesto presupuesto = db.presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: presupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            presupuesto presupuesto = db.presupuesto.Find(id);
            db.presupuesto.Remove(presupuesto);
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
