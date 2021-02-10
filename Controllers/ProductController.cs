using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Services;

namespace NetCoreAPI_v3.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("productGroups")]
        public async Task<IActionResult> GetAllProductGroup()
        {
            return Ok(await _productService.GetAllProductGroup());
        }

        [HttpGet("productGroups/{id}")]
        public async Task<IActionResult> GetProductGroupById(int id)
        {
            return Ok(await _productService.GetProductGroupById(id));
        }

        [HttpPost("productGroups")]
        public async Task<IActionResult> AddProductGroup(AddProductGroupDto addProductGroup)
        {
            return Ok(await _productService.AddProductGroup(addProductGroup));
        }

        [HttpDelete("productGroups/{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id)
        {
            return Ok(await _productService.DeleteProductGroup(id));
        }

        [HttpPut("productGroups/{id}")]
        public async Task<IActionResult> EditProductGroup(int id, EditProductGroupDto editProductGroup)
        {
            return Ok(await _productService.EditProductGroup(id, editProductGroup));
        }

        [HttpGet("productGroups/filter")]
        public async Task<IActionResult> GetProductGroupFilter([FromQuery] ProductGroupFilterDto filter)
        {
            return Ok(await _productService.GetProductGroupFilter(filter));
        }



        //Product
        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct(AddProductDto addProduct)
        {
            return Ok(await _productService.AddProduct(addProduct));
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> EditProduct(int id, EditProductDto editProduct)
        {
            return Ok(await _productService.EditProduct(id, editProduct));
        }

        [HttpGet("products/filter")]
        public async Task<IActionResult> GetProductFilter([FromQuery] ProductFilterDto filter)
        {
            return Ok(await _productService.GetProductFilter(filter));
        }


    }


}