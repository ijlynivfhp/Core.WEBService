﻿using ijlynivfhp.Projects.SeckillServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.SeckillRecordServices.Services
{
    /// <summary>
    /// 秒杀记录服务接口
    /// </summary>
    public interface ISeckillRecordService
    {
        IEnumerable<SeckillRecord> GetSeckillRecords();
        SeckillRecord GetSeckillRecordById(int id);
        void Create(SeckillRecord SeckillRecord);
        void Update(SeckillRecord SeckillRecord);
        void Delete(SeckillRecord SeckillRecord);
        bool SeckillRecordExists(int id);
    }
}
