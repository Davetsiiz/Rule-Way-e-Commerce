using CaseRW.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CaseRW.Api.Filters
{
    public class ValidateFiltersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var responses = context.ModelState.Values.SelectMany(x => x.Errors);
                var errors = responses.Select(x => x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
            }
        }
    }
}
