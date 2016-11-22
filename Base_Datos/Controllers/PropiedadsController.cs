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
    public class PropiedadsController : Controller
    {
        private Base_DatosContext db = new Base_DatosContext();

        // GET: Propiedads
        public ActionResult Index()
        {
            var propiedads = db.Propiedads.Include(p => p.Usuario);
            return View(propiedads.ToList());
        }

        // GET: Propiedads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedads.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            return View(propiedad);
        }

        // GET: Propiedads/Create
        public ActionResult Create()
        {
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname");
            return View();
        }

        // POST: Propiedads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Propiedad,Area,Direccion,Telefono,ID_Usuario")] Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                if (Session["Privilegio"].Equals("True"))
                {
                    db.Propiedads.Add(propiedad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    db.Propiedads.Add(propiedad);
                    db.Propiedads.Add(propiedad).ID_Usuario = Convert.ToInt16(Session["ID_Persona"]);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }

            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", propiedad.ID_Usuario);
            return View(propiedad);
        }

        // GET: Propiedads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedads.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", propiedad.ID_Usuario);
            return View(propiedad);
        }

        // POST: Propiedads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Propiedad,Area,Direccion,Telefono,ID_Usuario")] Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propiedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Usuario = new SelectList(db.Usuarios, "ID_Usuario", "Nickname", propiedad.ID_Usuario);
            return View(propiedad);
        }

        // GET: Propiedads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propiedad propiedad = db.Propiedads.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            return View(propiedad);
        }

        // POST: Propiedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propiedad propiedad = db.Propiedads.Find(id);
            db.Propiedads.Remove(propiedad);
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
