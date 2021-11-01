using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Core.WEBService.ProductServices.Models;

namespace ijlynivfhp.Core.WEBService.ProductServices.Context
{
    /// <summary>
    /// 商品服务上下文
    /// </summary>
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        /// <summary>
        /// 商品集合
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 商品图片集合
        /// </summary>
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
