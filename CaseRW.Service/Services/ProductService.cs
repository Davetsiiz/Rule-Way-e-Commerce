using AutoMapper;
using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;
using CaseRW.Core.Repositories;
using CaseRW.Core.Services;
using CaseRW.Core.UnitOfWork;

namespace CaseRW.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetProductDescriptionBySearchAsync(string key)
        {
            var products = await _productRepository.GetProductDescriptionBySearch(key);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetProductsByCategoryMinStockAsync()
        {
            var products = await _productRepository.GetProductsByCategoryMinStockAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, productDto);
        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetProductsByStockQuantityRangeAsync(int max, int min)
        {
            var products = await _productRepository.GetProductsByStockQuantityRange(max, min);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, productsDto);

        }

        public async Task<CustomResponseDto<List<ProductDto>>> GetProductTitleBySearchAsync(string key)
        {
            var products = await _productRepository.GetProductTitleBySearchAsync(key);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return CustomResponseDto<List<ProductDto>>.Success(200, productsDto);
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategoryAsync()
        {
            var product = await _productRepository.GetProductsWithCategoryAsync();
            var productDto = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productDto);
        }
    }
}
