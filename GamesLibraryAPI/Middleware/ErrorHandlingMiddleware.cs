using System.Net;
using GamesLibraryAPI.Exceptions;
using GamesLibraryShared;

namespace GamesLibraryAPI.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (BadRequestException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (UserNotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.NoContent);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, "Something went wrong : ");
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode,
        string message = "")
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(new BaseResponse()
        {
            Error = true,
            Message = message + exception.Message + exception.StackTrace // StackTrace only for testing purposes
        });
    }
}