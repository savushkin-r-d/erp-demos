using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            /* Console.WriteLine($"Exception: {context.Exception.Message}");
            Console.WriteLine("Exception filter");

            context.ExceptionHandled = true;
            context.Result = new ObjectResult(context.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            }; */

            //TODO: Process exceptions in one output format
        }
    }
}