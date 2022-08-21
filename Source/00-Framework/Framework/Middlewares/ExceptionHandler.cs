using Framework.ApiResponse;
using Framework.Exceptions;
using Framework.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Framework.Middlewares;

public sealed class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionHandler> logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var message = string.IsNullOrWhiteSpace(e.Message) ? EShopException.BASE_MESSAGE : e.Message;

            var apiError = new ApiError(message);
            var apiResult = ApiResult.From(apiError);

            var result = JsonConvert.SerializeObject(apiResult);
            context.Response.StatusCode = (int)StatusCodeFinder.FindHttpStatusCode(e);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);

            logger.LogError(e.Message);
        }
    }
}
