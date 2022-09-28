using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExampleApi.Filters
{
    public class DebugResourseFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[Resourse Filter] {context.ActionDescriptor.DisplayName} is executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"[Resourse Filter] {context.ActionDescriptor.DisplayName} is executing");

        }
    }
}
