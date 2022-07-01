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
    public class ResenaController : Controller
    {
        private DBS_NEIGHBORFOOD2Entities db = new DBS_NEIGHBORFOOD2Entities();

        // GET: Resena
        public ActionResult Index()
        {
            var tBL_Resena = db.TBL_Resena.Include(t => t.TBL_Cliente).Include(t => t.TBL_Restaurante);
         
            return View(tBL_Resena.ToList());
        }

        // GET: Resena/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Resena tBL_Resena = db.TBL_Resena.Find(id);
            if (tBL_Resena == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Resena);
        }

        // GET: Resena/Create
        public ActionResult Create()
        {
            ViewBag.FK_CodCliente = new SelectList(db.TBL_Cliente, "PK_Cedula_Cliente", "CLI_Nombre");
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre");
            return View();
        }

        // POST: Resena/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_CodigoReseña,RES_Fecha,RES_Calificacion,RES_Opinion,FK_CodCliente,FK_CodRestaurante")] TBL_Resena tBL_Resena)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Resena.Add(tBL_Resena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_CodCliente = new SelectList(db.TBL_Cliente, "PK_Cedula_Cliente", "CLI_Nombre", tBL_Resena.FK_CodCliente);
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Resena.FK_CodRestaurante);
            return View(tBL_Resena);
        }

        // GET: Resena/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Resena tBL_Resena = db.TBL_Resena.Find(id);
            if (tBL_Resena == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_CodCliente = new SelectList(db.TBL_Cliente, "PK_Cedula_Cliente", "CLI_Nombre", tBL_Resena.FK_CodCliente);
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Resena.FK_CodRestaurante);
            return View(tBL_Resena);
        }

        // POST: Resena/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_CodigoReseña,RES_Fecha,RES_Calificacion,RES_Opinion,FK_CodCliente,FK_CodRestaurante")] TBL_Resena tBL_Resena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Resena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_CodCliente = new SelectList(db.TBL_Cliente, "PK_Cedula_Cliente", "CLI_Nombre", tBL_Resena.FK_CodCliente);
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Resena.FK_CodRestaurante);
            return View(tBL_Resena);
        }

        // GET: Resena/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Resena tBL_Resena = db.TBL_Resena.Find(id);
            if (tBL_Resena == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Resena);
        }

        // POST: Resena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Resena tBL_Resena = db.TBL_Resena.Find(id);
            db.TBL_Resena.Remove(tBL_Resena);
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
