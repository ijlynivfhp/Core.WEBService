using ijlynivfhp.Projects.SeckillServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.SeckillServices.Repositories
{
    /// <summary>
    /// 秒杀记录仓储接口
    /// </summary>
    public interface ISeckillRecordRepository
    {
        IEnumerable<SeckillRecord> GetSeckillRecords();
        SeckillRecord GetSeckillRecordById(int id);
        void Create(SeckillRecord SeckillRecord);
        void Update(SeckillRecord SeckillRecord);
        void Delete(SeckillRecord SeckillRecord);
        bool SeckillRecordExists(int id);
    }
}
