using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace AccountManager.API.Infrastructure.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            Dictionary<string, string> errors = context.ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(key => key.Key.ToLower(), value => value.Value.Errors.First().ErrorMessage);

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
