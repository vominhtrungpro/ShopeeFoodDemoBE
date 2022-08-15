using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all product ");
            try
            {
                var product = await _productService.GetAllProduct();
                timer.Stop();
                _logger.LogInformation("Get all product succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all product ");
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get product by id ");
            try
            {
                var product = await _productService.GetProductById(id);
                timer.Stop();
                _logger.LogInformation("Get product by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get product by id ");
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add product ");
            try
            {
                var product = await _productService.AddProduct(request);
                timer.Stop();
                _logger.LogInformation("Add product name: {0},menu id: {1},product price: {2},product image: {3},amount stock: {4},amount purchased: {5},description: {6},status: {7} succeed in {8} ms", request.ProductName,request.MenuId,request.ProductPrice,request.ProductImage,request.AmountStock,request.AmountPurchased,request.Description,request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add product ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update product ");
            try
            {
                var product = await _productService.UpdateProduct(request);
                timer.Stop();
                _logger.LogInformation("Update product id: {0}, product name: {1},menu id: {2},product price: {3},product image: {4},amount stock: {5},amount purchased: {6},description: {7},status: {8} succeed in {9} ms",request.ProductId, request.ProductName, request.MenuId, request.ProductPrice, request.ProductImage, request.AmountStock, request.AmountPurchased, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update product ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }    
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete product ");
            try
            {
                var product = await _productService.DeleteProduct(id);
                timer.Stop();
                _logger.LogInformation("Delete product {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete product ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpGet("menuid-{id}")]
        public async Task<IActionResult> GetProductByMenuId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get product by menu id ");
            try
            {
                var menu = await _productService.GetProductByMenuId(id);
                timer.Stop();
                _logger.LogInformation("Get product by menu id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get product by menu id ");
                return Ok(menu);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }
    }
}
