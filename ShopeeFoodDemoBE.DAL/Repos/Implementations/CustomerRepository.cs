using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _dataContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dataContext.Customer.FindAsync(id);
        }

        public async Task<Boolean> AddCustomer(Customer customer)
        {
            _dataContext.Customer.Add(customer);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateCustomer(Customer customer)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteCustomer(int id)
        {
            var customer = await GetCustomerById(id);
            _dataContext.Customer.Remove(customer);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomerByUsernameAndPassword(string username,string password)
        {
            return _dataContext.Customer.SingleOrDefault(c => c.CustomerUsername == username && c.CustomerPassword==password);
        }


    }
}
