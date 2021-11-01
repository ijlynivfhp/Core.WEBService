using Microsoft.AspNetCore.Mvc;
using ijlynivfhp.Core.WEBService.ProductServices.Models;
using ijlynivfhp.Core.WEBService.SeckillAggregateServices.Services;
using ijlynivfhp.Core.WEBService.UserServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.SeckillAggregateServices.Controllers
{
    /// <summary>
    /// 商品聚合控制器
    /// </summary>
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductClient productClient;
        private readonly IProductImageClient productImageClient;
        public ProductController(IProductClient productClient,
                                IProductImageClient productImageClient)
        {
            this.productClient = productClient;
            this.productImageClient = productImageClient;
        }

        /// <summary>
        /// 商品详情查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public Product GetProductDetail(User user, int productId)
        {
            // 1、查询商品
            Product product = productClient.GetProduct(productId);

            // 2、查询商品轮播图
            List<ProductImage> productImages = productImageClient.GetProductImges(productId);

            // 3、商品设置图片
            product.Images = productImages;
            return product;
        }
    }
}
