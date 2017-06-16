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
    public class CARRERAsController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: CARRERAs
        public ActionResult Index()
        {
            return View(db.CARRERA.ToList());
        }

        // GET: CARRERAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERA.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA);
        }

        // GET: CARRERAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CARRERAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CARRERA,NOMBRE_CARRERA")] CARRERA cARRERA)
        {
            if (ModelState.IsValid)
            {
                db.CARRERA.Add(cARRERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cARRERA);
        }

        // GET: CARRERAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERA.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA);
        }

        // POST: CARRERAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CARRERA,NOMBRE_CARRERA")] CARRERA cARRERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cARRERA);
        }

        // GET: CARRERAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRERA cARRERA = db.CARRERA.Find(id);
            if (cARRERA == null)
            {
                return HttpNotFound();
            }
            return View(cARRERA);
        }

        // POST: CARRERAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARRERA cARRERA = db.CARRERA.Find(id);
            db.CARRERA.Remove(cARRERA);
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
