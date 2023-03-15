using System.Diagnostics;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestFilters.Filters
{
    public class TestActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Inside OnActionExecuted");
            Console.WriteLine("Inside OnActionExecuted");
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Inside OnActionExecuting");
            Console.WriteLine("Inside OnActionExecuting");
        }
    }
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;             //context.Result = new OkObjectResult(new { err = true, errDesc = ex.Message});
            context.Result = new ObjectResult(new { err = true, errDesc = ex.Message })
            { StatusCode = 500 };
        }
    }
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //throw new NotImplementedException();
            int statusCode = context.HttpContext.Response.StatusCode;
            //new { StatusCode = context.HttpContext.Response.StatusCode, Message = "ResultFilterPassed" };
            statusCode = 201;
            context.HttpContext.Response.StatusCode = statusCode;
        }
    }
}
