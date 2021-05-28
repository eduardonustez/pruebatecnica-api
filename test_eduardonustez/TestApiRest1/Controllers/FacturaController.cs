using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test.Application;
using test.Application.Contracts;

namespace TestApiRest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;
        private readonly IFacturaService _facturaService;
        public FacturaController(ILogger<FacturaController> logger,IFacturaService facturaService)
        {
            _logger = logger;
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<IEnumerable<FacturaReturnDTO>> Get()
        {
            return await _facturaService.Get();
        }

        [HttpPost]
        public async Task<IActionResult> Post(FacturaDTO facturaDTO)
        {
            await _facturaService.Create(facturaDTO);
            return Ok("Nuevo cliente agregado!");
        }
    }
}
