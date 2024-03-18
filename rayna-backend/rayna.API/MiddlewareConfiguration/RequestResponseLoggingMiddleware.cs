using rayna.Common.Entities;
using rayna.Common.ExceptionHandler;
using rayna.Persistence.Configuration;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Text;

namespace rayna.API.MiddlewareConfiguration;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    private async Task<string?> GetRequest(HttpRequest request)
    {
        request.EnableBuffering();

        var body = await new StreamReader(request.Body).ReadToEndAsync();
        request.Body.Position = 0;

        return body;
    }

    public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
    {
        DateTimeOffset reqDateTime = DateTimeOffset.UtcNow;
        APILogs apiLog = new APILogs()
        {
            Method = context.Request.Method,
            Host = context.Request.Host.Value,
            Path = context.Request.Path,
            RequestAt = reqDateTime,
            QueryString = context.Request.QueryString.Value,
            ResponseBody = "SUCCESS"
        };
        try
        {
            apiLog.RequestBody = await GetRequest(context.Request);

            await _next(context);

            apiLog.StatusCode = context.Response.StatusCode;
            apiLog.ResponseAt = DateTimeOffset.UtcNow;
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";


            context.Response.StatusCode = ex switch
            {
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
            {
                Log.Error(ex.Message);
                apiLog.Exception = ex.ToString();
            }

            string resBody = new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString();

            apiLog.ResponseAt = DateTimeOffset.UtcNow;
            apiLog.StatusCode = context.Response.StatusCode;
            apiLog.ResponseBody = resBody;

            await context.Response.WriteAsync(resBody);
        }
        finally
        {
            dbContext.APILogs.Add(apiLog);
            await dbContext.SaveChangesAsync();
        }
    }
}
