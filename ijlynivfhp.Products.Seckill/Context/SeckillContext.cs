using Microsoft.EntityFrameworkCore;
using ijlynivfhp.Projects.SeckillServices.Models;

namespace ijlynivfhp.Projects.SeckillServices.Context
{
    /// <summary>
    /// 秒杀服务上下文
    /// </summary>
    public class SeckillContext : DbContext
    {

        /// <summary>
        /// 秒杀集合
        /// </summary>
        public DbSet<Seckill> Seckills { get; set; }

        /// <summary>
        public SeckillContext(DbContextOptions<SeckillContext> options) : base(options)
        {

        }
        /// 秒杀记录集合
        /// </summary>
        public DbSet<SeckillRecord> SeckillRecords { get; set; }

        /// <summary>
        /// 秒杀时间集合
        /// </summary>
        public DbSet<SeckillTimeModel> SeckillTimeModels { get; set; }
    }
}
