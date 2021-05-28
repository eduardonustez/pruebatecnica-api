using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Application.Contracts;
using test.Domain;
using test.Domain.Contracts;
using test.Domain.Entities;

namespace test.Application
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public FacturaService(IFacturaRepository facturaRepository
            , IProductoRepository productoRepository
            ,IClienteRepository clienteRepository
            , IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _productoRepository = productoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(FacturaDTO facturaDTO)
        {
            Factura factura = _mapper.Map<Factura>(facturaDTO);
            factura.Fecha = DateTime.Now;
            factura.ClienteId = (await _clienteRepository.Find(c => c.NumeroDocumento == facturaDTO.NumeroDocumento)).Id;
            factura.NumeroFactura = Guid.NewGuid().ToString();
            List<FacturaDetalle> items = facturaDTO.Items.Select(i => _mapper.Map<FacturaDetalle>(i)).ToList();
            items.ForEach(async i => {
                i.Producto = await _productoRepository.GetById(i.ProductoId);
            });
            factura.SetItems(items);
            await _facturaRepository.Create(factura);
            return factura.Id;
        }

        public async Task<IEnumerable<FacturaReturnDTO>> Get()
        {
            List<Factura> facturas = (List<Factura>)await _facturaRepository.Get(x=>x.Id>0,x=>x.Cliente);
            return facturas.Select(c => _mapper.Map<FacturaReturnDTO>(c)).ToList();
        }
    }
}
