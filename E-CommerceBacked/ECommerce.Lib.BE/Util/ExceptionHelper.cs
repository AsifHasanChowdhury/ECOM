using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace ECommerce.Lib.BE.Util;

public class ExceptionHelper: ActionFilterAttribute

{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Code to execute before the action method is called
        // For example, logging information about the incoming request
        int x = 2;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Code to execute after the action method has been called
        // For example, logging information about the result or modifying the result
    }
}