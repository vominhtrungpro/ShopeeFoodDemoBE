using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<DtoProduct>> GetAllProduct()
        {
            var dtoProduct = new List<DtoProduct>();
            var dbProduct = await _productRepository.GetAllProduct();
            dtoProduct = dbProduct.Select(c => new DtoProduct
            {
                ProductId = c.ProductId,
                MenuId = c.MenuId,
                ProductName = c.ProductName,
                ProductPrice = c.ProductPrice,
                ProductImage = c.ProductImage,
                AmountStock = c.AmountStock,
                AmountPurchased = c.AmountPurchased,
                Description = c.Description,
                Status = c.Status
            }).ToList();
            return dtoProduct;
        }

        public async Task<DtoProduct> GetProductById(int id)
        {
            var dtoProduct = new DtoProduct();
            var dbProduct = await _productRepository.GetProductById(id);
            if (dbProduct == null)
            {
                return await Task.FromResult<DtoProduct>(null);
            }
            else
            {
                dtoProduct.ProductId = dbProduct.ProductId;
                dtoProduct.MenuId = dbProduct.MenuId;
                dtoProduct.ProductName = dbProduct.ProductName;
                dtoProduct.ProductPrice = dbProduct.ProductPrice;
                dtoProduct.ProductImage = dbProduct.ProductImage;
                dtoProduct.AmountStock = dbProduct.AmountStock;
                dtoProduct.AmountPurchased = dbProduct.AmountPurchased;
                dtoProduct.Description = dbProduct.Description;
                dtoProduct.Status = dbProduct.Status;
                return dtoProduct;
            }
        }

        public async Task<ActionResponse> AddProduct(ProductRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var product = new Product()
            {
                MenuId = request.MenuId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductImage = request.ProductImage,
                AmountStock = request.AmountStock,
                AmountPurchased = request.AmountPurchased,
                Description = request.Description,
                Status = request.Status
            };
            var addResult = await _productRepository.AddProduct(product);
            if (addResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Add failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdateProduct(ProductRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbProduct = await _productRepository.GetProductById(request.ProductId);
            if (dbProduct == null)
            {
                result.Success = false;
                result.Message = "Product not found!";
                return result;
            }
            dbProduct.MenuId = request.MenuId;
            dbProduct.ProductName = request.ProductName;
            dbProduct.ProductPrice = request.ProductPrice;
            dbProduct.ProductImage = request.ProductImage;
            dbProduct.AmountStock = request.AmountStock;
            dbProduct.AmountPurchased = request.AmountPurchased;
            dbProduct.Description = request.Description;
            dbProduct.Status = request.Status;
            var updateResult = await _productRepository.UpdateProduct(dbProduct);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> DeleteProduct(int id)
        {
            var result = new ActionResponse();
            var dbMenu = await _productRepository.GetProductById(id);
            if (dbMenu == null)
            {
                result.Success = false;
                result.Message = "Product not found!";
                return result;
            }
            var deleteResult = await _productRepository.DeleteProduct(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
            }
            return result;
        }

        public async Task<List<DtoProduct>> GetProductByMenuId(int id)
        {
            var dtoProduct = new List<DtoProduct>();
            var dbProduct = await _productRepository.GetProductByMenuId(id);
            if (!dbProduct.Any())
            {
                return await Task.FromResult<List<DtoProduct>>(null);
            }
            else
            {
                dtoProduct = dbProduct.Select(c => new DtoProduct
                {
                    ProductId = c.ProductId,
                    MenuId = c.MenuId,
                    ProductName = c.ProductName,
                    ProductPrice = c.ProductPrice,
                    ProductImage = c.ProductImage,
                    AmountStock = c.AmountStock,
                    AmountPurchased = c.AmountPurchased,
                    Description = c.Description,
                    Status = c.Status
                }).ToList();
                return dtoProduct;
            }
        }
    }
}
