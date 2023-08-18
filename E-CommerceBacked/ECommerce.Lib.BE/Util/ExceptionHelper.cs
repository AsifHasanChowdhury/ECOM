using System.Web.Http.Filters;

namespace ECommerce.Lib.BE.Util;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionHelper:ActionFilterAttribute

{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Code to execute before the action method is called
        // For example, logging information about the incoming request
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Code to execute after the action method has been called
        // For example, logging information about the result or modifying the result
    }
}