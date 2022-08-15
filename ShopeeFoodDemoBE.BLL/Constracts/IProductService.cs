using ShopeeFoodDemoBE.BLL.Models.Requests;
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
        Task<List<Product>> GetAllProduct();

        Task<Product> GetProductById(int id);

        Task<Boolean> AddProduct(ProductRequest request);

        Task<Boolean> UpdateProduct(ProductRequest request);

        Task<Boolean> DeleteProduct(int id);

        Task<List<Product>> GetProductByMenuId(int id);
    }
}
