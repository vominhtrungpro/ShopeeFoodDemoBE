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

        Task<ActionResponse> UpdateCustomer(CustomerRequest request);

        Task<ActionResponse> DeleteCustomer(int id);

        Task<DtoCustomer> Login(UserDtoRequest request);

        Task<DtoCustomer> GetCustomerByUsernameAndPassword(string username,string password);

        string CreateToken(UserDtoRequest user);

        Task<DtoCustomer> GetCustomerByEmail(string email);

        Task<ActionResponse> UpdatePasswordCustomer(RestorePasswordRequest request);

    }
}
