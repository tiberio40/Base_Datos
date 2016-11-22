using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Base_Datos.Models;
using System.Collections;

namespace Base_Datos.Controllers
{
    public class UsuariosController : Controller
    {
        private Base_DatosContext db = new Base_DatosContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            /*if (Session["Privilegio"].Equals("True"))
            {
                return View(db.Usuarios.ToList());
            }
            else
            {
                foreach (var consulta in db.Usuarios.ToList())
                {
                    if (Session["Nick"].Equals(consulta.Nickname))
                    {

                        return View(consulta);
                    }
                 }
            }
            return RedirectToAction("Index", "Home");*/
            return View(db.Usuarios.ToList());

        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Usuario,Nickname,Nombre,Direccion,Email,Clave,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Usuario,Nickname,Nombre,Direccion,Email,Clave,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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

        public ActionResult Login()
        {
            if (Session["ID_Persona"] != null)
            {
                return RedirectToAction("Loggedin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario user)
        {
            var usr = db.Usuarios.Where(x => x.Nickname == user.Nickname && x.Clave == user.Clave).FirstOrDefault();
            if (usr != null)
            {
                Session["ID_Persona"] = usr.ID_Usuario.ToString();
                Session["Nick"] = usr.Nickname.ToString();
                Session["Nombre_Usuario"] = usr.Nombre.ToString();
                Session["Privilegio"] = usr.TipoUsuario.ToString();
                return RedirectToAction("Loggedin");
            }
            else
            {
                ModelState.AddModelError("", "Usuario o la contraseña estan mal digitados o no existen");
            }
            return View();
        }

        //CONFIRMACION INGRESO

        public ActionResult Loggedin()
        {
            if (Session["ID_Persona"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult LoginOut()
        {
            if (Session["ID_Persona"] == null)
            {
                return RedirectToAction("Login");

            }
            else
            {
                return View();
            }
        }

        //INGRESAR A LA CUENTA - FORMULARIO INGRESO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginOut(Usuario user)
        {
            if (Session["ID_Persona"] != null)
            {
                Session["ID_Persona"] = null;
                Session["Nick"] = null;
                Session["Nombre_Usuario"] = null;
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
