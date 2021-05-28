using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace test.Application.Contracts
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaReturnDTO>> Get();
        Task<int> Create(FacturaDTO dto);
    }
}
