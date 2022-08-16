using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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
        Task<List<DtoCustomer>> GetAllCustomer();

        Task<DtoCustomer> GetCustomerById(int id);

        Task<ActionResponse> AddCustomer(CustomerRequest request);

        Task<Boolean> UpdateCustomer(CustomerRequest request);

        Task<Boolean> DeleteCustomer(int id);

        Task<Customer> Login(UserDtoRequest request);

        Task<Customer> GetCustomerByUsernameAndPassword(string username,string password);

        string CreateToken(UserDtoRequest user);

        Task<Customer> GetCustomerByEmail(string email);

        Task<Boolean> UpdatePasswordCustomer(RestorePasswordRequest request);

    }
}
