using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaPresentacionNG;

namespace CapaPresentacionNG.Controllers
{
    public class PlatoController : Controller
    {
        private DBS_NEIGHBORFOOD2Entities db = new DBS_NEIGHBORFOOD2Entities();

        // GET: Plato
        public ActionResult Index()
        {
            return View(db.TBL_Plato.ToList());
        }

        // GET: Plato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Plato tBL_Plato = db.TBL_Plato.Find(id);
            if (tBL_Plato == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Plato);
        }

        // GET: Plato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_CodigoPlato,PLA_NombrePlato,PLA_Precio,PLA_Descripcion,PLA_Ingredientes")] TBL_Plato tBL_Plato)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Plato.Add(tBL_Plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Plato);
        }

        // GET: Plato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Plato tBL_Plato = db.TBL_Plato.Find(id);
            if (tBL_Plato == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Plato);
        }

        // POST: Plato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_CodigoPlato,PLA_NombrePlato,PLA_Precio,PLA_Descripcion,PLA_Ingredientes")] TBL_Plato tBL_Plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Plato);
        }

        // GET: Plato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Plato tBL_Plato = db.TBL_Plato.Find(id);
            if (tBL_Plato == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Plato);
        }

        // POST: Plato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Plato tBL_Plato = db.TBL_Plato.Find(id);
            db.TBL_Plato.Remove(tBL_Plato);
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
