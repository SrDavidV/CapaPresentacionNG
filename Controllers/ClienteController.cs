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
    public class ClienteController : Controller
    {
        private DBS_NEIGHBORFOOD2Entities db = new DBS_NEIGHBORFOOD2Entities();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.TBL_Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = db.TBL_Cliente.Find(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_Cedula_Cliente,CLI_Nombre,CLI_Apellido,CLI_Genero,CLI_CorreoElectronico,CLI_FechaNacimiento,CLI_Ciudad,CLI_Barrio,CLI_Telefono,CLI_Contrasena")] TBL_Cliente tBL_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Cliente.Add(tBL_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = db.TBL_Cliente.Find(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_Cedula_Cliente,CLI_Nombre,CLI_Apellido,CLI_Genero,CLI_CorreoElectronico,CLI_FechaNacimiento,CLI_Ciudad,CLI_Barrio,CLI_Telefono,CLI_Contrasena")] TBL_Cliente tBL_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Cliente tBL_Cliente = db.TBL_Cliente.Find(id);
            if (tBL_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Cliente tBL_Cliente = db.TBL_Cliente.Find(id);
            db.TBL_Cliente.Remove(tBL_Cliente);
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
