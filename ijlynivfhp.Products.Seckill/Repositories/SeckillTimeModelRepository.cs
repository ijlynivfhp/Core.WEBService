using ijlynivfhp.WEBService.SeckillServices.Context;
using ijlynivfhp.WEBService.SeckillServices.Models;
using ijlynivfhp.WEBService.SeckillServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RuanMou.MicroService.SeckillTimeModelService.Repositories
{
    /// <summary>
    /// 秒杀时间仓储实现
    /// </summary>
    public class SeckillTimeModelRepository : ISeckillTimeModelRepository
    {
        public SeckillContext SeckillContext;
        public SeckillTimeModelRepository(SeckillContext SeckillContext)
        {
            this.SeckillContext = SeckillContext;
        }
        public void Create(SeckillTimeModel SeckillTimeModel)
        {
            SeckillContext.SeckillTimeModels.Add(SeckillTimeModel);
            SeckillContext.SaveChanges();
        }

        public void Delete(SeckillTimeModel SeckillTimeModel)
        {
            SeckillContext.SeckillTimeModels.Remove(SeckillTimeModel);
            SeckillContext.SaveChanges();
        }

        public SeckillTimeModel GetSeckillTimeModelById(int id)
        {
            return SeckillContext.SeckillTimeModels.Find(id);
        }

        public IEnumerable<SeckillTimeModel> GetSeckillTimeModels()
        {
            return SeckillContext.SeckillTimeModels.ToList();
        }

        public void Update(SeckillTimeModel SeckillTimeModel)
        {
            SeckillContext.SeckillTimeModels.Update(SeckillTimeModel);
            SeckillContext.SaveChanges();
        }
        public bool SeckillTimeModelExists(int id)
        {
            return SeckillContext.SeckillTimeModels.Any(e => e.Id == id);
        }


    }
}
