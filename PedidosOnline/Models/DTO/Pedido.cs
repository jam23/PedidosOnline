using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosOnline.Models.DTO
{


    public class Pedido {
        public PedidoHeader Header { get; set; }
        public PedidoBody Body { get; set; }
        public decimal Total
        {
            get
            {
                return Body.SubTotal + this.Impuestos;
            }
        }
        public decimal Impuestos
        {
            get
            {
                return Body.TotalImpuestos;
            }
        }
        public decimal Descuentos
        {
            get
            {
                return Body.TotalDescuentos;
            }
        }
    }

    public class PedidoHeader
    {
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class PedidoBody 
    {
        public List<Articulo> Articulos { get; set; }
        public decimal SubTotal
        {
            get
            {
                return this.Articulos.Sum(a => a.Precio * a.Cantidad);
            }
        }
        public decimal TotalImpuestos
        {
            get
            {
                return this.Articulos.Sum(a => a.Precio - ((a.Impuesto / 100) * a.Precio));
            }

        }
        public decimal TotalDescuentos
        {
            get
            {
                return this.Articulos.Sum(a => a.Precio - ((a.Descuento / 100) * a.Precio));
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