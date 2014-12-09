using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosOnline.Models;
using PedidosOnline.Models.DTO;


namespace PedidosOnline.Controllers
{
    public class PedidosController : Controller
    {
        private MOISESEntities db = new MOISESEntities();

        //
        // GET: /Pedidos/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClient(string name)
        {
            var client = db.Clientes.FirstOrDefault(c => c.Nombres.Contains(name));
            if (client == null)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArticle(string code, string description)
        {
            var article = db.Articulos.FirstOrDefault(a => !String.IsNullOrEmpty(code) ? a.Codigo.Contains(code) : !String.IsNullOrEmpty(description) ? a.Descripcion.Contains(description) : false);
            if (article == null)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                Codigo = article.Codigo,
                Descripcion = article.Descripcion,
                Precio = article.PrecioCompra
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStore(string code, string name, string description)
        {
            var stores = db.Almacenes.FirstOrDefault(a => !String.IsNullOrEmpty(code) ? a.Codigo.Contains(code) : !String.IsNullOrEmpty(description) ? a.Descripcion.Contains(description) : false);
            return Json(new
            {
                Codigo = stores.Codigo,
                Descripcion = stores.Descripcion
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveRequest(Pedido pedido)
        {
            return Json(new { });
        }



        public JsonResult AutoComplete(string term)
        {
            string query = term.Trim().ToUpper();
            var articulos = db.Articulos.Where(a => a.Codigo.ToUpper().Contains(query) || a.Descripcion.ToUpper().Contains(query)).Select(a => new { a.Codigo, a.Descripcion, a.PrecioCompra, a.Impuesto });

            return Json(articulos, JsonRequestBehavior.AllowGet);

        }


    }
}
