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
    public class TelefonosController : Controller
    {
        private Base_DatosContext db = new Base_DatosContext();

        // GET: Telefonos
        public ActionResult Index()
        {
            var telefonoes = db.Telefonoes.Include(t => t.Usuario);
            return View(telefonoes.ToList());
        }

        // GET: Telefonos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // GET: Telefonos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname");
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Telefono,NoTelefonico,ID_Usuario")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Telefonoes.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", telefono.ID_Usuario);
            return View(telefono);
        }

        // GET: Telefonos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", telefono.ID_Usuario);
            return View(telefono);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Telefono,NoTelefonico,ID_Usuario")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", telefono.ID_Usuario);
            return View(telefono);
        }

        // GET: Telefonos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefonoes.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefonoes.Find(id);
            db.Telefonoes.Remove(telefono);
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
