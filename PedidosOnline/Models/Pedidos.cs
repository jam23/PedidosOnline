//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PedidosOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedidos
    {
        public Pedidos()
        {
            this.Pedidos_Detalles = new HashSet<Pedidos_Detalles>();
        }
    
        public int Numero { get; set; }
        public string NumeroTrans { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string Vendedor { get; set; }
        public string Terminos { get; set; }
        public decimal Descuento { get; set; }
        public bool Impuesto { get; set; }
        public string GrupoImpuesto { get; set; }
        public string Observaciones { get; set; }
        public bool Nulo { get; set; }
        public decimal Total { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal SubTotal { get; set; }
        public Nullable<int> Pedido { get; set; }
        public bool Cerrado { get; set; }
        public string Almacen { get; set; }
        public decimal FreightAmount { get; set; }
        public string CurrencyID { get; set; }
        public string SendTo { get; set; }
        public string BillTo { get; set; }
        public string Quote { get; set; }
        public string SubCompany { get; set; }
        public string NoteID { get; set; }
        public decimal PriceExchangeRate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string RTFNotes { get; set; }
        public string JobID { get; set; }
        public bool SubstractForecast { get; set; }
        public decimal FreightFactor { get; set; }
        public string CustomerPO { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public string Custom3 { get; set; }
        public string Custom4 { get; set; }
        public string Custom5 { get; set; }
        public string Custom6 { get; set; }
        public bool RequiresService { get; set; }
        public string CreatedBy { get; set; }
        public int OnHoldStatus { get; set; }
        public string ReferencedBy { get; set; }
        public string ComissionLevelID { get; set; }
        public bool Printed { get; set; }
        public string YourReference { get; set; }
        public string ShipToCustomerID { get; set; }
        public Nullable<System.DateTime> DocHour { get; set; }
        public bool Cash { get; set; }
        public string AlmacenEntrada { get; set; }
        public string OpportunityID { get; set; }
        public bool ReserveStock { get; set; }
        public string BillToAddress { get; set; }
        public string ShipToAddress { get; set; }
        public int TripQuantity { get; set; }
        public string ShipToAddressID { get; set; }
        public string BillToAddressID { get; set; }
        public string BillToCityID { get; set; }
        public string BillToStateID { get; set; }
        public string BillToCountryID { get; set; }
        public string BillToContact { get; set; }
        public string BillToPhone { get; set; }
        public string ShipToContact { get; set; }
        public string ShipToCityID { get; set; }
        public string ShipToStateID { get; set; }
        public string ShipToCountryID { get; set; }
        public string ShipToPhone { get; set; }
        public int AuthorizationNumber { get; set; }
        public string LocationID { get; set; }
        public string Secuence { get; set; }
        public string ReasonsID { get; set; }
        public Nullable<int> SalesStatus { get; set; }
        public Nullable<bool> FreightTax { get; set; }
        public System.DateTime DateCreaty { get; set; }
        public Nullable<System.DateTime> DateAutorization { get; set; }
        public string Beneficiario { get; set; }
        public string ClienteCedula { get; set; }
    
        public virtual Almacenes Almacenes { get; set; }
        public virtual Almacenes Almacenes1 { get; set; }
        public virtual Clientes Clientes { get; set; }
        public virtual Clientes Clientes1 { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Terminos Terminos1 { get; set; }
        public virtual ICollection<Pedidos_Detalles> Pedidos_Detalles { get; set; }
    }
}