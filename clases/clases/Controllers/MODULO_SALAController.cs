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
    public class MODULO_SALAController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: MODULO_SALA
        public ActionResult Index()
        {
            var mODULO_SALA = db.MODULO_SALA.Include(m => m.MODULO).Include(m => m.SALA);
            return View(mODULO_SALA.ToList());
        }

        // GET: MODULO_SALA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO_SALA mODULO_SALA = db.MODULO_SALA.Find(id);
            if (mODULO_SALA == null)
            {
                return HttpNotFound();
            }
            return View(mODULO_SALA);
        }

        // GET: MODULO_SALA/Create
        public ActionResult Create()
        {
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO");
            ViewBag.ID_SALA = new SelectList(db.SALA, "ID_SALA", "NOMBRE_SALA");
            return View();
        }

        // POST: MODULO_SALA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SALA,ID_MODULO,ID_MODULO_SALA")] MODULO_SALA mODULO_SALA)
        {
            if (ModelState.IsValid)
            {
                db.MODULO_SALA.Add(mODULO_SALA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", mODULO_SALA.ID_MODULO);
            ViewBag.ID_SALA = new SelectList(db.SALA, "ID_SALA", "NOMBRE_SALA", mODULO_SALA.ID_SALA);
            return View(mODULO_SALA);
        }

        // GET: MODULO_SALA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO_SALA mODULO_SALA = db.MODULO_SALA.Find(id);
            if (mODULO_SALA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", mODULO_SALA.ID_MODULO);
            ViewBag.ID_SALA = new SelectList(db.SALA, "ID_SALA", "NOMBRE_SALA", mODULO_SALA.ID_SALA);
            return View(mODULO_SALA);
        }

        // POST: MODULO_SALA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SALA,ID_MODULO,ID_MODULO_SALA")] MODULO_SALA mODULO_SALA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODULO_SALA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MODULO = new SelectList(db.MODULO, "ID_MODULO", "ID_MODULO", mODULO_SALA.ID_MODULO);
            ViewBag.ID_SALA = new SelectList(db.SALA, "ID_SALA", "NOMBRE_SALA", mODULO_SALA.ID_SALA);
            return View(mODULO_SALA);
        }

        // GET: MODULO_SALA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULO_SALA mODULO_SALA = db.MODULO_SALA.Find(id);
            if (mODULO_SALA == null)
            {
                return HttpNotFound();
            }
            return View(mODULO_SALA);
        }

        // POST: MODULO_SALA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MODULO_SALA mODULO_SALA = db.MODULO_SALA.Find(id);
            db.MODULO_SALA.Remove(mODULO_SALA);
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
