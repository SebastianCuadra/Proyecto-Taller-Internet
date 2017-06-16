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
    public class RAMO_PROFESORController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: RAMO_PROFESOR
        public ActionResult Index()
        {
            var rAMO_PROFESOR = db.RAMO_PROFESOR.Include(r => r.PROFESOR).Include(r => r.RAMO);
            return View(rAMO_PROFESOR.ToList());
        }

        // GET: RAMO_PROFESOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_PROFESOR rAMO_PROFESOR = db.RAMO_PROFESOR.Find(id);
            if (rAMO_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(rAMO_PROFESOR);
        }

        // GET: RAMO_PROFESOR/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR");
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO");
            return View();
        }

        // POST: RAMO_PROFESOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESOR,ID_RAMO,ID_RAMO_PROFE")] RAMO_PROFESOR rAMO_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.RAMO_PROFESOR.Add(rAMO_PROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", rAMO_PROFESOR.ID_PROFESOR);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_PROFESOR.ID_RAMO);
            return View(rAMO_PROFESOR);
        }

        // GET: RAMO_PROFESOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_PROFESOR rAMO_PROFESOR = db.RAMO_PROFESOR.Find(id);
            if (rAMO_PROFESOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", rAMO_PROFESOR.ID_PROFESOR);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_PROFESOR.ID_RAMO);
            return View(rAMO_PROFESOR);
        }

        // POST: RAMO_PROFESOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROFESOR,ID_RAMO,ID_RAMO_PROFE")] RAMO_PROFESOR rAMO_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAMO_PROFESOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "NOMBRE_PROFESOR", rAMO_PROFESOR.ID_PROFESOR);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", rAMO_PROFESOR.ID_RAMO);
            return View(rAMO_PROFESOR);
        }

        // GET: RAMO_PROFESOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO_PROFESOR rAMO_PROFESOR = db.RAMO_PROFESOR.Find(id);
            if (rAMO_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(rAMO_PROFESOR);
        }

        // POST: RAMO_PROFESOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAMO_PROFESOR rAMO_PROFESOR = db.RAMO_PROFESOR.Find(id);
            db.RAMO_PROFESOR.Remove(rAMO_PROFESOR);
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
