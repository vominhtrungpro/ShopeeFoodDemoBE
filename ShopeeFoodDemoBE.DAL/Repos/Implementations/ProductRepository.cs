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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dataContext.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dataContext.Product.FindAsync(id);
        }

        public async Task<Boolean> AddProduct(Product product)
        {
            _dataContext.Product.Add(product);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateProduct(Product product)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            _dataContext.Product.Remove(product);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
