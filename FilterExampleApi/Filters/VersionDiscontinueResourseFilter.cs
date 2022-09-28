using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExampleApi.Filters
{
    public class VersionDiscontinueResourseFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.QueryString.Value.ToLower().Contains("?api-version=0.1"))
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Success = false,
                    Errors = new [] {"This version of the API is discontinued, please use new version"} 
                });
            }
        }

    }
}
