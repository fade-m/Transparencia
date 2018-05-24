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
    public class tipoPropuestasController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: tipoPropuestas
        public ActionResult Index()
        {
            return View(db.tipoPropuesta.ToList());
        }

        // GET: tipoPropuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPropuesta tipoPropuesta = db.tipoPropuesta.Find(id);
            if (tipoPropuesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPropuesta);
        }

        // GET: tipoPropuestas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoPropuestas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoPropuesta,tipoPropuesta1")] tipoPropuesta tipoPropuesta)
        {
            if (ModelState.IsValid)
            {
                db.tipoPropuesta.Add(tipoPropuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPropuesta);
        }

        // GET: tipoPropuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPropuesta tipoPropuesta = db.tipoPropuesta.Find(id);
            if (tipoPropuesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPropuesta);
        }

        // POST: tipoPropuestas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoPropuesta,tipoPropuesta1")] tipoPropuesta tipoPropuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPropuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPropuesta);
        }

        // GET: tipoPropuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoPropuesta tipoPropuesta = db.tipoPropuesta.Find(id);
            if (tipoPropuesta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPropuesta);
        }

        // POST: tipoPropuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoPropuesta tipoPropuesta = db.tipoPropuesta.Find(id);
            db.tipoPropuesta.Remove(tipoPropuesta);
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
