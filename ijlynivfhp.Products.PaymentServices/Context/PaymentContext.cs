using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Projects.PaymentServices.Models;

namespace ijlynivfhp.Projects.PaymentServices.Context
{
    /// <summary>
    /// 支付服务上下文
    /// </summary>
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }

        /// <summary>
        /// 订单集合
        /// </summary>
        public DbSet<Payment> Payments { get; set; }
    }
}
