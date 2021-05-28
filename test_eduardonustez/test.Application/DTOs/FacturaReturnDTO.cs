using System;
using System.Collections.Generic;
using System.Text;

namespace test.Application
{
    public class FacturaReturnDTO
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
    }
}
