using AutoMapper;
using CaseRW.Api.Filters;
using CaseRW.Core.DTOs;
using CaseRW.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseRW.Api.Controllers
{
    [ValidateFiltersAttribute]
    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> CategoryWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProductsAsync(categoryId));
        }
        [HttpGet("[action]/{categoryName}")]
        public async Task<IActionResult> GetCategoryBySearch(string categoryName)
        {
            return CreateActionResult(await _categoryService.GetCategoryBySearchAsync(categoryName));
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
        }




    }
}
