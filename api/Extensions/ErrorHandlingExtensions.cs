using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace api.Extensions;

public static class ErrorHandlingExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails?.Error;
            
            logger.LogError(
                exception,
                "Could not process request on Machine {MachineName}. TraceId: {TraceId}",
                Environment.MachineName,
                Activity.Current?.Id);

            await Results.Problem(
                title: "We made a mistake but we are working on it!",
                statusCode: StatusCodes.Status500InternalServerError,
                extensions: new Dictionary<string, object?>()
                {
                    { "traceId", Activity.Current?.Id ?? context.TraceIdentifier }
                }).ExecuteAsync(context);
        });
    }
}