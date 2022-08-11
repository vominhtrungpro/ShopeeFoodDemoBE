using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var order = await _orderService.GetAllOrder();
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequest request)
        {
            var order = await _orderService.AddOrder(request);
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequest request)
        {
            var order = await _orderService.UpdateOrder(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var order = await _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
