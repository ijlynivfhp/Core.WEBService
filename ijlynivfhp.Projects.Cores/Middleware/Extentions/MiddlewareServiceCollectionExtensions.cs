﻿using Microsoft.Extensions.DependencyInjection;
using ijlynivfhp.Projects.Cores.Cluster.Extentions;
using ijlynivfhp.Projects.Cores.HttpClientPolly;
using ijlynivfhp.Projects.Cores.Middleware.options;
using ijlynivfhp.Projects.Cores.Middleware.support;
using ijlynivfhp.Projects.Cores.Middleware.transports;
using ijlynivfhp.Projects.Cores.Middleware.Urls;
using ijlynivfhp.Projects.Cores.Middleware.Urls.consul;
using ijlynivfhp.Projects.Cores.Registry.Extentions;
using System;

namespace ijlynivfhp.Projects.Cores.Middleware.Extentions
{
    /// <summary>
    ///  中台ServiceCollection扩展方法
    /// </summary>
    public static class MiddlewareServiceCollectionExtensions
    {
        /// <summary>
        /// 添加中台
        /// </summary>
        /// <typeparam name="IMiddleService"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            AddMiddleware(services, options => {});
            return services;
        }

        /// <summary>
        /// 添加中台
        /// </summary>
        /// <typeparam name="IMiddleService"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMiddleware(this IServiceCollection services, Action<MiddlewareOptions> options)
        {
            MiddlewareOptions middlewareOptions = new MiddlewareOptions();
            options(middlewareOptions);

            // 1、注册到IOC
            services.Configure<MiddlewareOptions>(options);

            // 2、添加HttpClient
            // services.AddHttpClient(middlewareOptions.HttpClientName);
            services.AddPollyHttpClient(middlewareOptions.HttpClientName, middlewareOptions.pollyHttpClientOptions);

            // 3、注册中台
            services.AddSingleton<IMiddleService, HttpMiddleService>();

            return services;
        }
    }
}
