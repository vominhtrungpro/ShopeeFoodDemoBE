using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerrepository;
        public CustomerService(ICustomerRepository customerrepository)
        {
            _customerrepository = customerrepository;
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

        public Task<Boolean> DeleteCustomer(int id)
        {
            return _customerrepository.DeleteCustomer(id);
        }
    }
}
