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
    public class ESTADO_CLASEController : Controller
    {
        private clasesEntities db = new clasesEntities();

        // GET: ESTADO_CLASE
        public ActionResult Index()
        {
            return View(db.ESTADO_CLASE.ToList());
        }

        // GET: ESTADO_CLASE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CLASE eSTADO_CLASE = db.ESTADO_CLASE.Find(id);
            if (eSTADO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CLASE);
        }

        // GET: ESTADO_CLASE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADO_CLASE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTADO,NOMBRE_ESTADO")] ESTADO_CLASE eSTADO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.ESTADO_CLASE.Add(eSTADO_CLASE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADO_CLASE);
        }

        // GET: ESTADO_CLASE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CLASE eSTADO_CLASE = db.ESTADO_CLASE.Find(id);
            if (eSTADO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CLASE);
        }

        // POST: ESTADO_CLASE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTADO,NOMBRE_ESTADO")] ESTADO_CLASE eSTADO_CLASE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO_CLASE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO_CLASE);
        }

        // GET: ESTADO_CLASE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CLASE eSTADO_CLASE = db.ESTADO_CLASE.Find(id);
            if (eSTADO_CLASE == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CLASE);
        }

        // POST: ESTADO_CLASE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO_CLASE eSTADO_CLASE = db.ESTADO_CLASE.Find(id);
            db.ESTADO_CLASE.Remove(eSTADO_CLASE);
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
