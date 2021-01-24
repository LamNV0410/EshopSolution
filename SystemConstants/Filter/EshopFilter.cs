using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Common.Filter
{
    public class EshopFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
