using CaseRW.Core.DTOs;
using FluentValidation;

namespace CaseRW.Service.ValidationRules
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MinimumLength(3).WithMessage("{PropertyName} must be at least 3 characters long.")
                .MaximumLength(200).WithMessage("{PropertyName} must be at most 200 characters long.");

            RuleFor(x => x.StockQuantity)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.CategoryId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
