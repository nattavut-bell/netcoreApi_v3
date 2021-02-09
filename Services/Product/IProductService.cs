using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Models;

namespace NetCoreAPI_v3.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup();
        Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId);
        Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto addProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(EditProductGroupDto editProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int productGroupId);




        Task<ServiceResponse<List<GetProductDto>>> GetAllProduct();
        Task<ServiceResponse<GetProductDto>> GetProductById(int productId);
        Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto addProduct);
        Task<ServiceResponse<GetProductDto>> EditProduct(EditProductDto editProduct);
        Task<ServiceResponse<GetProductDto>> DeleteProduct(int productId);


    }
}