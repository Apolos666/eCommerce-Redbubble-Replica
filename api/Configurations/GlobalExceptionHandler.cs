using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace api.Configurations;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var trackId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        
        _logger.LogError(
            exception,
            "Could not process request on Machine {MachineName}. TraceId: {TraceId}",
            Environment.MachineName,
            trackId);
        
        var (statusCode, title) = MapException(exception);
        
        await Results.Problem(
            title: title,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>()
            {
                { "traceId", trackId }
            }).ExecuteAsync(httpContext);
        
        return true;
    }
    
    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            DbUpdateException => (StatusCodes.Status500InternalServerError, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "We made a mistake but we are working on it!")
        };
    }
}