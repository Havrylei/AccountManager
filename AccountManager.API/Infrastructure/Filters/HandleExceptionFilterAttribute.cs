using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountManager.API.Infrastructure.Filters
{
    public class HandleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult("Bad Request\n" + context.Exception.Message);
        }
    }
}
