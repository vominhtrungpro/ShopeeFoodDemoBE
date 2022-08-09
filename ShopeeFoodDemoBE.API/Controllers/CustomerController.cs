using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _customerService.GetAllCustomer();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequest request)
        {
            var customer = await _customerService.AddCustomer(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest request)
        {
            var customer = await _customerService.UpdateCustomer(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
