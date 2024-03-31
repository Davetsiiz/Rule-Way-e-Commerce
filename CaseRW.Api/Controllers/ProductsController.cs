using AutoMapper;
using CaseRW.Api.Filters;
using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;
using CaseRW.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseRW.Api.Controllers
{
    [ValidateFiltersAttribute]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDtos = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDtos));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto productCreateDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productCreateDto));
            var productDtos = _mapper.Map<ProductCreateDto>(product);
            return CreateActionResult(CustomResponseDto<ProductCreateDto>.Success(201, productDtos));

        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Bu Stoğa ait kayıt bulunamadı."));
            }
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productService.GetProductWithCategoryAsync());
        }

        [HttpGet("[action]/{title}")]
        public async Task<IActionResult> GetProductTitleBySearch(string title)
        {
            return CreateActionResult(await _productService.GetProductTitleBySearchAsync(title));
        }

        [HttpGet("[action]/{description}")]
        public async Task<IActionResult> GetProductDescriptionBySearch(string description)
        {
            return CreateActionResult(await _productService.GetProductDescriptionBySearchAsync(description));
        }

        [HttpGet("[action]/{min}/{max}")]
        public async Task<IActionResult> GetProductByStockQuantityRange(int min, int max)
        {
            return CreateActionResult(await _productService.GetProductsByStockQuantityRangeAsync(max, min));
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductByCategoryMinStock()
        {
            return CreateActionResult(await _productService.GetProductsByCategoryMinStockAsync());
        }

    }
}
