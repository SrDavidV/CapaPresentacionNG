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
    public class AdministradorController : Controller
    {
        private DBS_NEIGHBORFOOD2Entities db = new DBS_NEIGHBORFOOD2Entities();

        // GET: Administrador
        public ActionResult Index()
        {
            var tBL_Administrador = db.TBL_Administrador.Include(t => t.TBL_Restaurante);
            return View(tBL_Administrador.ToList());
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Administrador tBL_Administrador = db.TBL_Administrador.Find(id);
            if (tBL_Administrador == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Administrador);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre");
            return View();
        }

        // POST: Administrador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_Cedula_Administrador,ADM_Nombre,ADM_Apellido,ADM_Genero,ADM_CorreoElectronico,ADM_Contrasena,ADM_Telefono,FK_CodRestaurante")] TBL_Administrador tBL_Administrador)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Administrador.Add(tBL_Administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Administrador.FK_CodRestaurante);
            return View(tBL_Administrador);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Administrador tBL_Administrador = db.TBL_Administrador.Find(id);
            if (tBL_Administrador == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Administrador.FK_CodRestaurante);
            return View(tBL_Administrador);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_Cedula_Administrador,ADM_Nombre,ADM_Apellido,ADM_Genero,ADM_CorreoElectronico,ADM_Contrasena,ADM_Telefono,FK_CodRestaurante")] TBL_Administrador tBL_Administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_CodRestaurante = new SelectList(db.TBL_Restaurante, "PK_CodigoRestaurante", "RESTA_Nombre", tBL_Administrador.FK_CodRestaurante);
            return View(tBL_Administrador);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Administrador tBL_Administrador = db.TBL_Administrador.Find(id);
            if (tBL_Administrador == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Administrador tBL_Administrador = db.TBL_Administrador.Find(id);
            db.TBL_Administrador.Remove(tBL_Administrador);
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
