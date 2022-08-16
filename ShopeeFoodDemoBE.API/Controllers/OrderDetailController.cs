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
                if (orderdetail.Any())
                {
                    _logger.LogInformation("Get all order detail succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all order detail ");
                    return Ok(orderdetail);
                }
                else
                {
                    _logger.LogInformation("Get all order detail failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all order detail ");
                    return BadRequest("Orderdetails not found!");
                }
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
                if (orderdetail != null)
                {
                    _logger.LogInformation("Get order detail by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get order detail by id ");
                    return Ok(orderdetail);
                }
                else
                {
                    _logger.LogInformation("Get order detail by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get order detail by id ");
                    return BadRequest("Orderdetail not found!");
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var orderdetail = await _orderdetailService.AddOrderDetail(request);
                timer.Stop();
                if (orderdetail == true)
                {
                    _logger.LogInformation("Add orderdetail {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add order detail ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add orderdetail {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add order detail ");
                    return BadRequest("Add orderdetail failed!");
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var orderdetail = await _orderdetailService.UpdateOrderDetail(request);
                timer.Stop();
                if (orderdetail == true)
                {
                    _logger.LogInformation("Update orderdetail {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update order detail ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update orderdetail {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update order detail ");
                    return BadRequest("Update orderdetail failed!");
                }
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
                if (orderdetail == true)
                {
                    _logger.LogInformation("Delete orderdetail {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete order detail ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete orderdetail {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete order detail ");
                    return BadRequest("Delete orderdetail failed!");
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
