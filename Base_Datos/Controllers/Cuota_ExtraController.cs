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
    public class Cuota_ExtraController : Controller
    {
        private Base_DatosContext db = new Base_DatosContext();

        // GET: Cuota_Extra
        public ActionResult Index()
        {
            var cuota_Extra = db.Cuota_Extra.Include(c => c.Factura);
            return View(cuota_Extra.ToList());
        }

        // GET: Cuota_Extra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota_Extra cuota_Extra = db.Cuota_Extra.Find(id);
            if (cuota_Extra == null)
            {
                return HttpNotFound();
            }
            return View(cuota_Extra);
        }

        // GET: Cuota_Extra/Create
        public ActionResult Create()
        {
            ViewBag.ID_Factura = new SelectList(db.Facturas, "ID_Factura", "ID_Factura");
            return View();
        }

        // POST: Cuota_Extra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Couta_Extra,Fecha,Valor,Descripcion,ID_Factura")] Cuota_Extra cuota_Extra)
        {
            if (ModelState.IsValid)
            {
                db.Cuota_Extra.Add(cuota_Extra);
                db.SaveChanges();
                FacturasController x = new FacturasController();
                x.AgregarCargoAdicional(cuota_Extra.Valor, cuota_Extra.ID_Factura);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Factura = new SelectList(db.Facturas, "ID_Factura", "ID_Factura", cuota_Extra.ID_Factura);
            return View(cuota_Extra);
        }

        // GET: Cuota_Extra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota_Extra cuota_Extra = db.Cuota_Extra.Find(id);
            if (cuota_Extra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Factura = new SelectList(db.Facturas, "ID_Factura", "ID_Factura", cuota_Extra.ID_Factura);
            return View(cuota_Extra);
        }

        // POST: Cuota_Extra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Couta_Extra,Fecha,Valor,Descripcion,ID_Factura")] Cuota_Extra cuota_Extra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuota_Extra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Factura = new SelectList(db.Facturas, "ID_Factura", "ID_Factura", cuota_Extra.ID_Factura);
            return View(cuota_Extra);
        }

        // GET: Cuota_Extra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuota_Extra cuota_Extra = db.Cuota_Extra.Find(id);
            if (cuota_Extra == null)
            {
                return HttpNotFound();
            }
            return View(cuota_Extra);
        }

        // POST: Cuota_Extra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuota_Extra cuota_Extra = db.Cuota_Extra.Find(id);
            db.Cuota_Extra.Remove(cuota_Extra);
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
