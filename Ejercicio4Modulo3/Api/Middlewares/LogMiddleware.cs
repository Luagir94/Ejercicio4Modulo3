using Ejercicio4Modulo3.Data;
using Ejercicio4Modulo3.Domain.Contracts;
using Ejercicio4Modulo3.Domain.Entities;

namespace Ejercicio4Modulo3.Api.Middlewares;

public class LoggingMiddleware : IMiddleware
{
    private readonly ILogService _logService;

    public LoggingMiddleware(ILogService context)
    {
        _logService = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        bool success = false;
        try
        {
            await next(context);
            success = context.Response.StatusCode < 400;
        }
        catch
        {
            success = false;
        }
        finally
        {
            await AddLog(context, success);
        }
    }

    private async Task AddLog(HttpContext context, bool success)
    {
        var log = new Logs
        {
            Fecha = DateTime.Now,
            Path = context.Request.Path,
            Method = context.Request.Method,
            Success = success
        };

        await _logService.Add_Log(log);
    }
}