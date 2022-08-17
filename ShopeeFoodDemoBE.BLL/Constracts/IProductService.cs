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
