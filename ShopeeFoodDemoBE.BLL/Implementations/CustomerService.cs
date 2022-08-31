﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        public async Task<List<DtoCustomer>> GetAllCustomer()
        {
            var dtoCustomer = new List<DtoCustomer>();
            var dbCustomer = await _customerrepository.GetAllCustomer();
            dtoCustomer = dbCustomer.Select(c => new DtoCustomer
            {
                CustomerId = c.CustomerId,
                CustomerUsername = c.CustomerUsername,
                CustomerFullname = c.CustomerFullname,
                CustomerAddress = c.CustomerAddress,
                CustomerPhone = c.CustomerPhone,
                CustomerEmail = c.CustomerEmail,
                Description = c.Description,
                Status = c.Status
            }).ToList();
            return dtoCustomer;
        }

        public async Task<DtoCustomer> GetCustomerById(int id)
        {
            var dtoCustomer = new DtoCustomer();
            var dbCustomer = await _customerrepository.GetCustomerById(id);
            if (dbCustomer == null)
            {
                return await Task.FromResult<DtoCustomer>(null);
            }
            else
            {
                dtoCustomer.CustomerId = dbCustomer.CustomerId;
                dtoCustomer.CustomerUsername = dbCustomer.CustomerUsername;
                dtoCustomer.CustomerFullname = dbCustomer.CustomerFullname;
                dtoCustomer.CustomerAddress = dbCustomer.CustomerAddress;
                dtoCustomer.CustomerPhone = dbCustomer.CustomerPhone;
                dtoCustomer.CustomerEmail = dbCustomer.CustomerEmail;
                dtoCustomer.Description = dbCustomer.Description;
                dtoCustomer.Status = dbCustomer.Status;
                return dtoCustomer;
            }  
        }

        public async Task<ActionResponse> AddCustomer(CustomerRequest request)
        {
            var result = new ActionResponse();
            if (request.Status!="Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var customerUsername = await _customerrepository.GetCustomerByUsername(request.CustomerUsername);
            if (customerUsername != null)
            {
                result.Success = false;
                result.Message = "User already exist!";
                return result;
            }
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
            var addResult = await _customerrepository.AddCustomer(customer);
            if (addResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Add failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdateCustomer(CustomerRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var customer = await _customerrepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                result.Success = false;
                result.Message = "Customer not found!";
                return result;
            }
            customer.CustomerUsername = request.CustomerUsername;
            customer.CustomerPassword = request.CustomerPassword;
            customer.CustomerFullname = request.CustomerFullname;
            customer.CustomerAddress = request.CustomerAddress;
            customer.CustomerPhone = request.CustomerPhone;
            customer.CustomerEmail = request.CustomerEmail;
            customer.Description = request.Description;
            customer.Status = request.Status;
            var updateResult = await _customerrepository.UpdateCustomer(customer);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdatePasswordCustomer(RestorePasswordRequest request)
        {
            var result = new ActionResponse();
            var customer = await _customerrepository.GetCustomerById(request.CustomerId);
            if (customer == null)
            {
                result.Success = false;
                result.Message = "Customer not found!";
                return result;
            }
            if (request.CustomerPassword == request.CustomerConfirmPassword)
            {
                customer.CustomerPassword = request.CustomerConfirmPassword;
                var updateResult = await _customerrepository.UpdatePasswordCustomer(customer);
                if (updateResult)
                {
                    result.Success = true;
                    result.Message = "Successful";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Update failed!";
                }
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "Password doesn't match";
                return result;
            }
        }

        public async Task<ActionResponse> DeleteCustomer(int id)
        {
            var result = new ActionResponse();
            var dbCustomer = await _customerrepository.GetCustomerById(id);
            if (dbCustomer == null)
            {
                result.Success = false;
                result.Message = "Customer not found!";
                return result;
            }
            var deleteResult = await _customerrepository.DeleteCustomer(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
            }
            return result;
        }

        public async Task<DtoCustomer> Login(UserDtoRequest request)
        {
            var dtoCustomer = new DtoCustomer();
            var dbCustomer = await _customerrepository.GetCustomerByUsernameAndPassword(request.Username,request.Password);

            if (dbCustomer == null)
            {
                return await Task.FromResult<DtoCustomer>(null);
            }
            else
            {
                dtoCustomer.CustomerId = dbCustomer.CustomerId;
                dtoCustomer.CustomerUsername = dbCustomer.CustomerUsername;
                dtoCustomer.CustomerFullname = dbCustomer.CustomerFullname;
                dtoCustomer.CustomerAddress = dbCustomer.CustomerAddress;
                dtoCustomer.CustomerPhone = dbCustomer.CustomerPhone;
                dtoCustomer.CustomerEmail = dbCustomer.CustomerEmail;
                dtoCustomer.Description = dbCustomer.Description;
                dtoCustomer.Status = dbCustomer.Status;
                return dtoCustomer;
            }
        }

        public async Task<ActionResponse> LoginCheckPass(UserDtoRequest request)
        {
            var result = new ActionResponse();
            var dbCustomer = await _customerrepository.GetCustomerByUsername(request.Username);
            if (dbCustomer == null)
            {
                result.Success = false;
                result.Message = "User not found!";
            }
            else if (dbCustomer.CustomerPassword != request.Password)
            {
                result.Success = false;
                result.Message = "Wrong password!";
            }
            else
            {
                result.Success = true;
                result.Message = "Successful!";
            }
            return result;
        }

        public async Task<DtoCustomer> GetCustomerByUsernameAndPassword(string username,string password)
        {
            var dtoCustomer = new DtoCustomer();
            var dbCustomer = await _customerrepository.GetCustomerByUsernameAndPassword(username,password);
            if (dbCustomer == null)
            {
                return await Task.FromResult<DtoCustomer>(null);
            }
            else
            {
                dtoCustomer.CustomerId = dbCustomer.CustomerId;
                dtoCustomer.CustomerUsername = dbCustomer.CustomerUsername;
                dtoCustomer.CustomerFullname = dbCustomer.CustomerFullname;
                dtoCustomer.CustomerAddress = dbCustomer.CustomerAddress;
                dtoCustomer.CustomerPhone = dbCustomer.CustomerPhone;
                dtoCustomer.CustomerEmail = dbCustomer.CustomerEmail;
                dtoCustomer.Description = dbCustomer.Description;
                dtoCustomer.Status = dbCustomer.Status;
                return dtoCustomer;
            }
        }

        public async Task<DtoCustomer> GetCustomerByEmail(string email)
        {
            var dtoCustomer = new DtoCustomer();
            var dbCustomer = await _customerrepository.GetCustomerByEmail(email);
            if (dbCustomer == null)
            {
                return await Task.FromResult<DtoCustomer>(null);
            }
            else
            {
                dtoCustomer.CustomerId = dbCustomer.CustomerId;
                dtoCustomer.CustomerUsername = dbCustomer.CustomerUsername;
                dtoCustomer.CustomerFullname = dbCustomer.CustomerFullname;
                dtoCustomer.CustomerAddress = dbCustomer.CustomerAddress;
                dtoCustomer.CustomerPhone = dbCustomer.CustomerPhone;
                dtoCustomer.CustomerEmail = dbCustomer.CustomerEmail;
                dtoCustomer.Description = dbCustomer.Description;
                dtoCustomer.Status = dbCustomer.Status;
                return dtoCustomer;
            }
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
