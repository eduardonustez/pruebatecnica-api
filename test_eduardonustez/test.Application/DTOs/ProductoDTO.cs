using System;
using System.Collections.Generic;
using System.Text;

namespace test.Application
{
    public class ProductoDTO
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public short Descuento { get; set; }
        public decimal ValorDescuento { 
            get {
                return Precio * Descuento / 100;
            }
            private set { } 
            }
        public short IVA { get; set; }
        public decimal ValorIVA
        {
            get
            {
                return Precio * IVA / 100;
            }
            private set { }
        }
    }
}
