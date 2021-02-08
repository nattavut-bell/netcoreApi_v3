using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreAPI_v3.Data;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Models;
using NetCoreAPI_v3.Services;
using NetCoreAPI_v3.Services.Product;

namespace NetCoreAPI_v3.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;

        public ProductService(AppDBContext dBContext, IMapper mapper, ILogger<ProductService> log, IHttpContextAccessor httpContext) : base(dBContext, mapper, httpContext)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;

        }

        public async Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroupDto addProductGroup)
        {
            var productGroup = new ProductGroup();

            var userId = Guid.Parse(GetUserId());
            var date = Now();

            productGroup.Name = addProductGroup.Name;
            productGroup.IsActive = true;
            productGroup.CreatedByUserId = userId;
            productGroup.CreatedDate = date;
            productGroup.UpdatedByUserId = userId;
            productGroup.UpdatedDate = date;

            _dBContext.ProductGroups.Add(productGroup);
            await _dBContext.SaveChangesAsync();

            // var x2 = await productGroup.

            var x1 = await _dBContext.ProductGroups.Include(x => x.UpdatedByUser).Include(x => x.CreatedByUser).FirstOrDefaultAsync(x => x.Id == productGroup.Id);

            var dto = _mapper.Map<GetProductGroupDto>(x1);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int productGroupId)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductGroupId == productGroupId);
            if (product != null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup used ?");
            }

            var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == productGroupId);
            if (productGroup == null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup not found ?");
            }

            if (productGroup.IsActive == false)
            {
                return ResponseResult.Failure<GetProductGroupDto>("None Active ?");
            }

            var userId = Guid.Parse(GetUserId());
            var date = Now();

            productGroup.IsActive = false;
            productGroup.UpdatedByUserId = userId;
            productGroup.UpdatedDate = date;

            _dBContext.ProductGroups.Update(productGroup);
            await _dBContext.SaveChangesAsync();

            var x1 = await _dBContext.ProductGroups.Include(x => x.UpdatedByUser).Include(x => x.CreatedByUser).FirstOrDefaultAsync(x => x.Id == productGroupId);

            var dto = _mapper.Map<GetProductGroupDto>(x1);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(EditProductGroupDto editProductGroup)
        {

            var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == editProductGroup.Id);
            if (productGroup == null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup not found ?");
            }


            var userId = Guid.Parse(GetUserId());
            var date = Now();

            productGroup.Name = editProductGroup.Name;
            productGroup.UpdatedByUserId = userId;
            productGroup.UpdatedDate = date;

            _dBContext.ProductGroups.Update(productGroup);
            await _dBContext.SaveChangesAsync();

            var x1 = await _dBContext.ProductGroups.Include(x => x.UpdatedByUser).Include(x => x.CreatedByUser).FirstOrDefaultAsync(x => x.Id == editProductGroup.Id);

            var dto = _mapper.Map<GetProductGroupDto>(x1);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup()
        {
            var productGroup = await _dBContext.ProductGroups.Include(x => x.UpdatedByUser).Include(x => x.CreatedByUser).AsNoTracking().ToListAsync();



            var dto = _mapper.Map<List<GetProductGroupDto>>(productGroup);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId)
        {
            var productGroup = await _dBContext.ProductGroups.Include(x => x.UpdatedByUser).Include(x => x.CreatedByUser).FirstOrDefaultAsync(x => x.Id == productGroupId);

            if (productGroup == null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup not found ?");
            }

            var dto = _mapper.Map<GetProductGroupDto>(productGroup);
            return ResponseResult.Success(dto);
        }
    }
}