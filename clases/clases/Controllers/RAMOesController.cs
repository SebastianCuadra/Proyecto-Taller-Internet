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
    public class RAMOesController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: RAMOes
        public ActionResult Index()
        {
            return View(db.RAMO.ToList());
        }

        // GET: RAMOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO rAMO = db.RAMO.Find(id);
            if (rAMO == null)
            {
                return HttpNotFound();
            }
            return View(rAMO);
        }

        // GET: RAMOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAMOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RAMO,NOMBRE_RAMO")] RAMO rAMO)
        {
            if (ModelState.IsValid)
            {
                db.RAMO.Add(rAMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rAMO);
        }

        // GET: RAMOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO rAMO = db.RAMO.Find(id);
            if (rAMO == null)
            {
                return HttpNotFound();
            }
            return View(rAMO);
        }

        // POST: RAMOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RAMO,NOMBRE_RAMO")] RAMO rAMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rAMO);
        }

        // GET: RAMOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAMO rAMO = db.RAMO.Find(id);
            if (rAMO == null)
            {
                return HttpNotFound();
            }
            return View(rAMO);
        }

        // POST: RAMOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAMO rAMO = db.RAMO.Find(id);
            db.RAMO.Remove(rAMO);
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
