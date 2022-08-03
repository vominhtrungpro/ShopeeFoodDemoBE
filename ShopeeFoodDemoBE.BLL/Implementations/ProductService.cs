using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _iproductRepository;
        public ProductService(IProductRepository iproductRepository)
        {
            _iproductRepository = iproductRepository;
        }

        public Task<List<Product>> GetAllProduct()
        {
            return _iproductRepository.GetAllProduct();
        }

        public Task<Product> GetProductById(int id)
        {
            return _iproductRepository.GetProductById(id);
        }

        public Task<Boolean> AddProduct(ProductRequest request)
        {
            var product = new Product()
            {
                ProductName = request.ProductName,
                ProductImage = request.ProductImage,
                ProductPrice = request.ProductPrice,
                MenuId = request.MenuId,
                AmountStock = request.AmountStock,
                AmountPurchased = request.AmountPurchased,
                Description = request.Description,
                Status = request.Status
            };
            return _iproductRepository.AddProduct(product);
        }

        public async Task<Boolean> UpdateProduct(ProductRequest request)
        {
            var product = await _iproductRepository.GetProductById(request.ProductId);
            product.ProductName = request.ProductName;
            product.ProductImage = request.ProductImage;
            product.ProductPrice = request.ProductPrice;
            product.MenuId = request.MenuId;
            product.AmountStock = request.AmountStock;
            product.AmountPurchased = request.AmountPurchased;
            product.Description = request.Description;
            product.Status = request.Status;
            await _iproductRepository.UpdateProduct(product);
            return true;
        }

        public Task<Boolean> DeleteProduct(int id)
        {
            return _iproductRepository.DeleteProduct(id);
        }
    }
}
