using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Projects.OrderServices.Models;

namespace ijlynivfhp.Projects.OrderServices.Context
{
    /// <summary>
    /// 订单服务上下文
    /// </summary>
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        /// <summary>
        /// 订单集合
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        ///  订单项集合
        /// </summary>
        public DbSet<OrderItem> OrderItems { set; get; }
    }
}
