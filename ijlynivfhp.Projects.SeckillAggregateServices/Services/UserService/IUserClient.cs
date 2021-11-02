using ijlynivfhp.Projects.Cores.Proxy;
using ijlynivfhp.Projects.Cores.Proxy.Attributes;
using ijlynivfhp.Projects.UserServices.Models;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Services
{
    /// <summary>
    /// 用户微服务客户端
    /// </summary>
    [MicroClient("http", "UserServices")]
    public interface IUserClient
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [PostPath("/Users")]
        public User RegistryUsers(User user);
    }
}
