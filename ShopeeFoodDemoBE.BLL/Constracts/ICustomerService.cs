using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

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

        Task<ActionResponse> LoginCheckPass(UserDtoRequest request);

        Task<DtoCustomer> GetCustomerByUsernameAndPassword(string username,string password);

        string CreateToken(UserDtoRequest user);

        Task<DtoCustomer> GetCustomerByEmail(string email);

        Task<ActionResponse> UpdatePasswordCustomer(RestorePasswordRequest request);

    }
}
