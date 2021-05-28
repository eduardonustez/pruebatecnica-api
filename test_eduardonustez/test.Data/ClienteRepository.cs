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
    public class ClienteRepository : BaseRepository<Cliente>,IClienteRepository
    {
        public ClienteRepository(testContext context):base(context)
        {
            
        }
    }
}
