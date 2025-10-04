using System.Net;
using UserAuthentication.Utilities.Exceptions;
using UserAuthentication.Utilities.Responses;

namespace UserAuthentication.Middleware;

public class GlobalExceptionHandlerMiddleware(
    ILogger<GlobalExceptionHandlerMiddleware> _logger
    ): IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = (int)ex.StatusCode;
            context.Response.ContentType = "application/json";
            ErrorResponse errorRespone = new ErrorResponse( ex.Message);
            
            _logger.LogDebug(errorRespone.Status.ToString() + " " + errorRespone.Message);

            await context.Response.WriteAsJsonAsync(errorRespone);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            ErrorResponse errorRespone = new ErrorResponse( ex.Message);

            await context.Response.WriteAsJsonAsync(errorRespone);
        }
    }
}