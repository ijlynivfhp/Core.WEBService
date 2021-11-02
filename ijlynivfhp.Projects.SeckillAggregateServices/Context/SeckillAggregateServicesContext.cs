using Microsoft.EntityFrameworkCore;

namespace ijlynivfhp.Projects.UserServices.Context
{
    /// <summary>
    /// 聚合服务上下文
    /// </summary>
    public class SeckillAggregateServicesContext : DbContext
    {
        public SeckillAggregateServicesContext(DbContextOptions<SeckillAggregateServicesContext> options) : base(options)
        {

        }
    }
}
