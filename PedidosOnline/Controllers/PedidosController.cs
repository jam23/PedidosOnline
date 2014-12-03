using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PedidosOnline.Models;

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

        public JsonResult GetClient(string name) {
            var client = db.Clientes.FirstOrDefault(c => c.Nombres.Contains(name));
            if (client == null)
	        {
		        return Json(new {}, JsonRequestBehavior.AllowGet);
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
    }
}
