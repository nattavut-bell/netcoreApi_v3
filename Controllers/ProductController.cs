using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Services;

namespace NetCoreAPI_v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("getProductGroup")]
        public async Task<IActionResult> GetAllProductGroup()
        {
            return Ok(await _productService.GetAllProductGroup());
        }

        [HttpGet("getProductGroupById")]
        public async Task<IActionResult> GetProductGroupById(int productGroupId)
        {
            return Ok(await _productService.GetProductGroupById(productGroupId));
        }

        [HttpPost("addProductGroup")]
        public async Task<IActionResult> AddProductGroup(AddProductGroupDto addProductGroup)
        {
            return Ok(await _productService.AddProductGroup(addProductGroup));
        }

        [HttpDelete("deleteProductGroup")]
        public async Task<IActionResult> DeleteProductGroup(int productGroupId)
        {
            return Ok(await _productService.DeleteProductGroup(productGroupId));
        }


        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("getProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            return Ok(await _productService.GetProductById(productId));
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto addProduct)
        {
            return Ok(await _productService.AddProduct(addProduct));
        }

        [HttpDelete("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            return Ok(await _productService.DeleteProduct(productId));
        }
    }


}