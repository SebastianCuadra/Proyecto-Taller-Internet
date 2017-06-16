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
    public class SECCION_MODULOController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: SECCION_MODULO
        public ActionResult Index()
        {
            var sECCION_MODULO = db.SECCION_MODULO.Include(s => s.MODULO).Include(s => s.SECCION);
            return View(sECCION_MODULO.ToList());
        }

        // GET: SECCION_MODULO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_MODULO sECCION_MODULO = db.SECCION_MODULO.Find(id);
            if (sECCION_MODULO == null)
            {
                return HttpNotFound();
            }
            return View(sECCION_MODULO);
        }

        // GET: SECCION_MODULO/Create
        public ActionResult Create()
        {
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO");
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION");
            return View();
        }

        // POST: SECCION_MODULO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MODULO,ID_SECCION,ID_MODULO_SECCION")] SECCION_MODULO sECCION_MODULO)
        {
            if (ModelState.IsValid)
            {
                db.SECCION_MODULO.Add(sECCION_MODULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", sECCION_MODULO.ID_MODULO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_MODULO.ID_SECCION);
            return View(sECCION_MODULO);
        }

        // GET: SECCION_MODULO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_MODULO sECCION_MODULO = db.SECCION_MODULO.Find(id);
            if (sECCION_MODULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", sECCION_MODULO.ID_MODULO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_MODULO.ID_SECCION);
            return View(sECCION_MODULO);
        }

        // POST: SECCION_MODULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MODULO,ID_SECCION,ID_MODULO_SECCION")] SECCION_MODULO sECCION_MODULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sECCION_MODULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", sECCION_MODULO.ID_MODULO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", sECCION_MODULO.ID_SECCION);
            return View(sECCION_MODULO);
        }

        // GET: SECCION_MODULO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION_MODULO sECCION_MODULO = db.SECCION_MODULO.Find(id);
            if (sECCION_MODULO == null)
            {
                return HttpNotFound();
            }
            return View(sECCION_MODULO);
        }

        // POST: SECCION_MODULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SECCION_MODULO sECCION_MODULO = db.SECCION_MODULO.Find(id);
            db.SECCION_MODULO.Remove(sECCION_MODULO);
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
