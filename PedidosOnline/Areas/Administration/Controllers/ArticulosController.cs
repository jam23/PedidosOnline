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
    public class ArticulosController : Controller
    {
        private MOISESEntities db = new MOISESEntities();

        //
        // GET: /Administration/Articulos/

        public ActionResult Index()
        {
            var articulos = db.Articulos.Include(a => a.Articulos2).Include(a => a.Articulos3);
            return View(articulos.ToList());
        }

        //
        // GET: /Administration/Articulos/Details/5

        public ActionResult Details(string id = null)
        {
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        //
        // GET: /Administration/Articulos/Create

        public ActionResult Create()
        {
            ViewBag.EquivalentItemID = new SelectList(db.Articulos, "Codigo", "Descripcion");
            ViewBag.OfferItemID = new SelectList(db.Articulos, "Codigo", "Descripcion");
            return View();
        }

        //
        // POST: /Administration/Articulos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquivalentItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.EquivalentItemID);
            ViewBag.OfferItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.OfferItemID);
            return View(articulos);
        }

        //
        // GET: /Administration/Articulos/Edit/5

        public ActionResult Edit(string id = null)
        {
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquivalentItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.EquivalentItemID);
            ViewBag.OfferItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.OfferItemID);
            return View(articulos);
        }

        //
        // POST: /Administration/Articulos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquivalentItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.EquivalentItemID);
            ViewBag.OfferItemID = new SelectList(db.Articulos, "Codigo", "Descripcion", articulos.OfferItemID);
            return View(articulos);
        }

        //
        // GET: /Administration/Articulos/Delete/5

        public ActionResult Delete(string id = null)
        {
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        //
        // POST: /Administration/Articulos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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