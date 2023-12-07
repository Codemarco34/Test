using System.Net;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Services.Contracts;

namespace AREMSUPPORTDESK.Extensions;

public  static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError,
                    };
                    
                    logger.LogError($"Something went wrong: {contextFeature.Error}");
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                
                    
                }
            });
        });
    }
}