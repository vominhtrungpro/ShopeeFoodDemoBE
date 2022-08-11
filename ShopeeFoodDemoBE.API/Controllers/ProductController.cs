using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iproductService;
        public ProductController(IProductService iproductService)
        {
            _iproductService = iproductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _iproductService.GetAllProduct();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _iproductService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequest request)
        {
            var product = await _iproductService.AddProduct(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductRequest request)
        {
            var product = await _iproductService.UpdateProduct(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _iproductService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("menuid-{id}")]
        public async Task<IActionResult> GetProductByMenuId(int id)
        {
            var menu = await _iproductService.GetProductByMenuId(id);
            return Ok(menu);
        }
    }
}
