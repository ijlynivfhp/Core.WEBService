using Microsoft.AspNetCore.Builder;

namespace ijlynivfhp.WEBService.Commons.Middlewares
{
    /// <summary>
    /// 自定义异常中间件扩展
    /// </summary>
    public static class SystemExceptionApplicationBuilderExtensions
    {
        /// <summary>
        /// 自定义系统异常中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSystmeException(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SystemExceptionHandlerderMiddleware>();
            return builder;
        }
    }
}
