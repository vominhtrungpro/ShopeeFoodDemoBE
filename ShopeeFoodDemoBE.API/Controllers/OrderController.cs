using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all order ");
            try
            {
                var order = await _orderService.GetAllOrder();
                timer.Stop();
                _logger.LogInformation("Get all order succeed in {0} s", timer.Elapsed.TotalSeconds);
                return Ok(order);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get order by id ");
            try
            {
                var order = await _orderService.GetOrderById(id);
                timer.Stop();
                _logger.LogInformation("Get order by id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok(order);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add order ");
            try
            {
                var order = await _orderService.AddOrder(request);
                timer.Stop();
                _logger.LogInformation("Add order succeed in {0} s", timer.Elapsed.TotalSeconds);
                return Ok(order);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update order ");
            try
            {
                var order = await _orderService.UpdateOrder(request);
                timer.Stop();
                _logger.LogInformation("Update order {0} succeed in {1} s", request.OrderId, timer.Elapsed.TotalSeconds);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete order ");
            try
            {
                var order = await _orderService.DeleteOrder(id);
                timer.Stop();
                _logger.LogInformation("Delete order {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }
    }
}
