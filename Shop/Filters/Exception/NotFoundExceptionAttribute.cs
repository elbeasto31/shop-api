using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Constants;
using Shop.Exceptions;

namespace Shop.Filters.Exception
{
    public class NotFoundExceptionAttribute : Attribute, IExceptionFilter 
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not NotFoundException exception || context.ExceptionHandled)
                return;

            context.Result = new NotFoundObjectResult(string.Format(Messages.UserNotFound, exception.UserId));
            context.ExceptionHandled = true;
        }
    }
}