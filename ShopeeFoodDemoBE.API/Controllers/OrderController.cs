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
                _logger.LogInformation("Get all order succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all order ");
                return Ok(order);
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
                _logger.LogInformation("Get order by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get order by id ");
                return Ok(order);
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
                var order = await _orderService.AddOrder(request);
                timer.Stop();
                _logger.LogInformation("Add order customer id: {0},total price: {1},time order: {2},place order: {3},description: {4},status: {5} succeed in {6} ms", request.CustomerId, request.TotalPrice, request.TimeOrder, request.PlaceOrder, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add order ");
                return Ok(order);
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
                var order = await _orderService.UpdateOrder(request);
                timer.Stop();
                _logger.LogInformation("Update order id: {0}, customer id: {1},total price: {2},time order: {3},place order: {4},description: {5},status: {6} succeed in {7} ms",request.OrderId, request.CustomerId, request.TotalPrice, request.TimeOrder, request.PlaceOrder, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update order ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                _logger.LogInformation("Delete order {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete order ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
    }
}
