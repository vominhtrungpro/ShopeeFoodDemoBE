using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;
        public CustomerController(ICustomerService customerService,IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDtoRequest request)
        {
            var customer = await _customerService.Login(request);

            if (customer == null)
                return BadRequest("User not found");
            else
            {
                string token = _customerService.CreateToken(request);
                return Ok(new { customer, token });
            }
        }

        [HttpGet("getusernameandpassword-{username}-{password}")]
        public async Task<IActionResult> GetCustomerByUsernameAndPassword(string username, string password)
        {
            var customer = await _customerService.GetCustomerByUsernameAndPassword(username, password);
            return Ok(customer);
        }
    }
}
