using System;
using System.Collections.Generic;
using System.Text;

namespace test.Domain.Entities
{
    public class FacturaDetalle:EntidadBase
    {
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
