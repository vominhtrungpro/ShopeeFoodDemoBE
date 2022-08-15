using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderdetailService;
        private readonly ILogger<OrderDetailController> _logger;
        public OrderDetailController(IOrderDetailService orderdetailService, ILogger<OrderDetailController> logger)
        {
            _orderdetailService = orderdetailService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all order detail ");
            try
            {
                var orderdetail = await _orderdetailService.GetAllOrderDetail();
                timer.Stop();
                _logger.LogInformation("Get all order detail succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all order detail ");
                return Ok(orderdetail);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get order detail by id ");
            try
            {
                var orderdetail = await _orderdetailService.GetOrderDetailById(id);
                timer.Stop();
                _logger.LogInformation("Get order detail by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get order detail by id ");
                return Ok(orderdetail);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetailRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add order detail ");
            try
            {
                var orderdetail = await _orderdetailService.AddOrderDetail(request);
                timer.Stop();
                _logger.LogInformation("Add order detail order id: {0},product id: {1},amount: {2},price: {3} succeed in {4} ms", request.OrderId, request.ProductId, request.Amount, request.Price, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add order detail ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update order detail ");
            try
            {
                var orderdetail = await _orderdetailService.UpdateOrderDetail(request);
                timer.Stop();
                _logger.LogInformation("Update order detail id: {0}, order id: {1},product id: {2},amount: {3},price: {4} succeed in {5} ms",request.OrderDetailId, request.OrderId, request.ProductId, request.Amount, request.Price, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update order detail ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete order detail ");
            try
            {
                var orderdetail = await _orderdetailService.DeleteOrderDetail(id);
                timer.Stop();
                _logger.LogInformation("Delete order detail {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete order detail ");
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
