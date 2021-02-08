using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Models;

namespace NetCoreAPI_v3.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup();
        Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId);
        Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto addProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(EditProductGroupDto editProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int productGroupId);

    }
}