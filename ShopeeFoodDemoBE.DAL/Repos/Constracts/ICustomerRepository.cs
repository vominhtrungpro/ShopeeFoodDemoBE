using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomer();

        Task<Customer> GetCustomerById(int id);

        Task<Boolean> AddCustomer(Customer customer);

        Task<Boolean> UpdateCustomer(Customer customer);

        Task<Boolean> DeleteCustomer(int id);

        Task<Customer> GetCustomerByUsernameAndPassword(string username, string password);

        Task<Customer> GetCustomerByUsername(string username);

        Task<Customer> GetCustomerByEmail(string email);

        Task<Boolean> UpdatePasswordCustomer(Customer customer);
    }
}
