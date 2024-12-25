using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log request
        Debug.WriteLine($"HTTP {context.Request.Method} {context.Request.Path}");

        await _next(context);

        // Log response
        Debug.WriteLine($"Response {context.Response.StatusCode}");
    }
}