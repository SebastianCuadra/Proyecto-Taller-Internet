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
    public class ALUMNO_CLASEController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: ALUMNO_CLASE
        public ActionResult Index()
        {
            var aLUMNO_CLASE = db.ALUMNO_CLASE.Include(a => a.ALUMNO).Include(a => a.CLASE);
            return View(aLUMNO_CLASE.ToList());
        }

        // GET: ALUMNO_CLASE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO_CLASE aLUMNO_CLASE = db.ALUMNO_CLASE.Find(id);
            if (aLUMNO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO_CLASE);
        }

        // GET: ALUMNO_CLASE/Create
        public ActionResult Create()
        {
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNO, "ID_ALUMNO", "NOMBRE_ALUMNO");
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR");
            return View();
        }

        // POST: ALUMNO_CLASE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALUMNO,ID_CLASE,ESTADO_ALUMNO,ID_ALUMNO_CLASE")] ALUMNO_CLASE aLUMNO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.ALUMNO_CLASE.Add(aLUMNO_CLASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNO, "ID_ALUMNO", "NOMBRE_ALUMNO", aLUMNO_CLASE.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", aLUMNO_CLASE.ID_CLASE);
            return View(aLUMNO_CLASE);
        }

        // GET: ALUMNO_CLASE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO_CLASE aLUMNO_CLASE = db.ALUMNO_CLASE.Find(id);
            if (aLUMNO_CLASE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNO, "ID_ALUMNO", "NOMBRE_ALUMNO", aLUMNO_CLASE.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", aLUMNO_CLASE.ID_CLASE);
            return View(aLUMNO_CLASE);
        }

        // POST: ALUMNO_CLASE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALUMNO,ID_CLASE,ESTADO_ALUMNO,ID_ALUMNO_CLASE")] ALUMNO_CLASE aLUMNO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUMNO_CLASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALUMNO = new SelectList(db.ALUMNO, "ID_ALUMNO", "NOMBRE_ALUMNO", aLUMNO_CLASE.ID_ALUMNO);
            ViewBag.ID_CLASE = new SelectList(db.CLASE, "ID_CLASE", "ESTADO_PROFESOR", aLUMNO_CLASE.ID_CLASE);
            return View(aLUMNO_CLASE);
        }

        // GET: ALUMNO_CLASE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO_CLASE aLUMNO_CLASE = db.ALUMNO_CLASE.Find(id);
            if (aLUMNO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO_CLASE);
        }

        // POST: ALUMNO_CLASE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUMNO_CLASE aLUMNO_CLASE = db.ALUMNO_CLASE.Find(id);
            db.ALUMNO_CLASE.Remove(aLUMNO_CLASE);
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
