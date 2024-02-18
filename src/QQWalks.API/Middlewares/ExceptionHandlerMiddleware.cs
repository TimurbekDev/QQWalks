using QQWalks.API.Helpers;
using QQWalks.Service.Exceptions;

namespace QQWalks.API.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (QQWalksException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = 500,
                Message = ex.Message
            });
        }
    }
}
