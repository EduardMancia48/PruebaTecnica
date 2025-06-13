using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppDC_Deras.Data;
using AppDC_Deras.Models;

namespace AppDC_Deras.Controllers
{
    public class ReclamoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reclamo
        public ActionResult Index()
        {
            return View(db.Reclamos.ToList());
        }

        // GET: Reclamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // GET: Reclamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Reclamo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NombreProveedor,DireccionProveedor,NombresConsumidor,ApellidosConsumidor,DUI,DetalleReclamo,MontoReclamado,Telefono")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {

                // Verificar si el DUI ya existe
                bool duiExistente = db.Reclamos.Any(r => r.DUI == reclamo.DUI);
                if (duiExistente)
                {
                    ModelState.AddModelError("DUI", "Este DUI ya ha sido registrado.");
                    return View(reclamo);
                }
                reclamo.FechaIngreso = DateTime.Now;

                db.Reclamos.Add(reclamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reclamo);
        }

        // GET: Reclamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // POST: Reclamo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclamo,NombreProveedor,DireccionProveedor,NombresConsumidor,ApellidosConsumidor,DUI,DetalleReclamo,MontoReclamado,Telefono,FechaIngreso")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reclamo);
        }

        // GET: Reclamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamos.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // POST: Reclamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamo reclamo = db.Reclamos.Find(id);
            db.Reclamos.Remove(reclamo);
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
