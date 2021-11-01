using ijlynivfhp.WEBService.Cores.Proxy;
using ijlynivfhp.WEBService.Cores.Proxy.Attributes;
using ijlynivfhp.WEBService.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.SeckillAggregateServices.Services
{
    /// <summary>
    /// 商品微服务客户端
    /// </summary>
    [MicroClient("http", "ProductServices")]
    public interface IProductClient
    {
        /// <summary>
        /// 查询所有商品信息
        /// </summary>
        /// <returns></returns>
        [GetPath("/Products")]
        public List<Product> GetProductList();


        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <returns></returns>
        [GetPath("/Products/{productId}")]
        public Product GetProduct(int productId);

        /// <summary>
        /// 扣减商品库存
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductCount"></param>
        /// <returns></returns>
        [PutPath("/Products/{ProductId}/set-stock")]
        public void ProductSetStock(int ProductId, int ProductCount);
    }
}
