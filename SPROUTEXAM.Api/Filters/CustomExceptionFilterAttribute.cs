using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SPROUTEXAM.Application.Exceptions;

namespace SPROUTEXAM.Api.Filters
{
    [AttributeUsage (AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException (ExceptionContext context) 
        {
            var code = HttpStatusCode.InternalServerError;
            if (context.Exception is RecordNotFoundException) 
            {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int) code;
            context.Result = new JsonResult (new {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}