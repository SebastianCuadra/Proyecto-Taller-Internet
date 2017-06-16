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
    public class ALUMNOesController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: ALUMNOes
        public ActionResult Index()
        {
            var aLUMNO = db.ALUMNO.Include(a => a.CARRERA).Include(a => a.SECCION);
            return View(aLUMNO.ToList());
        }

        // GET: ALUMNOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // GET: ALUMNOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA");
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION");
            return View();
        }

        // POST: ALUMNOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALUMNO,ID_CARRERA,ID_SECCION,NOMBRE_ALUMNO,AP_ALUMNO")] ALUMNO aLUMNO)
        {
            if (ModelState.IsValid)
            {
                db.ALUMNO.Add(aLUMNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", aLUMNO.ID_CARRERA);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", aLUMNO.ID_SECCION);
            return View(aLUMNO);
        }

        // GET: ALUMNOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", aLUMNO.ID_CARRERA);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", aLUMNO.ID_SECCION);
            return View(aLUMNO);
        }

        // POST: ALUMNOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALUMNO,ID_CARRERA,ID_SECCION,NOMBRE_ALUMNO,AP_ALUMNO")] ALUMNO aLUMNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUMNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CARRERA = new SelectList(db.CARRERA, "ID_CARRERA", "NOMBRE_CARRERA", aLUMNO.ID_CARRERA);
            ViewBag.ID_SECCION = new SelectList(db.SECCION, "ID_SECCION", "NOMBRE_SECCION", aLUMNO.ID_SECCION);
            return View(aLUMNO);
        }

        // GET: ALUMNOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            if (aLUMNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUMNO);
        }

        // POST: ALUMNOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUMNO aLUMNO = db.ALUMNO.Find(id);
            db.ALUMNO.Remove(aLUMNO);
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
