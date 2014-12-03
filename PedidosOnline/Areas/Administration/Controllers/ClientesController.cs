using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosOnline.Models;

namespace PedidosOnline.Areas.Administration.Controllers
{
    public class ClientesController : Controller
    {
        private MOISESEntities db = new MOISESEntities();

        //
        // GET: /Administration/Clientes/

        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Empleados).Include(c => c.Monedas).Include(c => c.Terminos1).Include(c => c.Empleados1).Include(c => c.Empleados2);
            return View(clientes.ToList());
        }

        //
        // GET: /Administration/Clientes/Details/5

        public ActionResult Details(string id = null)
        {
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // GET: /Administration/Clientes/Create

        public ActionResult Create()
        {
            ViewBag.ARResponsible = new SelectList(db.Empleados, "Codigo", "Apellidos");
            ViewBag.CurrencyID = new SelectList(db.Monedas, "Codigo", "Descripcion");
            ViewBag.Terminos = new SelectList(db.Terminos, "Codigo", "Descripcion");
            ViewBag.Vendedor = new SelectList(db.Empleados, "Codigo", "Apellidos");
            ViewBag.Repartidor = new SelectList(db.Empleados, "Codigo", "Apellidos");
            return View();
        }

        //
        // POST: /Administration/Clientes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ARResponsible = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.ARResponsible);
            ViewBag.CurrencyID = new SelectList(db.Monedas, "Codigo", "Descripcion", clientes.CurrencyID);
            ViewBag.Terminos = new SelectList(db.Terminos, "Codigo", "Descripcion", clientes.Terminos);
            ViewBag.Vendedor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Vendedor);
            ViewBag.Repartidor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Repartidor);
            return View(clientes);
        }

        //
        // GET: /Administration/Clientes/Edit/5

        public ActionResult Edit(string id = null)
        {
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ARResponsible = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.ARResponsible);
            ViewBag.CurrencyID = new SelectList(db.Monedas, "Codigo", "Descripcion", clientes.CurrencyID);
            ViewBag.Terminos = new SelectList(db.Terminos, "Codigo", "Descripcion", clientes.Terminos);
            ViewBag.Vendedor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Vendedor);
            ViewBag.Repartidor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Repartidor);
            return View(clientes);
        }

        //
        // POST: /Administration/Clientes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ARResponsible = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.ARResponsible);
            ViewBag.CurrencyID = new SelectList(db.Monedas, "Codigo", "Descripcion", clientes.CurrencyID);
            ViewBag.Terminos = new SelectList(db.Terminos, "Codigo", "Descripcion", clientes.Terminos);
            ViewBag.Vendedor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Vendedor);
            ViewBag.Repartidor = new SelectList(db.Empleados, "Codigo", "Apellidos", clientes.Repartidor);
            return View(clientes);
        }

        //
        // GET: /Administration/Clientes/Delete/5

        public ActionResult Delete(string id = null)
        {
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // POST: /Administration/Clientes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}