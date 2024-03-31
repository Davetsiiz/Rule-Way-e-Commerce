using AutoMapper;
using CaseRW.Core.DTOs;
using CaseRW.Core.Entities;
using CaseRW.Core.Repositories;
using CaseRW.Core.Services;
using CaseRW.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseRW.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProductsAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, categoryDto);
        }

        public async Task<CustomResponseDto<List<CategoryDto>>> GetCategoryBySearchAsync(string key)
        {
            var categories = await _categoryRepository.GetCategoryBySearchAsync(key);
            var categoryDto = _mapper.Map<List<CategoryDto>>(categories);
            return CustomResponseDto<List<CategoryDto>>.Success(200, categoryDto);
        }


    }
}
