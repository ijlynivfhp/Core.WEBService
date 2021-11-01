using ijlynivfhp.WEBService.SeckillServices.Models;
using ijlynivfhp.WEBService.SeckillServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.SeckillTimeServices.Services
{
    /// <summary>
    /// 秒杀时间服务实现
    /// </summary>
    public class SeckillTimeModelServiceImpl : ISeckillTimeModelService
    {
        public readonly ISeckillTimeModelRepository SeckillTimeRepository;

        public SeckillTimeModelServiceImpl(ISeckillTimeModelRepository SeckillTimeRepository)
        {
            this.SeckillTimeRepository = SeckillTimeRepository;
        }

        public void Create(SeckillTimeModel SeckillTime)
        {
            SeckillTimeRepository.Create(SeckillTime);
        }

        public void Delete(SeckillTimeModel SeckillTime)
        {
            SeckillTimeRepository.Delete(SeckillTime);
        }

        public SeckillTimeModel GetSeckillTimeModelById(int id)
        {
            return SeckillTimeRepository.GetSeckillTimeModelById(id);
        }

        public IEnumerable<SeckillTimeModel> GetSeckillTimeModels()
        {
            return SeckillTimeRepository.GetSeckillTimeModels();
        }

        public void Update(SeckillTimeModel SeckillTime)
        {
            SeckillTimeRepository.Update(SeckillTime);
        }

        public bool SeckillTimeModelExists(int id)
        {
            return SeckillTimeRepository.SeckillTimeModelExists(id);
        }
    }
}
