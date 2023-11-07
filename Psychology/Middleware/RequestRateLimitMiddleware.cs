using Microsoft.Extensions.Caching.Memory;

namespace Psychology.Middleware;

public class RequestRateLimitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly int _limit;
    private readonly TimeSpan _period;

    public RequestRateLimitMiddleware(RequestDelegate next, IMemoryCache cache, int limit, TimeSpan period)
    {
        _next = next;
        _cache = cache;
        _limit = limit;
        _period = period;
    }

    public async Task Invoke(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress.ToString();

        var cacheKey = $"{ipAddress}-{DateTime.UtcNow.Minute}";

        if (!_cache.TryGetValue(cacheKey, out int requestCount))
        {
            requestCount = 0;
        }

        requestCount++;

        if (requestCount > _limit)
        {
            context.Response.StatusCode = 429; // Too Many Requests
            await context.Response.WriteAsync("Rate limit exceeded. Please try again later.");
            return;
        }

        _cache.Set(cacheKey, requestCount, _period);

        await _next(context);
    }
}

public static class RequestRateLimitMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestRateLimit(this IApplicationBuilder builder, int limit, TimeSpan period)
    {
        return builder.UseMiddleware<RequestRateLimitMiddleware>(limit, period);
    }
}