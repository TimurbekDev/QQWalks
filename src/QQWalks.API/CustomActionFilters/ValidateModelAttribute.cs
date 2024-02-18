using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QQWalks.API.CustomActionFilters;

public class ValidateModelAttribute: ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if(!context.ModelState.IsValid)
        {
            context.Result = new BadRequestResult();
        }
    }
}
