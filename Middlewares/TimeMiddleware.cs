
namespace rest_api_dotnet_core.Middleware;

  public class TimeMiddleware
  {
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
      next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {

      if (context.Request.Query.Any(p => p.Key == "time"))
      {
        await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
      }

      if (context.Response.HasStarted)
      {
        await next(context);
      }

    }
    
  }

  public static class TimeMiddlewareExtension
{
  public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<TimeMiddleware>();
  }
}
