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
    public class CLASEsController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: CLASEs
        public ActionResult Index()
        {
            var cLASE = db.CLASE.Include(c => c.CARRERA).Include(c => c.MODULO_SALA).Include(c => c.RAMO_PROFESOR);
            return View(cLASE.ToList());
        }

        // GET: CLASEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASE cLASE = db.CLASE.Find(id);
            if (cLASE == null)
            {
                return HttpNotFound();
            }
            return View(cLASE);
        }

        // GET: CLASEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA");
            ViewBag.ID_MODULO_SALA = new SelectList(db.MODULO_SALA, "ID_MODULO_SALA", "ID_MODULO_SALA");
            ViewBag.ID_RAMO_PROFE = new SelectList(db.RAMO_PROFESOR, "ID_RAMO_PROFE", "ID_RAMO_PROFE");
            return View();
        }

        // POST: CLASEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLASE,ID_CARRERA,ID_RAMO_PROFE,ID_MODULO_SALA,ESTADO_PROFESOR,FECHA_CLASE")] CLASE cLASE)
        {
            if (ModelState.IsValid)
            {
                db.CLASE.Add(cLASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cLASE.ID_CARRERA);
            ViewBag.ID_MODULO_SALA = new SelectList(db.MODULO_SALA, "ID_MODULO_SALA", "ID_MODULO_SALA", cLASE.ID_MODULO_SALA);
            ViewBag.ID_RAMO_PROFE = new SelectList(db.RAMO_PROFESOR, "ID_RAMO_PROFE", "ID_RAMO_PROFE", cLASE.ID_RAMO_PROFE);
            return View(cLASE);
        }

        // GET: CLASEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASE cLASE = db.CLASE.Find(id);
            if (cLASE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cLASE.ID_CARRERA);
            ViewBag.ID_MODULO_SALA = new SelectList(db.MODULO_SALA, "ID_MODULO_SALA", "ID_MODULO_SALA", cLASE.ID_MODULO_SALA);
            ViewBag.ID_RAMO_PROFE = new SelectList(db.RAMO_PROFESOR, "ID_RAMO_PROFE", "ID_RAMO_PROFE", cLASE.ID_RAMO_PROFE);
            return View(cLASE);
        }

        // POST: CLASEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLASE,ID_CARRERA,ID_RAMO_PROFE,ID_MODULO_SALA,ESTADO_PROFESOR,FECHA_CLASE")] CLASE cLASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", cLASE.ID_CARRERA);
            ViewBag.ID_MODULO_SALA = new SelectList(db.MODULO_SALA, "ID_MODULO_SALA", "ID_MODULO_SALA", cLASE.ID_MODULO_SALA);
            ViewBag.ID_RAMO_PROFE = new SelectList(db.RAMO_PROFESOR, "ID_RAMO_PROFE", "ID_RAMO_PROFE", cLASE.ID_RAMO_PROFE);
            return View(cLASE);
        }

        // GET: CLASEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASE cLASE = db.CLASE.Find(id);
            if (cLASE == null)
            {
                return HttpNotFound();
            }
            return View(cLASE);
        }

        // POST: CLASEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASE cLASE = db.CLASE.Find(id);
            db.CLASE.Remove(cLASE);
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
