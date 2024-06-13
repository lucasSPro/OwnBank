using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ownbank.exceptions.ExceptionBase;
using ownbank.communication.Responses;
using System.Net;
using System;
using ownbank.exceptions;

namespace ownbank.api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is OwnbankExceptions)
                HandleProjectException(context);
            else
            {
                ThrowUnknowException(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException)
            {   
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesExceptions.UNKNOW_ERROR));
        }
    }
}
