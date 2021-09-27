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
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IKamRepository _repository;

        public OrdersController(IKamRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger; 
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok( _repository.GetAllOrders());
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get orders:{ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order != null) return Ok(order);
                else return NotFound();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders:{ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Order model)
        {
            try
            {
                _repository.AddEntity(model);
                if (_repository.SaveChanges())
                {

                    return Created($"/api/orders/{model.Id}", model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order:{ex}");
               
            }
            return BadRequest("Failed to save orders");
        }
    }
}
