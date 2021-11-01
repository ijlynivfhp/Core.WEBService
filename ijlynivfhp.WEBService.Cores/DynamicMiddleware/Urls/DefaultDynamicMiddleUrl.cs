﻿using ijlynivfhp.WEBService.Commons.Exceptions;
using ijlynivfhp.WEBService.Cores.Cluster;
using ijlynivfhp.WEBService.Cores.Registry;
using System.Collections.Generic;
using System.Text;

namespace ijlynivfhp.WEBService.Cores.Middleware.Urls.consul
{
    /// <summary>
    /// 默认获取Url
    /// </summary>
    public class DefaultDynamicMiddleUrl : IDynamicMiddleUrl
    {
        private readonly IServiceDiscovery serviceDiscovery;
        private readonly ILoadBalance loadBalance;

        public DefaultDynamicMiddleUrl(IServiceDiscovery serviceDiscovery, ILoadBalance loadBalance)
        {
            this.serviceDiscovery = serviceDiscovery;
            this.loadBalance = loadBalance;
        }

        public string GetMiddleUrl(string urlShcme, string serviceName)
        {
            // 1、获取服务url
            IList<ServiceNode> serviceUrls = serviceDiscovery.Discovery(serviceName);

            if (serviceUrls.Count == 0)
            {
                throw new FrameException($"{serviceName} 服务不存在");
            }

            // 2、url负载均衡
            ServiceNode serviceUrl = loadBalance.Select(serviceUrls);

            // 3、创建url
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(urlShcme);
            stringBuilder.Append("://");
            stringBuilder.Append(serviceUrl.Url);
            return stringBuilder.ToString();
        }
    }
}
