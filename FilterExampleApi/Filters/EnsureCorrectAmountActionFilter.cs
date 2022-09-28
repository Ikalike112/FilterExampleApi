using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExampleApi.Filters
{
    public class EnsureCorrectAmountActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            int count = (int)context.ActionArguments["count"];
            if (count <= 0)
            {
                context.ModelState.AddModelError("count","Amount of dates must be more than 0");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
