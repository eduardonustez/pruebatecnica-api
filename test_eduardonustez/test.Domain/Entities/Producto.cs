using System;

namespace test.Domain.Entities
{
    public class Producto:EntidadBase
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public short Descuento { get; set; }
        public short IVA { get; set; }
    }
}
