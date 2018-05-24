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
    public class partidoPoliticoController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: partidoPolitico
        public ActionResult Index()
        {
            return View(db.partidoPolitico.ToList());
        }

        // GET: partidoPolitico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partidoPolitico partidoPolitico = db.partidoPolitico.Find(id);
            if (partidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(partidoPolitico);
        }

        // GET: partidoPolitico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: partidoPolitico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartido,nombre")] partidoPolitico partidoPolitico)
        {
            if (ModelState.IsValid)
            {
                db.partidoPolitico.Add(partidoPolitico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partidoPolitico);
        }

        // GET: partidoPolitico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partidoPolitico partidoPolitico = db.partidoPolitico.Find(id);
            if (partidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(partidoPolitico);
        }

        // POST: partidoPolitico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartido,nombre")] partidoPolitico partidoPolitico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidoPolitico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partidoPolitico);
        }

        // GET: partidoPolitico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partidoPolitico partidoPolitico = db.partidoPolitico.Find(id);
            if (partidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(partidoPolitico);
        }

        // POST: partidoPolitico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            partidoPolitico partidoPolitico = db.partidoPolitico.Find(id);
            db.partidoPolitico.Remove(partidoPolitico);
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
