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
    public class candidatoesController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: candidatoes
        public ActionResult Index()
        {
            var candidato = db.candidato.Include(c => c.partidoPolitico).Include(c => c.presupuesto).Include(c => c.tipoCandidato).Include(c => c.usuario);
            return View(candidato.ToList());
        }

        // GET: candidatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidato candidato = db.candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: candidatoes/Create
        public ActionResult Create()
        {
            ViewBag.idPartido = new SelectList(db.partidoPolitico, "idPartido", "nombre");
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto");
            ViewBag.idTipoCandidato = new SelectList(db.tipoCandidato, "idTipoCandidato", "tipoCandidato1");
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "usuario1");
            ViewBag.idTipoUsuario = new SelectList(db.tipoUsuario, "idTipoUsuario", "tipo");
            return View();
        }

        // POST: candidatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCandidato,idPartido,idUsuario,idTipoCandidato,idPresupuesto")] candidato candidato,
            [Bind(Include = "usuario1,idTipoUsuario,contrasena,idUsuario,email")] usuario usuario)
        {
            if (ModelState.IsValid)
            {

                db.usuario.Add(usuario);
                db.SaveChanges();
                
                var id = (from x in db.usuario where x.usuario1 == usuario.usuario1 select x.idUsuario).First();
                candidato.idUsuario = id;
                db.candidato.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPartido = new SelectList(db.partidoPolitico, "idPartido", "nombre", candidato.idPartido);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", candidato.idPresupuesto);
            ViewBag.idTipoCandidato = new SelectList(db.tipoCandidato, "idTipoCandidato", "tipoCandidato1", candidato.idTipoCandidato);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "usuario1", candidato.idUsuario);
            return View(candidato);
        }

        // GET: candidatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidato candidato = db.candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPartido = new SelectList(db.partidoPolitico, "idPartido", "nombre", candidato.idPartido);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", candidato.idPresupuesto);
            ViewBag.idTipoCandidato = new SelectList(db.tipoCandidato, "idTipoCandidato", "tipoCandidato1", candidato.idTipoCandidato);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "usuario1", candidato.idUsuario);
            return View(candidato);
        }

        // POST: candidatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCandidato,idPartido,idUsuario,idTipoCandidato,idPresupuesto")] candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPartido = new SelectList(db.partidoPolitico, "idPartido", "nombre", candidato.idPartido);
            ViewBag.idPresupuesto = new SelectList(db.presupuesto, "idPresupuesto", "idPresupuesto", candidato.idPresupuesto);
            ViewBag.idTipoCandidato = new SelectList(db.tipoCandidato, "idTipoCandidato", "tipoCandidato1", candidato.idTipoCandidato);
            ViewBag.idUsuario = new SelectList(db.usuario, "idUsuario", "usuario1", candidato.idUsuario);
            return View(candidato);
        }

        // GET: candidatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidato candidato = db.candidato.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: candidatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            candidato candidato = db.candidato.Find(id);
            db.candidato.Remove(candidato);
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
