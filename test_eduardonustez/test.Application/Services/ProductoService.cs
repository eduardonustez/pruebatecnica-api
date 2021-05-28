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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public ProductoService(IProductoRepository productoRepository
            ,IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> GetById(int id)
        {
            Producto producto = (Producto)await _productoRepository.GetById(id);
            return  _mapper.Map<ProductoDTO>(producto);
        }
    }
}
