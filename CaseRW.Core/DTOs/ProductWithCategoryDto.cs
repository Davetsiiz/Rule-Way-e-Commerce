﻿namespace CaseRW.Core.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
