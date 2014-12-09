using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosOnline.Models.DTO
{


    public class Pedido {
        public PedidoHeader Header { get; set; }
        public PedidoBody Body { get; set; }
    }

    public class PedidoHeader
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PedidoBody 
    {
        public List<Articulo> Articulos { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalImpuestos { get; set; }
        public decimal TotalDescuentos { get; set; }
             
        public PedidoBody()
        {
            if (this.Articulos != null && this.Articulos.Any())
            {
                this.TotalImpuestos = this.Articulos.Sum(a => a.Precio - ((a.Impuesto / 100) * a.Precio));
                this.TotalDescuentos = this.Articulos.Sum(a => a.Precio - ((a.Descuento / 100) * a.Precio));
                this.SubTotal = this.Articulos.Sum(a => a.Precio * a.Cantidad);
            }
        }

    }

    public class Articulo
    {
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Impuesto { get; set; }

    }
}