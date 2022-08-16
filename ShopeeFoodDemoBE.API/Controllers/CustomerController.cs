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
using System.Text.Json;

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
                var customer = await _customerService.GetAllCustomer();
                timer.Stop();
                if (customer.Any())
                {
                    _logger.LogInformation("Get all customer succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all customer");
                    return Ok(customer);
                }
                else
                {
                    _logger.LogInformation("Get all customer failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all customer");
                    return BadRequest("Customers not found!");
                } 
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                var customer = await _customerService.GetCustomerById(id);
                timer.Stop();
                if (customer != null)
                {
                    _logger.LogInformation("Get customer by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get customer by id");
                    return Ok(customer);
                }
                else
                {
                    _logger.LogInformation("Get customer by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get customer by id");
                    return BadRequest("Customer not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var customer = await _customerService.AddCustomer(request);
                timer.Stop();
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("Add customer {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds, ModelState);
                    _logger.LogInformation("End add customer by id");
                    return BadRequest(ModelState);
                }
                if (customer.Success)
                {
                    _logger.LogInformation("Add customer {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add customer by id");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add customer {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds, customer.Message);
                    _logger.LogInformation("End add customer by id");
                    return BadRequest(customer.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var customer = await _customerService.UpdateCustomer(request);
                timer.Stop();
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("Update customer {0} failed in {1} ms with message {2} ", jsonString, timer.Elapsed.TotalMilliseconds, ModelState);
                    _logger.LogInformation("End Update customer by id");
                    return BadRequest(ModelState);
                }
                if (customer.Success)
                {
                    _logger.LogInformation("Update customer {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End Update customer by id");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update customer {0} failed in {1} ms with message {2} ", jsonString, timer.Elapsed.TotalMilliseconds,customer.Message);
                    _logger.LogInformation("End Update customer by id");
                    return BadRequest(customer.Message);
                }
                

            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                if (customer == true)
                {
                    _logger.LogInformation("Delete customer {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete customer by id");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete customer {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete customer by id");
                    return BadRequest("Delete customer failed!");
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var customer = await _customerService.Login(request);
                string token = _customerService.CreateToken(request);
                var refreshToken = GetRefreshToken();
                SetRefreshToken(refreshToken);
                timer.Stop();
                if (customer == null)
                {
                    _logger.LogInformation("Login user {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End login");
                    return BadRequest("User not found!");
                }
                    
                else
                {
                    _logger.LogInformation("Login user {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End login");
                    return Ok(new { customer, token, refreshToken });
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                if (customer != null)
                {
                    _logger.LogInformation("get customer by username: {0},password: {1} succeed in {0} s", username, password, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get username and password");
                    return Ok(customer);
                }
                else
                {
                    _logger.LogInformation("get customer by username: {0},password: {1} failed in {0} s", username, password, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get username and password");
                    return BadRequest("Customer not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                if (customer != null)
                {
                    _logger.LogInformation("get customer by email {0} succeed in {1} ms", email, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get customer by email");
                    return Ok(customer);
                }
                else
                {
                    _logger.LogInformation("get customer by email {0} failed in {1} ms", email, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get customer by email");
                    return BadRequest("Customer not found!");
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
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
                string jsonString = JsonSerializer.Serialize(request);
                var customer = await _customerService.UpdatePasswordCustomer(request);
                timer.Stop();
                if (customer == true)
                {
                    _logger.LogInformation("Update customer {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update customer password");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update customer {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update customer password");
                    return BadRequest("Update password failed!");
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
