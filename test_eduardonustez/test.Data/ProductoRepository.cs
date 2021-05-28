using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Domain;
using test.Domain.Contracts;
using test.Domain.Entities;

namespace test.Data
{
    public class ProductoRepository : BaseRepository<Producto>,IProductoRepository
    {
        public ProductoRepository(testContext context):base(context)
        {
            
        }
    }
}
