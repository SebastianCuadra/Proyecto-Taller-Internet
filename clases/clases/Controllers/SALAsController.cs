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
    public class SALAsController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: SALAs
        public ActionResult Index()
        {
            return View(db.SALA.ToList());
        }

        // GET: SALAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALA.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // GET: SALAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SALA,NOMBRE_SALA")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.SALA.Add(sALA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALA);
        }

        // GET: SALAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALA.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: SALAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SALA,NOMBRE_SALA")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALA);
        }

        // GET: SALAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = db.SALA.Find(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: SALAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALA sALA = db.SALA.Find(id);
            db.SALA.Remove(sALA);
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
