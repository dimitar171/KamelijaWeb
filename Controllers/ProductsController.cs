using KamelijaWeb.Data;
using KamelijaWeb.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamelijaWeb.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IKamRepository _repository;

        public ProductsController(IKamRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger; 
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders:{ex}");
                return BadRequest("Failed to get orders");
            }
        }
    }
}
