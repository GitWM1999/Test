using Microsoft.AspNetCore.Builder;

namespace Education.Common
{
    //日志中间件扩展
    public static class LogMiddlewareExtensions
    {
        //使用日志中间件
        public static IApplicationBuilder UseLog(this IApplicationBuilder builder)
        {
            //使用日志中间件
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
