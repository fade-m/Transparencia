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
    public class tipoCandidatoesController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: tipoCandidatoes
        public ActionResult Index()
        {
            return View(db.tipoCandidato.ToList());
        }

        // GET: tipoCandidatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCandidato tipoCandidato = db.tipoCandidato.Find(id);
            if (tipoCandidato == null)
            {
                return HttpNotFound();
            }
            return View(tipoCandidato);
        }

        // GET: tipoCandidatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoCandidatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoCandidato,tipoCandidato1")] tipoCandidato tipoCandidato)
        {
            if (ModelState.IsValid)
            {
                db.tipoCandidato.Add(tipoCandidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCandidato);
        }

        // GET: tipoCandidatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCandidato tipoCandidato = db.tipoCandidato.Find(id);
            if (tipoCandidato == null)
            {
                return HttpNotFound();
            }
            return View(tipoCandidato);
        }

        // POST: tipoCandidatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoCandidato,tipoCandidato1")] tipoCandidato tipoCandidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCandidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCandidato);
        }

        // GET: tipoCandidatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoCandidato tipoCandidato = db.tipoCandidato.Find(id);
            if (tipoCandidato == null)
            {
                return HttpNotFound();
            }
            return View(tipoCandidato);
        }

        // POST: tipoCandidatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoCandidato tipoCandidato = db.tipoCandidato.Find(id);
            db.tipoCandidato.Remove(tipoCandidato);
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
