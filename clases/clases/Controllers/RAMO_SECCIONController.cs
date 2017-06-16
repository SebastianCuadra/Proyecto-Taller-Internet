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
    public class RAMO_SECCIONController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: RAMO_SECCION
        public ActionResult Index()
        {
            var rAMO_SECCION = db.RAMO_SECCION.Include(r => r.RAMO).Include(r => r.SECCION);
            return View(rAMO_SECCION.ToList());
        }

        // GET: RAMO_SECCION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_SECCION rAMO_SECCION = db.RAMO_SECCION.Find(id);
            if (rAMO_SECCION == null)
            {
                return HttpNotFound();
            }
            return View(rAMO_SECCION);
        }

        // GET: RAMO_SECCION/Create
        public ActionResult Create()
        {
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO");
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION");
            return View();
        }

        // POST: RAMO_SECCION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SECCION,ID_RAMO,ID_SECCION_RAMO")] RAMO_SECCION rAMO_SECCION)
        {
            if (ModelState.IsValid)
            {
                db.RAMO_SECCION.Add(rAMO_SECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_SECCION.ID_RAMO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", rAMO_SECCION.ID_SECCION);
            return View(rAMO_SECCION);
        }

        // GET: RAMO_SECCION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_SECCION rAMO_SECCION = db.RAMO_SECCION.Find(id);
            if (rAMO_SECCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_SECCION.ID_RAMO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", rAMO_SECCION.ID_SECCION);
            return View(rAMO_SECCION);
        }

        // POST: RAMO_SECCION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SECCION,ID_RAMO,ID_SECCION_RAMO")] RAMO_SECCION rAMO_SECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAMO_SECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_SECCION.ID_RAMO);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", rAMO_SECCION.ID_SECCION);
            return View(rAMO_SECCION);
        }

        // GET: RAMO_SECCION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_SECCION rAMO_SECCION = db.RAMO_SECCION.Find(id);
            if (rAMO_SECCION == null)
            {
                return HttpNotFound();
            }
            return View(rAMO_SECCION);
        }

        // POST: RAMO_SECCION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAMO_SECCION rAMO_SECCION = db.RAMO_SECCION.Find(id);
            db.RAMO_SECCION.Remove(rAMO_SECCION);
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
