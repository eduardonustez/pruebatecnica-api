using System;
using System.Collections.Generic;
using System.Text;
using test.Domain.Enums;

namespace test.Domain.Entities
{
    public class Factura:EntidadBase
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public TipoPago TipoDePago { get; set; }
        public int ClienteId { get; set; }
        public decimal Subtotal { get; private set; }
        public decimal TotalDescuento { get; private set; }
        public decimal TotalImpuesto { get; private set; }
        public decimal Total { get; private set; }
        public virtual Cliente Cliente { get; set; }
        public virtual IEnumerable<FacturaDetalle> Items { get; private set; }

        public Factura()
        {
            Items = new List<FacturaDetalle>();
        }
        public void SetItems(List<FacturaDetalle> items)
        {
            Items = items;
            foreach(FacturaDetalle item in items)
            {
                Producto producto = item.Producto;
                Subtotal +=  producto.Precio * item.Cantidad;
                TotalDescuento += (producto.Precio * producto.Descuento / 100) * item.Cantidad;
                TotalImpuesto += (producto.Precio * producto.IVA / 100) * item.Cantidad;
            }
            Total = Subtotal - TotalDescuento + TotalImpuesto;
        }

    }
}
