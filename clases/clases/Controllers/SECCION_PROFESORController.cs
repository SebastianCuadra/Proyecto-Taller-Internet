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
    public class SECCION_PROFESORController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: SECCION_PROFESOR
        public ActionResult Index()
        {
            var sECCION_PROFESOR = db.SECCION_PROFESOR.Include(s => s.PROFESOR).Include(s => s.SECCION);
            return View(sECCION_PROFESOR.ToList());
        }

        // GET: SECCION_PROFESOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_PROFESOR sECCION_PROFESOR = db.SECCION_PROFESOR.Find(id);
            if (sECCION_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(sECCION_PROFESOR);
        }

        // GET: SECCION_PROFESOR/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR");
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION");
            return View();
        }

        // POST: SECCION_PROFESOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESOR,ID_SECCION,ID_PROFE_SECCION")] SECCION_PROFESOR sECCION_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.SECCION_PROFESOR.Add(sECCION_PROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", sECCION_PROFESOR.ID_PROFESOR);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_PROFESOR.ID_SECCION);
            return View(sECCION_PROFESOR);
        }

        // GET: SECCION_PROFESOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_PROFESOR sECCION_PROFESOR = db.SECCION_PROFESOR.Find(id);
            if (sECCION_PROFESOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", sECCION_PROFESOR.ID_PROFESOR);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_PROFESOR.ID_SECCION);
            return View(sECCION_PROFESOR);
        }

        // POST: SECCION_PROFESOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROFESOR,ID_SECCION,ID_PROFE_SECCION")] SECCION_PROFESOR sECCION_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sECCION_PROFESOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", sECCION_PROFESOR.ID_PROFESOR);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_PROFESOR.ID_SECCION);
            return View(sECCION_PROFESOR);
        }

        // GET: SECCION_PROFESOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_PROFESOR sECCION_PROFESOR = db.SECCION_PROFESOR.Find(id);
            if (sECCION_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(sECCION_PROFESOR);
        }

        // POST: SECCION_PROFESOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SECCION_PROFESOR sECCION_PROFESOR = db.SECCION_PROFESOR.Find(id);
            db.SECCION_PROFESOR.Remove(sECCION_PROFESOR);
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
