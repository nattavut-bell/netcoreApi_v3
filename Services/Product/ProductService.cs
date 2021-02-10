using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreAPI_v3.Data;
using NetCoreAPI_v3.DTOs;
using NetCoreAPI_v3.Helpers;
using NetCoreAPI_v3.Models;
using System.Linq.Dynamic.Core;

namespace NetCoreAPI_v3.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;
        private readonly IHttpContextAccessor _httpContext;

        public ProductService(AppDBContext dBContext, IMapper mapper, ILogger<ProductService> log, IHttpContextAccessor httpContext) : base(dBContext, mapper, httpContext)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
            _httpContext = httpContext;
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

            var result = await _dBContext.ProductGroups
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == productGroup.Id);

            var dto = _mapper.Map<GetProductGroupDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> DeleteProductGroup(int productGroupId)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductGroupId == productGroupId && x.IsActive == true);
            if (product != null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup used ?");
            }

            var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == productGroupId);
            if (productGroup is null)
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

            var result = await _dBContext.ProductGroups
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == productGroupId);

            var dto = _mapper.Map<GetProductGroupDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(int productGroupId, EditProductGroupDto editProductGroup)
        {

            var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == productGroupId);
            if (productGroup is null)
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

            var result = await _dBContext.ProductGroups
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == productGroupId);

            var dto = _mapper.Map<GetProductGroupDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetAllProductGroup()
        {
            var result = await _dBContext.ProductGroups
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.Product)
            .AsNoTracking().ToListAsync();

            var dto = _mapper.Map<List<GetProductGroupDto>>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId)
        {
            var result = await _dBContext.ProductGroups
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == productGroupId);

            if (result is null)
            {
                return ResponseResult.Failure<GetProductGroupDto>("ProductGroup not found ?");
            }

            var dto = _mapper.Map<GetProductGroupDto>(result);
            return ResponseResult.Success(dto);
        }


        public async Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto addProduct)
        {
            var product = new Product();

            var userId = Guid.Parse(GetUserId());
            var date = Now();

            product.Name = addProduct.Name;
            product.Price = addProduct.Price;
            product.Stock = addProduct.Stock;
            product.ProductGroupId = addProduct.ProductGroupId;
            product.IsActive = true;
            product.CreatedByUserId = userId;
            product.CreatedDate = date;
            product.UpdatedByUserId = userId;
            product.UpdatedDate = date;

            _dBContext.Products.Add(product);
            await _dBContext.SaveChangesAsync();

            var result = await _dBContext.Products
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.ProductGroup)
            .FirstOrDefaultAsync(x => x.Id == product.Id);

            var dto = _mapper.Map<GetProductDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductDto>> DeleteProduct(int productId)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
            {
                return ResponseResult.Failure<GetProductDto>("Product not found ?");
            }


            if (product.IsActive == false)
            {
                return ResponseResult.Failure<GetProductDto>("None Active ?");
            }

            var userId = Guid.Parse(GetUserId());
            var date = Now();

            product.IsActive = false;
            product.UpdatedByUserId = userId;
            product.UpdatedDate = date;

            _dBContext.Products.Update(product);
            await _dBContext.SaveChangesAsync();

            var result = await _dBContext.Products
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.ProductGroup)
            .FirstOrDefaultAsync(x => x.Id == productId);

            var dto = _mapper.Map<GetProductDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductDto>> EditProduct(int productId, EditProductDto editProduct)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
            {
                return ResponseResult.Failure<GetProductDto>("Product not found ?");
            }


            var userId = Guid.Parse(GetUserId());
            var date = Now();

            product.Name = editProduct.Name;
            product.Price = editProduct.Price;
            product.Stock = editProduct.Stock;
            product.ProductGroupId = editProduct.ProductGroupId;
            product.UpdatedByUserId = userId;
            product.UpdatedDate = date;

            _dBContext.Products.Update(product);
            await _dBContext.SaveChangesAsync();

            var result = await _dBContext.Products
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.ProductGroup)
            .FirstOrDefaultAsync(x => x.Id == productId);

            var dto = _mapper.Map<GetProductDto>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProduct()
        {
            var result = await _dBContext.Products
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.ProductGroup)
            .AsNoTracking().ToListAsync();

            var dto = _mapper.Map<List<GetProductDto>>(result);
            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int productId)
        {
            var result = await _dBContext.Products
            .Include(x => x.UpdatedByUser)
            .Include(x => x.CreatedByUser)
            .Include(x => x.ProductGroup)
            .FirstOrDefaultAsync(x => x.Id == productId);

            if (result == null)
            {
                return ResponseResult.Failure<GetProductDto>("Product not found ?");
            }

            var dto = _mapper.Map<GetProductDto>(result);
            return ResponseResult.Success(dto);
        }


        public async Task<ServiceResponseWithPagination<List<GetProductGroupDto>>> GetProductGroupFilter(ProductGroupFilterDto filter)
        {
            var queryable = _dBContext.ProductGroups
            .Include(x => x.CreatedByUser)
            .Include(x => x.UpdatedByUser)
            .Include(x => x.Product)
            .AsQueryable();

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.SearchDetail))
            {
                queryable = queryable.Where(x => x.Name.Contains(filter.SearchDetail));
            }

            //Ordering
            if (!string.IsNullOrWhiteSpace(filter.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{filter.OrderingField} {(filter.AscendingOrder ? "ASC" : "DESC")}");
                }
                catch
                {
                    return ResponseResultWithPagination.Failure<List<GetProductGroupDto>>($"Could not order by Filed: {filter.OrderingField}");
                }
            }

            var paginationResult = await _httpContext.HttpContext
                .InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);
            var result = await queryable.Paginate(filter).ToListAsync();
            var dto = _mapper.Map<List<GetProductGroupDto>>(result);

            return ResponseResultWithPagination.Success<List<GetProductGroupDto>>(dto, paginationResult);
        }

        public async Task<ServiceResponseWithPagination<List<GetProductDto>>> GetProductFilter(ProductFilterDto filter)
        {
            var queryable = _dBContext.Products
            .Include(x => x.CreatedByUser)
            .Include(x => x.UpdatedByUser)
            .Include(x => x.ProductGroup)
            .AsQueryable();

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.SearchDetail))
            {
                queryable = queryable.Where(x => x.Name.Contains(filter.SearchDetail));
            }

            //Ordering
            if (!string.IsNullOrWhiteSpace(filter.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{filter.OrderingField} {(filter.AscendingOrder ? "ASC" : "DESC")}");
                }
                catch
                {
                    return ResponseResultWithPagination.Failure<List<GetProductDto>>($"Could not order by Filed: {filter.OrderingField}");
                }
            }

            var paginationResult = await _httpContext.HttpContext
                .InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);
            var result = await queryable.Paginate(filter).ToListAsync();
            var dto = _mapper.Map<List<GetProductDto>>(result);

            return ResponseResultWithPagination.Success<List<GetProductDto>>(dto, paginationResult);
        }
    }
}