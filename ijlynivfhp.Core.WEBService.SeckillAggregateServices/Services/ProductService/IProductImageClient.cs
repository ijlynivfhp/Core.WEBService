using ijlynivfhp.Core.WEBService.Cores.Proxy;
using ijlynivfhp.Core.WEBService.Cores.Proxy.Attributes;
using ijlynivfhp.Core.WEBService.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services
{
    /// <summary>
    /// 商品微服务客户端
    /// </summary>
    [MicroClient("http", "ProductServices")]
    public interface IProductImageClient
    {
        /// <summary>
        /// 查询所有商品信息
        /// </summary>
        /// <returns></returns>
        [GetPath("/Products/{productId}/ProductImages")]
        public List<ProductImage> GetProductImges(int productId);
    }
}
