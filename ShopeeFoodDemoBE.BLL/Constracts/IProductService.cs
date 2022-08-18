using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IProductService
    {
        Task<List<DtoProduct>> GetAllProduct();

        Task<DtoProduct> GetProductById(int id);

        Task<ActionResponse> AddProduct(ProductRequest request);

        Task<ActionResponse> UpdateProduct(ProductRequest request);

        Task<ActionResponse> DeleteProduct(int id);

        Task<List<DtoProduct>> GetProductByMenuId(int id);
    }
}
