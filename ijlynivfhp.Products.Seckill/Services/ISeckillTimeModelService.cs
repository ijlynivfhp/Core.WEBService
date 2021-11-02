using ijlynivfhp.Projects.SeckillServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.SeckillTimeServices.Services
{
    /// <summary>
    /// 秒杀时间服务接口
    /// </summary>
    public interface ISeckillTimeModelService
    {
        IEnumerable<SeckillTimeModel> GetSeckillTimeModels();
        SeckillTimeModel GetSeckillTimeModelById(int id);
        void Create(SeckillTimeModel SeckillTime);
        void Update(SeckillTimeModel SeckillTime);
        void Delete(SeckillTimeModel SeckillTime);
        bool SeckillTimeModelExists(int id);
    }
}
