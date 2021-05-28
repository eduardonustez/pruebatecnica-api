using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace test.Application.Contracts
{
    public interface IProductoService
    {
        Task<ProductoDTO> GetById(int id);
    }
}
