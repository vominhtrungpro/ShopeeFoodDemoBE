using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomer();

        Task<Customer> GetCustomerById(int id);

        Task<Boolean> AddCustomer(CustomerRequest request);

        Task<Boolean> UpdateCustomer(CustomerRequest request);

        Task<Boolean> DeleteCustomer(int id);
    }
}
