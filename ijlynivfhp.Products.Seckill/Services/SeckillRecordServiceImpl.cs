﻿using ijlynivfhp.Projects.SeckillServices.Models;
using ijlynivfhp.Projects.SeckillServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.SeckillRecordServices.Services
{
    /// <summary>
    /// 秒杀记录服务实现
    /// </summary>
    public class SeckillRecordServiceImpl : ISeckillRecordService
    {
        public readonly ISeckillRecordRepository SeckillRecordRepository;

        public SeckillRecordServiceImpl(ISeckillRecordRepository SeckillRecordRepository)
        {
            this.SeckillRecordRepository = SeckillRecordRepository;
        }

        public void Create(SeckillRecord SeckillRecord)
        {
            SeckillRecordRepository.Create(SeckillRecord);
        }

        public void Delete(SeckillRecord SeckillRecord)
        {
            SeckillRecordRepository.Delete(SeckillRecord);
        }

        public SeckillRecord GetSeckillRecordById(int id)
        {
            return SeckillRecordRepository.GetSeckillRecordById(id);
        }

        public IEnumerable<SeckillRecord> GetSeckillRecords()
        {
            return SeckillRecordRepository.GetSeckillRecords();
        }

        public void Update(SeckillRecord SeckillRecord)
        {
            SeckillRecordRepository.Update(SeckillRecord);
        }

        public bool SeckillRecordExists(int id)
        {
            return SeckillRecordRepository.SeckillRecordExists(id);
        }
    }
}
