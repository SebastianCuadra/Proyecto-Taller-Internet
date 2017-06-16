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
    public class SECCIONsController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: SECCIONs
        public ActionResult Index()
        {
            return View(db.SECCION.ToList());
        }

        // GET: SECCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION sECCION = db.SECCION.Find(id);
            if (sECCION == null)
            {
                return HttpNotFound();
            }
            return View(sECCION);
        }

        // GET: SECCIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SECCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SECCION,NOMBRE_SECCION")] SECCION sECCION)
        {
            if (ModelState.IsValid)
            {
                db.SECCION.Add(sECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sECCION);
        }

        // GET: SECCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION sECCION = db.SECCION.Find(id);
            if (sECCION == null)
            {
                return HttpNotFound();
            }
            return View(sECCION);
        }

        // POST: SECCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SECCION,NOMBRE_SECCION")] SECCION sECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sECCION);
        }

        // GET: SECCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SECCION sECCION = db.SECCION.Find(id);
            if (sECCION == null)
            {
                return HttpNotFound();
            }
            return View(sECCION);
        }

        // POST: SECCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SECCION sECCION = db.SECCION.Find(id);
            db.SECCION.Remove(sECCION);
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
