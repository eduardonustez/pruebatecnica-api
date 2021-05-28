using System;
using System.Collections.Generic;
using System.Text;

namespace test.Application
{
    public class FacturaDTO
    {
        public int TipoDePago { get; set; }
        public string NumeroDocumento { get; set; }
        public List<FacturaDetalleDTO> Items { get; set; }
    }
}
