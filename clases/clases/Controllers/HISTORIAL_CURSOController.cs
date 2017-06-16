using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clases.Models;

namespace clases.Controllers
{
    public class HISTORIAL_CURSOController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: HISTORIAL_CURSO
        public ActionResult Index()
        {
            var hISTORIAL_CURSO = db.HISTORIAL_CURSO.Include(h => h.CLASE).Include(h => h.ESTADO_CLASE);
            return View(hISTORIAL_CURSO.ToList());
        }

        // GET: HISTORIAL_CURSO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_CURSO hISTORIAL_CURSO = db.HISTORIAL_CURSO.Find(id);
            if (hISTORIAL_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_CURSO);
        }

        // GET: HISTORIAL_CURSO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR");
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO_CLASE, "ID_ESTADO", "NOMBRE_ESTADO");
            return View();
        }

        // POST: HISTORIAL_CURSO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HISTORIAL,ID_CLASE,ID_ESTADO,NUMERO_CLASE")] HISTORIAL_CURSO hISTORIAL_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIAL_CURSO.Add(hISTORIAL_CURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", hISTORIAL_CURSO.ID_CLASE);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO_CLASE, "ID_ESTADO", "NOMBRE_ESTADO", hISTORIAL_CURSO.ID_ESTADO);
            return View(hISTORIAL_CURSO);
        }

        // GET: HISTORIAL_CURSO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_CURSO hISTORIAL_CURSO = db.HISTORIAL_CURSO.Find(id);
            if (hISTORIAL_CURSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", hISTORIAL_CURSO.ID_CLASE);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO_CLASE, "ID_ESTADO", "NOMBRE_ESTADO", hISTORIAL_CURSO.ID_ESTADO);
            return View(hISTORIAL_CURSO);
        }

        // POST: HISTORIAL_CURSO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HISTORIAL,ID_CLASE,ID_ESTADO,NUMERO_CLASE")] HISTORIAL_CURSO hISTORIAL_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIAL_CURSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", hISTORIAL_CURSO.ID_CLASE);
            ViewBag.ID_ESTADO = new SelectList(db.ESTADO_CLASE, "ID_ESTADO", "NOMBRE_ESTADO", hISTORIAL_CURSO.ID_ESTADO);
            return View(hISTORIAL_CURSO);
        }

        // GET: HISTORIAL_CURSO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_CURSO hISTORIAL_CURSO = db.HISTORIAL_CURSO.Find(id);
            if (hISTORIAL_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_CURSO);
        }

        // POST: HISTORIAL_CURSO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORIAL_CURSO hISTORIAL_CURSO = db.HISTORIAL_CURSO.Find(id);
            db.HISTORIAL_CURSO.Remove(hISTORIAL_CURSO);
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
