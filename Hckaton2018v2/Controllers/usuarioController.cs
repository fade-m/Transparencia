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
    public class usuarioController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        // GET: usuario
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.persona).Include(u => u.tipoUsuario);
            return View(usuario.ToList());
        }

        // GET: usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuario/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "nombre");
            ViewBag.idTipoUsuario = new SelectList(db.tipoUsuario, "idTipoUsuario", "tipo");
            return View();
        }

        // POST: usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuario1,idTipoUsuario,contrasena,idUsuario,email,idPersona")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "nombre", usuario.idPersona);
            ViewBag.idTipoUsuario = new SelectList(db.tipoUsuario, "idTipoUsuario", "tipo", usuario.idTipoUsuario);
            return View(usuario);
        }

        // GET: usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "nombre", usuario.idPersona);
            ViewBag.idTipoUsuario = new SelectList(db.tipoUsuario, "idTipoUsuario", "tipo", usuario.idTipoUsuario);
            return View(usuario);
        }

        // POST: usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuario1,idTipoUsuario,contrasena,idUsuario,email,idPersona")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "nombre", usuario.idPersona);
            ViewBag.idTipoUsuario = new SelectList(db.tipoUsuario, "idTipoUsuario", "tipo", usuario.idTipoUsuario);
            return View(usuario);
        }

        // GET: usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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
