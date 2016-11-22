using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Base_Datos.Models;

namespace Base_Datos.Controllers
{
    public class FacturasController : Controller
    {
        private Base_DatosContext db = new Base_DatosContext();

        // GET: Facturas

        public void AgregarCargoAdicional(double valor, int id)
        {
            Factura factura = db.Facturas.Find(id);
            factura.ValorFinal = factura.ValorFinal + valor;
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                
            }
;
        }
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Propiedad);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Propiedad = new SelectList(db.Propiedads, "ID_Propiedad", "Direccion");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Factura,Fecha,Administracion,ValorFinal,FechaPago,EstadoPago,ID_Propiedad")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.Facturas.Add(factura).ValorFinal = factura.Administracion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Propiedad = new SelectList(db.Propiedads, "ID_Propiedad", "Direccion", factura.ID_Propiedad);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Propiedad = new SelectList(db.Propiedads, "ID_Propiedad", "Direccion", factura.ID_Propiedad);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Factura,Fecha,Administracion,ValorFinal,FechaPago,EstadoPago,ID_Propiedad")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Propiedad = new SelectList(db.Propiedads, "ID_Propiedad", "Direccion", factura.ID_Propiedad);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
