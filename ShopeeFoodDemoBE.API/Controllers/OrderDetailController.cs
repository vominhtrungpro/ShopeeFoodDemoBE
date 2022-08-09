using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderdetailService;
        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            _orderdetailService = orderdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            var orderdetail = await _orderdetailService.GetAllOrderDetail();
            return Ok(orderdetail);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderdetail = await _orderdetailService.GetOrderDetailById(id);
            return Ok(orderdetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetailRequest request)
        {
            var orderdetail = await _orderdetailService.AddOrderDetail(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailRequest request)
        {
            var orderdetail = await _orderdetailService.UpdateOrderDetail(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var orderdetail = await _orderdetailService.DeleteOrderDetail(id);
            return Ok();
        }
    }
}
