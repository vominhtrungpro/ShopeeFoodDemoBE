using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

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

                var refreshToken = GetRefreshToken();
                SetRefreshToken(refreshToken);
                return Ok(new { customer, token, refreshToken });
            }
        }

        [HttpGet("getusernameandpassword-{username}-{password}")]
        public async Task<IActionResult> GetCustomerByUsernameAndPassword(string username, string password)
        {
            var customer = await _customerService.GetCustomerByUsernameAndPassword(username, password);
            return Ok(customer);
        }

        private RefreshTokenRequest GetRefreshToken()
        {
            var refreshTokenRequest = new RefreshTokenRequest
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshTokenRequest;
        }

        private void SetRefreshToken(RefreshTokenRequest newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            RefreshTokenRespone response = new RefreshTokenRespone();

            response.Token = newRefreshToken.Token;
            response.Created = newRefreshToken.Created;
            response.Expires = newRefreshToken.Expires;
        }
    }
}
