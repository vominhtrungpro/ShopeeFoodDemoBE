using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;
using System.Text.Json;

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
                if (order.Any())
                {
                    _logger.LogInformation("Get all order succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all order ");
                    return Ok(order);
                }
                else
                {
                    _logger.LogInformation("Get all order failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all order ");
                    return BadRequest("Orders not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                if (order != null)
                {
                    _logger.LogInformation("Get order by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get order by id ");
                    return Ok(order);
                }
                else
                {
                    _logger.LogInformation("Get order by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get order by id ");
                    return BadRequest("Order not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var order = await _orderService.AddOrder(request);
                timer.Stop();
                if (order != null)
                {
                    _logger.LogInformation("Add order {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add order ");
                    return Ok(order);
                }
                else
                {
                    _logger.LogInformation("Add order {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add order ");
                    return BadRequest("Add order failed!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var order = await _orderService.UpdateOrder(request);
                timer.Stop();
                if (order == true)
                {
                    _logger.LogInformation("Update order {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update order ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update order {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update order ");
                    return BadRequest("Update order failed!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete order ");
            try
            {
                var order = await _orderService.DeleteOrder(id);
                timer.Stop();
                if (order == true)
                {
                    _logger.LogInformation("Delete order {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete order ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete order {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete order ");
                    return BadRequest("Delete order failed!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
    }
}
