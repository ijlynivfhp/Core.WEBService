using ijlynivfhp.Core.WEBService.SeckillServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.SeckillServices.Repositories
{
    /// <summary>
    /// 秒杀时间仓储接口
    /// </summary>
    public interface ISeckillTimeModelRepository
    {
        IEnumerable<SeckillTimeModel> GetSeckillTimeModels();
        SeckillTimeModel GetSeckillTimeModelById(int id);
        void Create(SeckillTimeModel SeckillTimeModel);
        void Update(SeckillTimeModel SeckillTimeModel);
        void Delete(SeckillTimeModel SeckillTimeModel);
        bool SeckillTimeModelExists(int id);
    }
}
