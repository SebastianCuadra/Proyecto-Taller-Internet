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
    public class CARRERA_RAMOController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: CARRERA_RAMO
        public ActionResult Index()
        {
            var cARRERA_RAMO = db.CARRERA_RAMO.Include(c => c.CARRERA).Include(c => c.RAMO);
            return View(cARRERA_RAMO.ToList());
        }

        // GET: CARRERA_RAMO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA_RAMO cARRERA_RAMO = db.CARRERA_RAMO.Find(id);
            if (cARRERA_RAMO == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA_RAMO);
        }

        // GET: CARRERA_RAMO/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA");
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO");
            return View();
        }

        // POST: CARRERA_RAMO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RAMO,ID_CARRERA,ID_CARRERA_RAMO")] CARRERA_RAMO cARRERA_RAMO)
        {
            if (ModelState.IsValid)
            {
                db.CARRERA_RAMO.Add(cARRERA_RAMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cARRERA_RAMO.ID_CARRERA);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", cARRERA_RAMO.ID_RAMO);
            return View(cARRERA_RAMO);
        }

        // GET: CARRERA_RAMO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA_RAMO cARRERA_RAMO = db.CARRERA_RAMO.Find(id);
            if (cARRERA_RAMO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cARRERA_RAMO.ID_CARRERA);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", cARRERA_RAMO.ID_RAMO);
            return View(cARRERA_RAMO);
        }

        // POST: CARRERA_RAMO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RAMO,ID_CARRERA,ID_CARRERA_RAMO")] CARRERA_RAMO cARRERA_RAMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRERA_RAMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cARRERA_RAMO.ID_CARRERA);
            ViewBag.ID_RAMO = new SelectList(db.RAMO, "ID_RAMO", "NOMBRE_RAMO", cARRERA_RAMO.ID_RAMO);
            return View(cARRERA_RAMO);
        }

        // GET: CARRERA_RAMO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA_RAMO cARRERA_RAMO = db.CARRERA_RAMO.Find(id);
            if (cARRERA_RAMO == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA_RAMO);
        }

        // POST: CARRERA_RAMO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARRERA_RAMO cARRERA_RAMO = db.CARRERA_RAMO.Find(id);
            db.CARRERA_RAMO.Remove(cARRERA_RAMO);
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
