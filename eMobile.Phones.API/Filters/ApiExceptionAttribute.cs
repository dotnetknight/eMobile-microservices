using eMobile.Phones.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eMobile.Phones.API.Filters
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var baseException = context.Exception.GetBaseException();

            int statusCode = StatusCodes.Status500InternalServerError;
            string message = "Internal server error occurred";

            if (baseException is BaseApiException baseApiException)
            {
                statusCode = (int)baseApiException.HttpStatusCode;
                message = baseApiException.Message;
            }

            context.HttpContext.Response.StatusCode = statusCode;

            context.Result = new JsonResult(new
            {
                statusCode,
                message
            });

            base.OnException(context);
        }
    }
}
