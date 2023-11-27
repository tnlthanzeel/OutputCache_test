﻿using OutputCache_test.SharedKernal.Helpers;
using OutputCache_test.SharedKernal.Responses;
using Serilog;
using System.Diagnostics;
using System.Net;

namespace OutputCache_test.Api.Middleware;

public sealed class ExceptionHandlerMiddleware
{
    private const string applicationJSONContentType = "application/json";
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception exception)
    {
        var activityId = Activity.Current?.Id ?? "N/A";

        ErrorResponse errorResponse = new() { TraceId = activityId };

        int httpStatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = applicationJSONContentType;

        var result = string.Empty;



        switch (exception)
        {
            case OperationCanceledException:
                //if client closes the connection
                httpStatusCode = StatusCodes.Status200OK;
                result = Serializer.Serialize(new ResponseResult<string>("Client closed the connecion"));
                break;
            case Exception:
                httpStatusCode = StatusCodes.Status500InternalServerError;
                errorResponse.Errors.Add(new KeyValuePair<string, IEnumerable<string>>(nameof(HttpStatusCode.InternalServerError), new[] { "Something went wrong, please try again" }));
                result = Serializer.Serialize(errorResponse);
                LogError(exception, activityId);
                break;
        }

        context.Response.StatusCode = httpStatusCode;

        return context.Response.WriteAsync(result);
    }

    private static void LogError(Exception exception, string activityId)
    {
        Log.Error("\n{startLine} \n\n Type:\n{exceptionType} \n\n ActivityId:\n{activity}\n\n Message:\n{exceptionMessage} \n\n Stack Trace:\n                              {stackTrace} \n{endLine}\n",
                                new string('-', 150),
                                exception.GetType().FullName,
                                activityId,
                                exception?.InnerException?.Message ?? exception?.Message,
                                exception?.InnerException?.StackTrace ?? exception?.StackTrace,
                                new string('-', 150));
    }
}
