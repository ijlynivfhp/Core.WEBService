using ijlynivfhp.Projects.Cores.Middleware;

namespace ijlynivfhp.Projects.SeckillAggregateServices.Services
{
    /// <summary>
    /// 秒杀记录客户端
    /// </summary>
    public interface ISeckillRecordClient
    {
        /// <summary>
        /// 查询秒杀活动列表
        /// </summary>
        /// <returns></returns>
        public MiddleResult GetSeckillList();
    }
}
