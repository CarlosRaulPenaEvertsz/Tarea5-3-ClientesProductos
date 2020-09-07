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
    public class ProductosController : Controller
    {
        private ClientesProductosDBEntities db = new ClientesProductosDBEntities();

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUpload(Producto Prod, HttpPostedFileBase file)
        //public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Prod.ImageUrl = file.FileName;
            if (file != null && ModelState.IsValid)
            { 
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("/Imagenes/" + ImageName);
                file.SaveAs(physicalPath);
                
                Prod.Producto1 = Request.Form["Producto1"];
                Prod.Descripcion = Request.Form["Descripcion"];
                Prod.Precio = float.Parse(Request.Form["Precio"]);
                Prod.CantExistencia = int.Parse(Request.Form["CantExistencia"]);
                Prod.ImageUrl = ImageName;
                db.Productos.Add(Prod);
                db.SaveChanges();
                return RedirectToAction("../Productos/Index/");

            }
            if (file == null)
            {
                TempData["ErrorFoto"] = "La Foto es Obligatoria";
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUploadUpdate(Producto Prod, HttpPostedFileBase file)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            Prod.ImageUrl = file.FileName;
            if (file != null && ModelState.IsValid)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("/Imagenes/" + ImageName);
                file.SaveAs(physicalPath);
                Prod.Producto1 = Request.Form["Producto1"];
                Prod.Descripcion = Request.Form["Descripcion"];
                Prod.Precio = float.Parse(Request.Form["Precio"]);
                Prod.CantExistencia = int.Parse(Request.Form["CantExistencia"]);
                Prod.ImageUrl = ImageName;
                db.Entry(Prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Productos/Index/");
            }
            if (file == null)
            {
                TempData["ErrorFoto"] = "La Foto es Obligatoria";
            }
            return View();
        }










        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,Producto1,Descripcion,Precio,CantExistencia,ImageUrl")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,Producto1,Descripcion,Precio,CantExistencia,ImageUrl")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
