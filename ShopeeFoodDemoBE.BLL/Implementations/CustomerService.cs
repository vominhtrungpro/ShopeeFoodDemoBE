using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerrepository;
        private readonly IConfiguration _configuration;
        public CustomerService(ICustomerRepository customerrepository,IConfiguration configuration)
        {
            _customerrepository = customerrepository;
            _configuration = configuration;
        }

        public Task<List<Customer>> GetAllCustomer()
        {
            return _customerrepository.GetAllCustomer();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            return _customerrepository.GetCustomerById(id);
        }

        public Task<Boolean> AddCustomer(CustomerRequest request)
        {
            var customer = new Customer()
            {
                CustomerUsername = request.CustomerUsername,
                CustomerPassword = request.CustomerPassword,
                CustomerFullname = request.CustomerFullname,
                CustomerAddress = request.CustomerAddress,
                CustomerPhone = request.CustomerPhone,
                CustomerEmail = request.CustomerEmail,
                Description = request.Description,
                Status = request.Status
            };
            return _customerrepository.AddCustomer(customer);
        }

        public async Task<Boolean> UpdateCustomer(CustomerRequest request)
        {
            var customer = await _customerrepository.GetCustomerById(request.CustomerId);
            customer.CustomerUsername = request.CustomerUsername;
            customer.CustomerPassword = request.CustomerPassword;
            customer.CustomerFullname = request.CustomerFullname;
            customer.CustomerAddress = request.CustomerAddress;
            customer.CustomerPhone = request.CustomerPhone;
            customer.CustomerEmail = request.CustomerEmail;
            customer.Description = request.Description;
            customer.Status = request.Status;
            await _customerrepository.UpdateCustomer(customer);
            return true;
        }

        public async Task<Boolean> UpdatePasswordCustomer(RestorePasswordRequest request)
        {
            var customer = await _customerrepository.GetCustomerById(request.CustomerId);
            if (request.CustomerPassword == request.CustomerConfirmPassword)
            {
                customer.CustomerPassword = request.CustomerConfirmPassword;
                await _customerrepository.UpdatePasswordCustomer(customer);
                return true;
            }
            else
                return false;
        }

        public Task<Boolean> DeleteCustomer(int id)
        {
            return _customerrepository.DeleteCustomer(id);
        }

        public async Task<Customer> Login(UserDtoRequest request)
        {
            var customer = await _customerrepository.GetCustomerByUsernameAndPassword(request.Username,request.Password);

            if (customer == null)
            {
                return await Task.FromResult<Customer>(null);
            }
            else
            {
                return customer;
            }
        }

        public async Task<Customer> GetCustomerByUsernameAndPassword(string username,string password)
        {
            return await _customerrepository.GetCustomerByUsernameAndPassword(username,password);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _customerrepository.GetCustomerByEmail(email);
        }


        public string CreateToken(UserDtoRequest user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
