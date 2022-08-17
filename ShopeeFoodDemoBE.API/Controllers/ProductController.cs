using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;
using System.Text.Json;

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
                if (product.Any())
                {
                    _logger.LogInformation("Get all product succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all product ");
                    return Ok(product);
                }
                else
                {
                    _logger.LogInformation("Get all product failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all product ");
                    return BadRequest("Products not found!");
                }
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
                if (product != null)
                {
                    _logger.LogInformation("Get product by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get product by id ");
                    return Ok(product);
                }
                else
                {
                    _logger.LogInformation("Get product by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get product by id ");
                    return BadRequest("Product not found!");
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var product = await _productService.AddProduct(request);
                timer.Stop();
                if (product.Success)
                {
                    _logger.LogInformation("Add product {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add product ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add product {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,product.Message);
                    _logger.LogInformation("End add product ");
                    return BadRequest(product.Message);
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var product = await _productService.UpdateProduct(request);
                timer.Stop();
                if (product.Success)
                {
                    _logger.LogInformation("Update product {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update product ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update product {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,product.Message);
                    _logger.LogInformation("End update product ");
                    return BadRequest(product.Message);
                }
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
                if (product.Success)
                {
                    _logger.LogInformation("Delete product {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete product ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete product {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds,product.Message);
                    _logger.LogInformation("End delete product ");
                    return BadRequest(product.Message);
                }
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
                if (menu != null)
                {
                    _logger.LogInformation("Get product by menu id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get product by menu id ");
                    return Ok(menu);
                }
                else
                {
                    _logger.LogInformation("Get product by menu id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get product by menu id ");
                    return BadRequest("Menu not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }
    }
}
