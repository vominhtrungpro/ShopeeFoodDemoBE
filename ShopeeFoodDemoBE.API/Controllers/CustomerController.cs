using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System.Diagnostics;
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
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all customer");
            try
            {
                timer.Stop();
                _logger.LogInformation("Get all customer succeed in {0} s", timer.Elapsed.TotalSeconds);
                return Ok(await _customerService.GetAllCustomer());
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get customer by id");
            try
            {
                timer.Stop();
                _logger.LogInformation("Get customer by id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok(await _customerService.GetCustomerById(id));
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add customer by id");
            try
            {
                var customer = await _customerService.AddCustomer(request);
                timer.Stop();
                _logger.LogInformation("Add customer {0} succeed in {1} s", request.CustomerFullname, timer.Elapsed.TotalSeconds);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update customer by id");
            try
            {
                var customer = await _customerService.UpdateCustomer(request);
                timer.Stop();
                _logger.LogInformation("Update customer {0} succeed in {1} s", request.CustomerId, timer.Elapsed.TotalSeconds);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete customer by id");
            try
            {
                var customer = await _customerService.DeleteCustomer(id);
                timer.Stop();
                _logger.LogInformation("Delete customer {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            } 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDtoRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start login");
            try
            {
                var customer = await _customerService.Login(request);
                if (customer == null)
                    return BadRequest("User not found");
                else
                {
                    string token = _customerService.CreateToken(request);
                    var refreshToken = GetRefreshToken();
                    SetRefreshToken(refreshToken);
                    timer.Stop();
                    _logger.LogInformation("Login succeed in {0} s", timer.Elapsed.TotalSeconds);
                    return Ok(new { customer, token, refreshToken });
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("getusernameandpassword-{username}-{password}")]
        public async Task<IActionResult> GetCustomerByUsernameAndPassword(string username, string password)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get username and password");
            try
            {
                var customer = await _customerService.GetCustomerByUsernameAndPassword(username, password);
                timer.Stop();
                _logger.LogInformation("get succeed in {0} s", timer.Elapsed.TotalSeconds);
                return Ok(customer);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("getemail-{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get customer by email");
            try
            {
                var customer = await _customerService.GetCustomerByEmail(email);
                timer.Stop();
                _logger.LogInformation("get succeed email {0} in {1} s", email, timer.Elapsed.TotalSeconds);
                return Ok(customer);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error", e);
                throw new Exception();
            }            
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

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePasswordCustomer(RestorePasswordRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update customer password");
            try
            {
                var customer = await _customerService.UpdatePasswordCustomer(request);
                timer.Stop();
                _logger.LogInformation("Update customer {0} password succeed in {1} s", request.CustomerId, timer.Elapsed.TotalSeconds);
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
