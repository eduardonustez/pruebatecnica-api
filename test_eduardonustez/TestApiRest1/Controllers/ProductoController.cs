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
    //[Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoService _productoService;
        public ProductoController(ILogger<ProductoController> logger,IProductoService productoService)
        {
            _logger = logger;
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ProductoDTO> GetById(int id)
        {
            return await _productoService.GetById(id);
        }
    }
}
