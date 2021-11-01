using ijlynivfhp.WEBService.SeckillServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.SeckillServices.Services
{
    /// <summary>
    /// 商品服务接口
    /// </summary>
    public interface ISeckillService
    {
        IEnumerable<Seckill> GetSeckills();
        IEnumerable<Seckill> GetSeckills(Seckill seckill);
        Seckill GetSeckillById(int id);
        public Seckill GetSeckillByProductId(int ProductId);
        void Create(Seckill Seckill);
        void Update(Seckill Seckill);
        void Delete(Seckill Seckill);
        bool SeckillExists(int id);
    }
}
