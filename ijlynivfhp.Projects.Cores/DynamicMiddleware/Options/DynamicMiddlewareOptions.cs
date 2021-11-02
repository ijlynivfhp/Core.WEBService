using ijlynivfhp.Projects.Cores.Cluster.Options;
using ijlynivfhp.Projects.Cores.HttpClientPolic;
using ijlynivfhp.Projects.Cores.Registry.Options;
using System;

namespace ijlynivfhp.Projects.Cores.Middleware.options
{
    /// <summary>
    /// 中台配置选项
    /// </summary>
    public class DynamicMiddlewareOptions
    {
        public DynamicMiddlewareOptions()
        {
            serviceDiscoveryOptions = options => { };
            loadBalanceOptions = options => { };
            middlewareOptions = options => { };
        }

        /// <summary>
        /// 服务发现选项
        /// </summary>
        public Action<ServiceDiscoveryOptions> serviceDiscoveryOptions { set; get; }

        /// <summary>
        /// 负载均衡选项
        /// </summary>
        public Action<LoadBalanceOptions> loadBalanceOptions { set; get; }

        // 中台选项
        public Action<MiddlewareOptions> middlewareOptions { set; get; }
    }
}
