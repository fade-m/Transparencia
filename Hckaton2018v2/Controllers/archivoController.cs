using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Hckaton2018v2;
using Hckaton2018v2.Models;

namespace Hckaton2018v2.Controllers
{
    public class archivoController : Controller
    {
        private db_transparenciaEntities db = new db_transparenciaEntities();

        DataClasses objData;

        public archivoController()
        {
            objData = new DataClasses();
        }
          
        
        [HttpPost]
        public ActionResult Cargar(HttpPostedFileBase archivo)
        {
            if (archivo != null && archivo.ContentLength > 0)
            {
                var nombreArchivo = Path.GetFileName(archivo.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Documentos Subidos"), nombreArchivo);
                archivo.SaveAs(path);
            }

            var files = objData.GetFiles();
            return View("index", files);

        }


        public FileResult Download(string id)
        {
            int fid = Convert.ToInt32(id);
            var files = objData.GetFiles();
            string filename = (from f in files
                               where f.FileId == fid
                               select f.FilePath).First();

            string contentType = "application/pdf";

            //Parameters to file are
            //1. The File Path on the File Server
            //2. The content type MIME type
            //3. The parameter for the file save by the browser
            return File(filename, contentType, "TransparenteDownload.pdf");
        }

        // GET: archivo
        public ActionResult Index()
        {
            var files = objData.GetFiles();
            return View("index", files);
        }

        // GET: archivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archivo archivo = db.archivo.Find(id);
            if (archivo == null)
            {
                return HttpNotFound();
            }
            return View(archivo);
        }

        // GET: archivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: archivo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArchivo,ruta")] archivo archivo)
        {
            if (ModelState.IsValid)
            {
                db.archivo.Add(archivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(archivo);
        }

        // GET: archivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archivo archivo = db.archivo.Find(id);
            if (archivo == null)
            {
                return HttpNotFound();
            }
            return View(archivo);
        }

        // POST: archivo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArchivo,ruta")] archivo archivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(archivo);
        }

        // GET: archivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archivo archivo = db.archivo.Find(id);
            if (archivo == null)
            {
                return HttpNotFound();
            }
            return View(archivo);
        }

        // POST: archivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            archivo archivo = db.archivo.Find(id);
            db.archivo.Remove(archivo);
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
