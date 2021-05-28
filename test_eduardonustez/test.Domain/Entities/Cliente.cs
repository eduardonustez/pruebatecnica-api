using System;
using System.Collections.Generic;
using System.Text;

namespace test.Domain.Entities
{
    public class Cliente:EntidadBase
    {
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public virtual IEnumerable<Factura> Facturas { get; set; }
    }
}
