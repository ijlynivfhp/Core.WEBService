﻿using System;

namespace ijlynivfhp.WEBService.Cores.Proxy
{
    /// <summary>
    /// 微服务客户端特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class MicroClient : Attribute
    {

        public string UrlShcme { get; }
        public string ServiceName { get; }

        public MicroClient(string urlShcme, string serviceName)
        {
            UrlShcme = urlShcme;
            ServiceName = serviceName;
        }
    }
}
