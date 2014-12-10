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
            ViewBag.CodigoPedido = String.Format("{0:ddMMyyhhmmss}-{1}",
                DateTime.Now, Guid.NewGuid().ToString().Substring(0, 4));

            ViewBag.Almacenes = new SelectList(db.Almacenes.Select(a => new
            {
                a.Codigo,
                a.Descripcion
            }), "Codigo", "Descripcion");

            return View();
        }


        [HttpPost]
        public JsonResult SaveRequest(Pedido pedido)
        {

            var _pedido = new Pedidos
            {
                Cliente = pedido.Header.ClienteId.ToString(),
                Almacen = pedido.Header.AlmacenId.ToString()
            };
            db.Pedidos.Add(_pedido);
            pedido.Body.Articulos.ForEach(a => {
                var _detalle = new Pedidos_Detalles
                {
                    Pedidos = _pedido,
                    Articulos = new Articulos
                    {
                        Codigo = a.Codigo
                    },
                    Descuento = a.Descuento,
                    Cantidad = a.Cantidad,
                    MontoImpuesto = a.Impuesto
                };
                db.Pedidos_Detalles.Add(_detalle);
            });
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {                
                throw e;
            }
            return Json(new { });
        }

        public JsonResult AutoCompleteArticulo(string term)
        {
            string query = term.Trim().ToUpper();

            var articulos = db.Articulos.Where(a => a.Codigo.ToUpper().Contains(query) || a.Descripcion.ToUpper().Contains(query))
                                     .Select(a => new
                                     {
                                         a.Codigo,
                                         a.Descripcion,
                                         a.PrecioCompra,
                                         a.Impuesto
                                     });
            return Json(articulos, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AutoCompleteCliente(string term)
        {
            string query = term.Trim().ToUpper();
            var cliente = db.Clientes.Where(c => c.Codigo.ToUpper().Contains(query) || c.Nombres.ToUpper().Contains(query) || c.Apellidos.ToUpper().Contains(query))
                           .Select(c => new
                           {
                               c.RazonSocial,
                               c.Categoria,
                               c.Repartidor,
                               c.Codigo,
                               c.Nombres,
                               c.Apellidos,
                               c.Cedula
                           });

            return Json(cliente, JsonRequestBehavior.AllowGet);

        }


    }
}
