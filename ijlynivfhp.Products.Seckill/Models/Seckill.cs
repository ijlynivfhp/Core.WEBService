﻿using System.ComponentModel.DataAnnotations;

namespace ijlynivfhp.Projects.SeckillServices.Models
{
    /// <summary>
    /// 秒杀模型(秒杀商品)
    /// </summary>
    public class Seckill
    {
        [Key]
        public int Id { set; get; } //  主键
        public int SeckillType { set; get; } // 秒杀类型
        public string SeckillName { set; get; } // 秒杀名称
        public string SeckillUrl { set; get; } // 秒杀URL
        public decimal SeckillPrice { set; get; } // 秒杀价格
        public int SeckillStock { set; get; } // 秒杀库存
        public string SeckillPercent { set; get; } // 秒杀百分比
        public int TimeId { set; get; } // 秒杀时间编号
        public int ProductId { set; get; } // 商品编号
        public int SeckillLimit { set; get; } // 秒杀限制数量
        public string SeckillDescription { set; get; } // 秒杀描述
        public int SeckillIstop { set; get; } // 秒杀是否结束
        public int SeckillStatus { set; get; } // 秒杀状态
    }
}
