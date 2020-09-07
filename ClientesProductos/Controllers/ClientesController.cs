using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientesProductos.Models;

namespace ClientesProductos.Controllers
{
    public class ClientesController : Controller
    {
        private ClientesProductosDBEntities db = new ClientesProductosDBEntities();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUpload(Cliente Client, HttpPostedFileBase file)
        //public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Client.ImageUrl = file.FileName;
            if (file != null && ModelState.IsValid)
            {
                //EstudianteDBEntities db = new EstudianteDBEntities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("/Imagenes/" + ImageName);
                file.SaveAs(physicalPath);
                //tblEstudiante estudiante = new tblEstudiante();
                Client.Nombres = Request.Form["Nombres"];
                Client.Apellidos = Request.Form["Apellidos"];
                Client.Direccion = Request.Form["Direccion"];
                Client.Telefono = Request.Form["Telefono"];
                Client.Movil = Request.Form["Movil"];
                Client.Email = Request.Form["Email"];
                Client.ImageUrl = ImageName;
                db.Clientes.Add(Client);
                db.SaveChanges();
                //return RedirectToAction("Index","Cliente","Index");
                return RedirectToAction("../Clientes/Index/");
                
            }
            if (file == null)
            {
                TempData["ErrorFoto"] = "La Foto es Obligatoria";
            }
            return View();
            //return View("Estudiantes");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUploadUpdate(Cliente Client, HttpPostedFileBase file)
        //public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Client.ImageUrl = file.FileName;
            if (file != null && ModelState.IsValid)
            {
                //EstudianteDBEntities db = new EstudianteDBEntities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("/Imagenes/" + ImageName);
                file.SaveAs(physicalPath);
                //tblEstudiante estudiante = new tblEstudiante();
                Client.Nombres = Request.Form["Nombres"];
                Client.Apellidos = Request.Form["Apellidos"];
                Client.Direccion = Request.Form["Direccion"];
                Client.Telefono = Request.Form["Telefono"];
                Client.Movil = Request.Form["Movil"];
                Client.Email = Request.Form["Email"];
                Client.ImageUrl = ImageName;
                db.Entry(Client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Clientes/Index/");
            }
            if (file == null)
            {
                TempData["ErrorFoto"] = "La Foto es Obligatoria";
            }
            return View();
        }










        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteId,Nombres,Apellidos,Direccion,Email,Telefono,Movil,ImageUrl")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,Nombres,Apellidos,Direccion,Email,Telefono,Movil,ImageUrl")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
