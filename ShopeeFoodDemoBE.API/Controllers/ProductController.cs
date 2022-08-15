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
                _logger.LogInformation("Get all product succeed in {0} s", timer.Elapsed.TotalSeconds);
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
                _logger.LogInformation("Get product by id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
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
                _logger.LogInformation("Add product {0} succeed in {1} s", request.ProductName, timer.Elapsed.TotalSeconds);
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
                _logger.LogInformation("Update product {0} succeed in {1} s", request.ProductId, timer.Elapsed.TotalSeconds);
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
                _logger.LogInformation("Delete product {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
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
                _logger.LogInformation("Get product by menu id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
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
