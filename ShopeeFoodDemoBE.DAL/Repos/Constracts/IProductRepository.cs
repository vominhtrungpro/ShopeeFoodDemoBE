using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();

        Task<Product> GetProductById(int id);

        Task<Boolean> AddProduct(Product product);

        Task<Boolean> UpdateProduct(Product product);

        Task<Boolean> DeleteProduct(int id);
    }
}
