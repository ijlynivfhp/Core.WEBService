using ijlynivfhp.Core.WEBService.SeckillServices.Context;
using ijlynivfhp.Core.WEBService.SeckillServices.Models;
using ijlynivfhp.Core.WEBService.SeckillServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RuanMou.MicroService.SeckillRecordService.Repositories
{
    /// <summary>
    /// 秒杀记录仓储实现
    /// </summary>
    public class SeckillRecordRepository : ISeckillRecordRepository
    {
        public SeckillContext SeckillContext;
        public SeckillRecordRepository(SeckillContext SeckillContext)
        {
            this.SeckillContext = SeckillContext;
        }
        public void Create(SeckillRecord SeckillRecord)
        {
            SeckillContext.SeckillRecords.Add(SeckillRecord);
            SeckillContext.SaveChanges();
        }

        public void Delete(SeckillRecord SeckillRecord)
        {
            SeckillContext.SeckillRecords.Remove(SeckillRecord);
            SeckillContext.SaveChanges();
        }

        public SeckillRecord GetSeckillRecordById(int id)
        {
            return SeckillContext.SeckillRecords.Find(id);
        }

        public IEnumerable<SeckillRecord> GetSeckillRecords()
        {
            return SeckillContext.SeckillRecords.ToList();
        }

        public void Update(SeckillRecord SeckillRecord)
        {
            SeckillContext.SeckillRecords.Update(SeckillRecord);
            SeckillContext.SaveChanges();
        }
        public bool SeckillRecordExists(int id)
        {
            return SeckillContext.SeckillRecords.Any(e => e.Id == id);
        }
    }
}
