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
        public async Task<List<Product>> GetProductByMenuId(int id)
        {
            var query = from p in _dataContext.Product
                        join m in _dataContext.Menu
                        on p.MenuId equals m.MenuId
                        where m.MenuId == id
                        select new { p };

            return await query.Select(x => new Product()
            {
                ProductId = x.p.ProductId,
                MenuId = x.p.MenuId,
                ProductName = x.p.ProductName,
                ProductPrice = x.p.ProductPrice,
                ProductImage = x.p.ProductImage,
                AmountStock = x.p.AmountStock,
                AmountPurchased = x.p.AmountPurchased,
                Description = x.p.Description,
                Status = x.p.Status
            }).ToListAsync();
        }
    }
}
